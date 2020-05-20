using AutoMapper;
using Bd.Web.App.DtoModels;
using Bd.Web.App.HttpService;
using Bd.Web.App.Masking;
using Bd.Web.App.WebApiClient;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bd.Web.App.Models;
using Microsoft.AspNetCore.Authorization;

namespace Bd.Web.App.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        private const string Products_Base_Address = "Products";

        private const string ProductsList_Base_Address = "Products/GetProducts";

        private IApiClient _appClient;
        private IMapper _mapper;


        public ProductsController(IApiClient appClient, IMapper mapper)
        {
            _appClient = appClient;
            _mapper = mapper;
        }



        // GET: Products
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var path = string.Format("{0}{1}", HttpClientProvider.HttpClient.BaseAddress, Products_Base_Address);
            var response = new List<ProductViewModel>();
            using (var client = HttpClientProvider.HttpClient)
            {
                response = (await _appClient.ListAsync<ProductViewModel>(path)).ToList();
            }
            response = (await PopulateUriKeyAsync(response)).ToList(); 
            return View(response);

        }


        // GET: Products/Details/5
        public ActionResult Details(string id)
        {
            var path = string.Format("{0}{1}/{2}",
                HttpClientProvider.HttpClient.BaseAddress, Products_Base_Address,
                GuidEncoder.Decode(id));
            var product = _mapper.Map<ProductViewModel>(_appClient.GetAsync<ProductDto>(path));
            product.UriKey = GuidEncoder.Encode(product.ProductId);
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            var newProduct = new ProductViewModel();
            return View("CreateEdit", newProduct);
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ProductViewModel model)
        {
            var postPath = string.Format("{0}{1}",
                HttpClientProvider.HttpClient.BaseAddress, Products_Base_Address);
            model.ProductId = Guid.NewGuid().ToString();

            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                   await _appClient.PostAsync(postPath, _mapper.Map<ProductDto>(model));
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        [HttpGet]
        // GET: Products/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            var path = string.Format("{0}/{1}", Products_Base_Address,
                GuidEncoder.Decode(id));
            var product = _mapper.Map<ProductViewModel>(await _appClient.GetAsync<ProductDto>(path));
            product.UriKey = GuidEncoder.Encode(product.ProductId);
            product.UiControl = "Create";
            return View("CreateEdit", product);
        }

        // POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductViewModel model)
        {
            model.ProductId = GuidEncoder.Decode(model.UriKey).ToString();
            var path = string.Format("{0}/{1}", Products_Base_Address,
                       model.ProductId);

            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                     await _appClient.PutAsync(path, 
                        _mapper.Map<ProductDto>(model));

                    //return RedirectToAction("Index");
                }

                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                var errMsg = ex.Message;
                return View("CreateEdit", model);
            }
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Products/Delete/5
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



        private async Task<IEnumerable<ProductViewModel>> PopulateUriKeyAsync(List<ProductViewModel> products)
        {
            return await Task.Run(() =>
            {
                return products.Select(p =>
                {
                    p.UriKey = GuidEncoder.Encode(p.ProductId);
                    return p;
                });
            });
        }
    }
}