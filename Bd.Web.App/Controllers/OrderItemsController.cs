using AutoMapper;
using Bd.Web.App.DtoModels;
using Bd.Web.App.HttpService;
using Bd.Web.App.Masking;
using Bd.Web.App.Models;
using Bd.Web.App.WebApiClient;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bd.Web.App.Controllers
{
    [Authorize]
    public class OrderItemsController : Controller
    {

        private readonly string Base_Address = "OrderItems";
        private readonly string OrderItems_By_OrderId = "OrderItems/GetOrderItemsByOrderId";
        private readonly string OwnerOfOrder = "Utilities/GetOrderAppUserNameAsync";
        private readonly string Products_Base_Address = "Products";
        private readonly IApiClient _apiClient;
        private readonly IMapper _mapper;

        public OrderItemsController(IApiClient apiClient, IMapper mapper)
        {
            _apiClient = apiClient;
            _mapper = mapper;
        }
        // GET: OrderItems
        public async Task<ActionResult> Index()
        {
            var path = string.Format("{0}{1}", HttpClientProvider.HttpClient.BaseAddress, Base_Address);
            var response = new List<OrderItemViewModel>();
            using (var client = HttpClientProvider.HttpClient)
            {
                response = _mapper
                    .Map<IEnumerable<OrderItemViewModel>>((
                    await _apiClient.ListAsync<OrderItemDto>(path)))
                    .ToList();
                response = (await PopulateUriKeyAsync(response)).ToList();
                return View(response);
            }
        }


        [HttpGet]
        public async Task<IActionResult> GetOrderItemsByOrderId(string id)
        {
            var decodedId = GuidEncoder.Decode(id);
            var userPath = string.Format("{0}/{1}", OwnerOfOrder, decodedId);
            var ownerDetails = await _apiClient.GetAsync<AppUserNameDto>(userPath);
            ViewBag.Owner = ownerDetails.FullName;
            var path = string.Format("{0}/{1}", OrderItems_By_OrderId,
                decodedId);
            var orderItems = _mapper.Map<IEnumerable<OrderItemViewModel>>(await _apiClient.ListAsync<OrderItemDto>(path));


            orderItems = await PopulateUriKeyAsync(orderItems.ToList());
            orderItems = await PopulateProductTypesAsync(orderItems);

            return View("Index", orderItems);
        }





        // GET: OrderItems/Details/5
        public async Task<ActionResult> Details(string id)
        {
            var path = string.Format("{0}/{1}", Base_Address,
                GuidEncoder.Decode(id));
            var orderItem = _mapper.Map<OrderItemViewModel>(await _apiClient.GetAsync<OrderItemDto>(path));
            orderItem.UriKey = GuidEncoder.Encode(orderItem.OrderItemId);
            return View(orderItem);
        }

        // GET: OrderItems/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrderItems/Create
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

        // GET: OrderItems/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrderItems/Edit/5
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

        // GET: OrderItems/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrderItems/Delete/5
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




        private async Task<IEnumerable<OrderItemViewModel>> PopulateUriKeyAsync(List<OrderItemViewModel> orders)
        {
            return await Task.Run(() =>
            {
                return orders.Select(oi =>
                {
                    oi.UriKey = GuidEncoder.Encode(oi.OrderItemId);
                    return oi;
                });
            });
        }


        private async Task<IEnumerable<OrderItemViewModel>> PopulateProductTypesAsync(IEnumerable<OrderItemViewModel> orderItems)
        {
            return orderItems =  await DelegatedPopulateProductTypesAsync(orderItems);

        }

        private async Task<IEnumerable<OrderItemViewModel>> DelegatedPopulateProductTypesAsync(IEnumerable<OrderItemViewModel> orderItems)
        {


            return orderItems = await Task.Run(() =>
            {
                orderItems.Select(async oi =>
                {
                    var id = oi.ProductId;
                    var path = string.Format("{0}/{1}", Products_Base_Address,
                    GuidEncoder.Decode(id));
                    oi.Product = _mapper
                        .Map<ProductViewModel>(await _apiClient
                        .GetAsync<ProductDto>(path));
                    return oi;
                });
                return orderItems;
            });

        }





    }
}