﻿using AutoMapper;
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
    public class PricesController : Controller
    {
        private const string Base_Address = "Prices";

        

        private IApiClient _apiClient;
        private IMapper _mapper;

        public PricesController(IApiClient apiClient, IMapper mapper)
        {
            _apiClient = apiClient;
            _mapper = mapper;

        }

        // GET: Prices
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var path = string.Format("{0}{1}", HttpClientProvider.HttpClient.BaseAddress, Base_Address);
            var prices = new List<PricesViewModel>();
            using (var client = HttpClientProvider.HttpClient)
            {
                prices = _mapper.Map<IEnumerable<PricesViewModel>>(await _apiClient.ListAsync<ProductViewModel>(path)).ToList();
            }
            prices = (await PopulateUriKeyAsync(prices)).ToList();
            return View(prices);
        }



        // GET: Prices/Details/5
        [HttpGet]
        public ActionResult Details(string id)
        {
            var path = string.Format("{0}{1}/{2}",
                HttpClientProvider.HttpClient.BaseAddress, Base_Address,
                GuidEncoder.Decode(id));
            var price = _mapper.Map<PricesViewModel>(_apiClient.GetAsync<PricesDto>(path));
            price.UriKey = GuidEncoder.Encode(price.PriceId);
            return View(price);
        }



        // GET: Prices/Create
        [HttpGet]
        public ActionResult Create()
        {
            var newPrice = new PricesViewModel()
            {
                PriceId = Guid.NewGuid().ToString()
            };
            newPrice.UriKey = GuidEncoder.Encode(newPrice.PriceId);
            return View("CreateEdit", newPrice);
        }

        // POST: Prices/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(PricesViewModel model)
        {
            var path = string.Format("{0}{1}",
                HttpClientProvider.HttpClient.BaseAddress, Base_Address);
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    model.PriceId = GuidEncoder.Decode(model.UriKey).ToString();
                    var result = await _apiClient.PostAsync<PricesDto>(path,
                        _mapper.Map<PricesDto>(model));
                    return RedirectToAction(nameof(Index));
                }

                return View();
            }
            catch(Exception ex)
            {
                var errMsg = ex.Message;
                return View();
            }
        }



        // GET: Prices/Edit/5
        [HttpGet]
        public ActionResult Edit(string id)
        {
            var path = string.Format("{0}{1}/{2}",
                HttpClientProvider.HttpClient.BaseAddress, Base_Address,
                GuidEncoder.Decode(id));
            var price = _mapper.Map<PricesViewModel>(_apiClient.GetAsync<PricesDto>(path));
            price.UriKey = GuidEncoder.Encode(price.PriceId);
            return View(price);
        }

        // POST: Prices/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(PricesViewModel model)
        {
            var path = string.Format("{0}{1}/{2}",
                HttpClientProvider.HttpClient.BaseAddress, Base_Address, GuidEncoder.Decode(model.UriKey));
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    model.PriceId = GuidEncoder.Decode(model.UriKey).ToString();
                    await _apiClient.PutAsync<PricesDto>(path,
                        _mapper.Map<PricesDto>(model));
                    return RedirectToAction(nameof(Index));
                }

                return View();
            }
            catch (Exception ex)
            {
                var errMsg = ex.Message;
                return View();
            }
        }

        // GET: Prices/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Prices/Delete/5
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

        private async Task<IEnumerable<PricesViewModel>> PopulateUriKeyAsync(List<PricesViewModel> products)
        {
            return await Task.Run(() =>
            {
                return products.Select(p =>
                {
                    p.UriKey = GuidEncoder.Encode(p.PriceId);
                    return p;
                });
            });
        }



    }
}