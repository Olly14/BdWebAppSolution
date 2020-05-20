using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Bd.Web.App.DtoModels;
using Bd.Web.App.HttpService;
using Bd.Web.App.Masking;
using Bd.Web.App.Models;
using Bd.Web.App.WebApiClient;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bd.Web.App.Controllers
{
    [Authorize]
    public class DriversController : Controller
    {

        private readonly string Base_Address = "Orders";

        private readonly string Orders_with_AppUser = "Orders/GetOrdersWithAppUsers";

        private readonly string OrdersList_Base_Address = "Orders/GetOrders";

        private readonly string Order_Base_Address = "Orders/GetOrder";

        private readonly IApiClient _apiClient;
        private readonly IMapper _mapper;



        public DriversController(IMapper mapper, IApiClient apiClient)
        {
            _apiClient = apiClient;
            _mapper = mapper;
        }


        // GET: Drivers
        public async Task<ActionResult> Index()
        {
            var path = string.Format("{0}{1}", HttpClientProvider.HttpClient.BaseAddress, Base_Address);
            var response = new List<OrderViewModel>();
            using (var client = HttpClientProvider.HttpClient)
            {
                response = _mapper
                    .Map<IEnumerable<OrderViewModel>>((
                    await _apiClient.ListAsync<OrderDto>(path)))
                    .ToList();
                response = (await PopulateUriKeyAsync(response)).ToList();
                return View(response);
            }
        }

        public async Task<ActionResult> Complete(string id)
        {
            var path = string.Format("{0}", Base_Address);

            var check = OrderDeliveredConfirmed(id);
            if (check)
            {
                var pathUpdate = string.Format("{0}/{1}", Base_Address, GuidEncoder.Decode(id));
                var order = await _apiClient.GetAsync<OrderDto>(path);
                order.Status = "Complete";
                await _apiClient.PutAsync<OrderDto>(pathUpdate, order);
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        private bool OrderDeliveredConfirmed(string id)
        {
            //Todo
            return true;
        }


        // GET: Drivers/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Drivers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Drivers/Create
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

        // GET: Drivers/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Drivers/Edit/5
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

        // GET: Drivers/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Drivers/Delete/5
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

        private async Task<OrderViewModel> PopulateUriKeyAsync(OrderViewModel order)
        {
            return await Task.Run(() =>
            {
                order.UriKey = GuidEncoder.Encode(order.OrderId);
                return order;
            });

        }

        private async Task<IEnumerable<OrderViewModel>> PopulateUriKeyAsync(List<OrderViewModel> orders)
        {
            return await Task.Run(() =>
            {
                return orders.Select(o =>
                {
                    o.UriKey = GuidEncoder.Encode(o.OrderId);
                    return o;
                });
            });
        }





    }
}
