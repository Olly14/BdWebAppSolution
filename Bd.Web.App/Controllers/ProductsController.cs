using AutoMapper;
using Bd.web.App.ViewModels;
using Bd.Web.App.HttpService;
using Bd.Web.App.Models;
using Bd.Web.App.WebApiClient;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            var path = string.Format("{0}{1}", HttpClientProvider.HttpClient.BaseAddress, ProductsList_Base_Address);
            var response = new List<ProductModel>();
            using (var client = HttpClientProvider.HttpClient)
            {
                response = (await _appClient.ListAsync<ProductModel>(path)).ToList();
                return View(response);
            }

        }

        // GET: Products/Details/5
        public ActionResult Details(int id)
        {
            return View();
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

        // GET: Products/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

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
    }
}