using AutoMapper;
using Bd.Web.App.DtoModels;
using Bd.Web.App.HttpService;
using Bd.Web.App.Masking;
using Bd.Web.App.Models;
using Bd.Web.App.WebApiClient;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bd.Web.App.Controllers
{
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
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        [HttpGet]
        // GET: Products/Edit/5
        public async Task<ActionResult> EditAsync(string id)
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
        public ActionResult Edit(ProductViewModel model)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {

                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
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