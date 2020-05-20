using AutoMapper;
using Bd.Web.App.WebApiClient;
using Bd.Web.App.DtoModels;
using Bd.Web.App.HttpService;
using Bd.Web.App.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bd.Web.App.Masking;

namespace Bd.Web.App.Controllers
{
    [Authorize]
    public class CustomerRelationshipMgmsController : Controller
    {
        private const string BaseUri = "AppUsers";
        private const string BaseUri_WithOutOrders = "AppUsers/GetAppUsersWithoutOrders";
        private const string UsersBaseUri = "Users";
        private const string User_ByUserIdUri = "Users/GetByUserId";
        private const string BaseUriCountry = "DropDownLists/GetCountries";
        private const string BaseUriGender = "DropDownLists";

        private const string AppUsers_Put = "AppUsers/PutAppUser";





        private readonly IApiClient _apiClient;
        private readonly IMapper _mapper;


        public CustomerRelationshipMgmsController(IApiClient apiClient, IMapper mapper)
        {
            _apiClient = apiClient;
            _mapper = mapper;

        }


        [HttpGet]
        // GET: CustomerRelationshipMgms
        public async Task<ActionResult> Index()
        {
            var users = await AppUsersAsync(BaseUri_WithOutOrders);
            users = PopulateUriKey(users);
            users = await PopulateCountryGenderIdsValuesOfUsersAsync(users.ToList());
            return View(users);
        }

        public async Task<ActionResult> WelcomeNewUser(string emailId)
        {
            var path = string.Format("{0}/{1}", UsersBaseUri, emailId);
            var user = _mapper.Map<UserViewModel>(await _apiClient.GetAsync<UserDto>(path));
            user.UriKey = GuidEncoder.Encode(user.SubjectId);
            return View(user);
        }


        [HttpGet]
        // GET: CustomerRelationshipMgms/Details/5
        public async Task<ActionResult> Details(string id)
        {
            var decodedId = GuidEncoder.Decode(id).ToString();

            var path = string.Format("{0}/{1}", BaseUri, decodedId);
            var user = await AppUserAsync(path);
            user.UriKey = GuidEncoder.Encode(user.AppUserId);
            user = await PopulateCountryGenderIdsValuesAsync(user);
            return View(user);
        }
        
        [HttpGet]
        // GET: CustomerRelationshipMgms/Create
        public async Task<ActionResult> Create(string id)
        {
            await PopulateViewBagsAsync();
            var path = string.Format("{0}/{1}", User_ByUserIdUri, GuidEncoder.Decode(id));
            var user = await _apiClient.GetAsync<UserDto>(path);

            var newUser = new AppUserViewModel();
            newUser.UriKey = GuidEncoder.Encode(user.SubjectId);
            newUser.DisplayName = user.Username;
            newUser.UiControl = "Create";
            return View("CreateEdit", newUser);
        }

        // POST: CustomerRelationshipMgms/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(AppUserViewModel model)
        {
            var userPath = string.Format("{0}/{1}", User_ByUserIdUri, GuidEncoder.Decode(model.UriKey));
            var user = _mapper.Map<UserViewModel>(await _apiClient.GetAsync<UserDto>(userPath));


            var path = string.Format("{0}{1}", HttpClientProvider.HttpClient.BaseAddress, BaseUri);
            model.UserName = user.Username;
            model.SubjectId = GuidEncoder.Decode(model.UriKey).ToString();
            model.AppUserId = Guid.NewGuid().ToString();
            model.IsActive = true;
            model.CreatedDate = DateTime.UtcNow;
            model.ModifiedDate = DateTime.UtcNow;

            model.GenderId = GuidEncoder.Decode(model.GenderId).ToString();
            model.CountryId = GuidEncoder.Decode(model.CountryId).ToString();
            //model.User = user;
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    await _apiClient.PostAsync(path, _mapper.Map<AppUserDto>(model));

                    return RedirectToAction(nameof(Index));
                }
                await PopulateViewBagsAsync();
                return View();

            }
            catch (Exception ex)
            {
                var msgError = ex.Message;
                await PopulateViewBagsAsync();
                return View();
            }
        }
        [HttpGet]
        // GET: CustomerRelationshipMgms/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            await PopulateViewBagsAsync();
            var decodedId = GuidEncoder.Decode(id).ToString();

            var path = string.Format("{0}/{1}", BaseUri, decodedId);
            var user = await AppUserAsync(path);
            user.UriKey = GuidEncoder.Encode(user.AppUserId);
            user.SubjectId = GuidEncoder.Encode(user.SubjectId);
            user.UiControl = "Edit";
            return View("CreateEdit", user);
        }

        // POST: CustomerRelationshipMgms/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(AppUserViewModel model)
        {
            model.AppUserId = GuidEncoder.Decode(model.UriKey).ToString();
            model.SubjectId = GuidEncoder.Decode(model.SubjectId).ToString();

            try
            {
                var path = string.Format("{0}", BaseUri);
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    await _apiClient.PutAsync(path, _mapper.Map<AppUserDto>(model));
                    return RedirectToAction(nameof(Index));
                }
                await PopulateViewBagsAsync();
                return View();
            }
            catch(Exception ex)
            {
                var errMsg = ex.Message;
                return View();
            }
        }

        // GET: CustomerRelationshipMgms/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CustomerRelationshipMgms/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        private IEnumerable<AppUserViewModel> PopulateUriKey(IEnumerable<AppUserViewModel> models)
        {
            models = models.Select(a =>
            {
                a.UriKey = GuidEncoder.Encode(a.AppUserId.ToString());
                return a;
            });
            return models;
        }


        private async Task<IEnumerable<GenderViewModel>> GetGendersAsync()
        {
            return await _apiClient.GetAsync<IEnumerable<GenderViewModel>>(BaseUriGender);
        }

        private async Task<IEnumerable<CountryViewModel>> GetCountriesAsync()
        {
            return await _apiClient.GetAsync<IEnumerable<CountryViewModel>>(BaseUriCountry);
        }


        private async Task<AppUserViewModel> AppUserAsync(string path)
        {
            return await _apiClient.GetAsync<AppUserViewModel>(path);
        }

        private async Task<IEnumerable<AppUserViewModel>> AppUsersAsync(string appUserBaseUri)
        {
            return await _apiClient.ListAsync<AppUserViewModel>(appUserBaseUri);
        }

        private async Task<IEnumerable<AppUserViewModel>> PopulateCountryGenderIdsValuesOfUsersAsync(List<AppUserViewModel> appUsers)
        {
            var countries = await GetCountriesAsync();
            var genders = await GetGendersAsync();
            return await Task.Run(() => appUsers.Select(au =>
             {

                 au = GetCountryIdValue(countries, au);
                 au = GetGenderIdValue(genders, au);
                 return au;
             }));

            //var countries = await GetCountriesAsync();
            //var genders = await GetGendersAsync();
            //appUser = await Task.Run(() => GetCountryIdValue(countries, appUser));
            //appUser = await Task.Run(() => GetGenderIdValue(genders, appUser));
            //return appUser;
        }

        private async Task<AppUserViewModel> PopulateCountryGenderIdsValuesAsync(AppUserViewModel appUser)
        {
            var countries = await GetCountriesAsync();
            var genders = await GetGendersAsync();
            appUser = await Task.Run(() => GetCountryIdValue(countries, appUser));
            appUser = await Task.Run(() => GetGenderIdValue(genders, appUser));
            return appUser;
        }

        private AppUserViewModel GetCountryIdValue(IEnumerable<CountryViewModel> genders, AppUserViewModel appUser)
        {
            appUser.CountryIdValue = genders.FirstOrDefault(g => string.Compare(g.CountryId, appUser.CountryId, true) == 0).CountryName;
            return appUser;
        }

        private AppUserViewModel GetGenderIdValue(IEnumerable<GenderViewModel> genders, AppUserViewModel appUser)
        {
            appUser.GenderIdValue = genders.FirstOrDefault(g => string.Compare(g.GenderId, appUser.GenderId, true) == 0).Type;
            return appUser;
        }

        public async Task PopulateViewBagsAsync()
        {
            var genders = await GetGendersAsync();
            var countries = await GetCountriesAsync();
            genders = await PopulateGenderUriKeyAsync(genders.ToList());
            countries = await PopulateCountryUriKeyAsync(countries.ToList());
            ViewBag.Genders = genders;
            ViewBag.Countries = countries;
        }

        public async Task<IEnumerable<GenderViewModel>> PopulateGenderUriKeyAsync(List<GenderViewModel> genders)
        {
            return await Task.Run(() =>

                genders.Select(g => { g.UriKey = GuidEncoder.Encode(g.GenderId); return g; })
            );
        }

        public async Task<IEnumerable<CountryViewModel>> PopulateCountryUriKeyAsync(List<CountryViewModel> countries)
        {
            return await Task.Run(() =>

                countries.Select(g => { g.UriKey = GuidEncoder.Encode(g.CountryId); return g; })
            );
        }
    }
}