using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Bd.Web.App.DtoModels;
using Bd.Web.App.Helpers;
using Bd.Web.App.HttpService;
using Bd.Web.App.Models;
using Bd.Web.App.WebApiClient;
using Bd.Web.App.WebApiClients;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bd.Web.App.Controllers
{
    public class RegistrationsController : Controller
    {
        private const string Users_BaseUri = "Users";
        private const string Registration_EmailUri = "Users/GetUserBymail";
        private const string User_ByUserIdUri = "Users/GetByUserId";
        private const string Registration_UserUri = "Users/GetUser";

        private const string Genders_Uri = "DropDownLists/GetGenders";
        private const string DDL_Uri = "DropDownLists";
        private const string Countries_Uri = "DropDownLists/GetCountries";

        private const string Base_AppUserUri = "AppUsers";
        private const string AppUsers_Post = "AppUsers/PostAppUser";
        private const string Base_GetAppUserUri = "AppUsers/GetByAppUserId";
        private const string AppUsers_Put = "AppUsers/PutAppUser";


        private readonly IMapper _mapper;
        private readonly IApiClient _apiClient;

        public RegistrationsController(IMapper mapper, IApiClient apiClient)
        {
            _apiClient = apiClient;
            _mapper = mapper;
        }



        // GET: Registrations
        [HttpGet]
        public ActionResult Registration()
        {
            var newUser = new RegistratioViewModel();
            return View(newUser);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Registration(RegistratioViewModel model)
        {
            model.Username = model.Email;
            model.SubjectId = Guid.NewGuid().ToString();
            var path = string.Format("{0}{1}", HttpClientProvider.HttpClient.BaseAddress, Users_BaseUri);

            if (ModelState.IsValid)
            {
                model.Password = PasswordBaseKeyDerivationFunction.HashPassword(model.Password);
                model.IsActive = true;
                var result = _mapper.Map<UserDto>(await _apiClient.PostAsync(path, model));

                return RedirectToAction("WelcomeNewUser", "CustomerRelationshipMgms", new { emailId = model.Email });

            }


            return View();
        }

        // GET: Registrations/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Registrations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Registrations/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Registration));
            }
            catch
            {
                return View();
            }
        }

        // GET: Registrations/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Registrations/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Registration));
            }
            catch
            {
                return View();
            }
        }

        // GET: Registrations/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Registrations/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Registration));
            }
            catch
            {
                return View();
            }
        }
    }
}