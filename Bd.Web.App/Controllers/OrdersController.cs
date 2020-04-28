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
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bd.Web.App.Controllers
{
    public class OrdersController : Controller
    {

        private readonly string Base_Address = "Orders";

        private readonly string OrderItems_By_OrderId = "Orders/GetOrderAndOrderItems";

        private readonly string OrdersList_Base_Address = "Orders/GetOrders";

        private readonly string Order_Base_Address = "Orders/GetOrder";

        private readonly IApiClient _apiClient;
        private readonly IMapper _mapper;



        public OrdersController(IApiClient apiClient, IMapper mapper)
        {
            _apiClient = apiClient;
            _mapper = mapper;
        }


        // GET: Orders

        public async Task<ActionResult> GetOrders()
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

        // GET: Orders/Details/5
        public async Task<ActionResult> Details(string id)
        {
            var path = string.Format("{0}/{1}", Base_Address,
                GuidEncoder.Decode(id));
            var order = _mapper.Map<OrderViewModel>(await _apiClient.GetAsync<OrderDto>(path));
            order.UriKey = GuidEncoder.Encode(order.OrderId);
            return View(order);
        }


        [HttpGet]
        public async Task<ActionResult> OrderItems(string id)
        {
            var path = string.Format("{0}/{1}", Base_Address,
                GuidEncoder.Decode(id));
            var order = _mapper.Map<OrderViewModel>(await _apiClient.GetAsync<OrderDto>(path));
            order.UriKey = GuidEncoder.Encode(order.OrderId);
            return RedirectToAction("GetOrderItemsByOrderId", nameof(OrderItems), new {id = order.UriKey } );
        }



        // GET: Orders/Create
        public ActionResult Create()
        {
            var newOrder = new OrderViewModel();
            return View("CreateEdit", newOrder);
        }

        // POST: Orders/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrderViewModel model)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(GetOrders));
            }
            catch
            {
                return View();
            }
        }

        // GET: Orders/Edit/5
        public async Task<ActionResult> EditAsync(string id)
        {
            var path = string.
                    Format("{0}{1}", 
                    HttpClientProvider.HttpClient.BaseAddress, Order_Base_Address, 
                    GuidEncoder.Decode(id));
            var orderToEdit = await PopulateUriKeyAsync(
                   _mapper.Map<OrderViewModel>(
                       await _apiClient.GetAsync<OrderDto>(path)));
            orderToEdit.UiControl = "EditUi";
            return View("CreateEdit", orderToEdit );
        }

        // POST: Orders/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(OrderViewModel model)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(GetOrders));
            }
            catch
            {
                return View();
            }
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Orders/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(GetOrders));
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