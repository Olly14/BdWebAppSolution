using AutoMapper;
using Bd.Web.App.DtoModels;
using Bd.Web.App.HttpService;
using Bd.Web.App.Masking;
using Bd.Web.App.Models;
using Bd.Web.App.Utilities;
using Bd.Web.App.WebApiClient;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bd.Web.App.Controllers
{
    public class ShoppingCartsController : Controller
    {
        private readonly string Products_Base_Address = "Products";

        private readonly string Orders_Base_Address = "Orders";

        private readonly string ConfirmOrder_Base_Address = "Orders/PostOrder";

        private readonly string ProductsList_Base_Address = "Product/GetProducts";

        private readonly string OneProduct_Base_Address = "Products/GetProduct";

        private readonly string DropDownLists_Base_Address = "Prices";

        private readonly string PricesList_Base_Address = "Prices";

        private readonly string GendersList_Base_Address = "Prices/GetGenders";

        private readonly string SinglePriceByType_Base_Address = "Prices/GetPricesByType";


        private readonly IMapper _mapper;
        private readonly IApiClient _apiClient;
        private readonly IOrderItemBasket _orderItemBasket;

        public ShoppingCartsController(IMapper mapper, IApiClient apiClient, IOrderItemBasket orderItemBasket)
        {
            _mapper = mapper;
            _apiClient = apiClient;
            _orderItemBasket = orderItemBasket;
        }


        // GET: ShoppingCartController
        [HttpGet]
        public async Task<IActionResult> Index(string id)
        {
            var path = string.Format("{0}/{1}", Products_Base_Address,
                            GuidEncoder.Decode(id));
            var product = PopulateUriKey(
                            _mapper.Map<ProductViewModel>(
                                await _apiClient.GetAsync<ProductDto>(path)));
            product = await PopulatePricesAsync(product);
            var products = await PopulateAndCreateTypesAsync(product);

            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> AddItem(string id, string type)
        {
            var path = string.Format("{0}/{1}", Products_Base_Address,
                            GuidEncoder.Decode(id));
            var product = PopulateUriKey(
                _mapper.Map<ProductViewModel>(
                    await _apiClient.GetAsync<ProductDto>(path)));
            var pricePath = string.Format("{0}/{1}", SinglePriceByType_Base_Address, type);
            var price = _mapper.Map<PricesViewModel>(
                    await _apiClient.GetAsync<PricesDto>(pricePath));

            product.Prices.Add(price);
            product.Type = type;
            product.Price = price.Price;

            var oi = await Task.Run(() =>
            {
                var orderItem = new OrderItemViewModel()
                {
                    Product = product,
                    Quantity = 1,
                    ProductType = product.Type,
                    ProductDescription = product.Description,
                    UriKey = id
                };
                orderItem.ProductName = product.Name;
                orderItem.TotalQuantityPrice = orderItem.Quantity * product.Price;
                orderItem.Product = product;
                orderItem.UnitPrice = product.Price;
                orderItem.Description = product.Description;
                return orderItem;
                //_orderItemBasket.OrderItems.Add(orderItem);
            });

            _orderItemBasket.OrderItems.Add(oi);


            return RedirectToAction(nameof(ListOfBasketItems));
        }


        [HttpGet]
        public IActionResult ListOfBasketItems()
        {
            var orderItems = _orderItemBasket.OrderItems;
            return View(orderItems);
        }

        [HttpGet]
        public IActionResult AddSameItemOnceToBasket(string id, string type)
        {
            var productId = GuidEncoder.Decode(id).ToString();
            var orderItems = _orderItemBasket.OrderItems;
            var orderItemsSize = orderItems.Count;
            var orderItem = new OrderItemViewModel();

            foreach (var item in orderItems)
            {
                var sameProductId = string.Compare(item.ProductId, productId, true);
                var sameType = string.Compare(item.ProductType, type, true);
                if (sameProductId + sameType == 0)
                {
                    item.Quantity += 1;
                    item.TotalQuantityPrice = item.Quantity * item.Product.Price;
                }
            }
            return RedirectToAction(nameof(ListOfBasketItems));
        }

        [HttpGet]
        public IActionResult RemoveSameItemOnceFromBasket(string id, string type)
        {
            var orderItems = _orderItemBasket.OrderItems;
            var orderItem = orderItems
                .FirstOrDefault(o => string.Compare(o.ProductId, GuidEncoder.Decode(id).ToString(), true) == 0);

            if (orderItems.Count >= 1)
            {
                orderItem.Quantity -= 1;
                orderItem.TotalQuantityPrice = orderItem.Quantity * orderItem.Product.Price;
            }

            return RedirectToAction(nameof(ListOfBasketItems));
        }

        public async Task<IActionResult> ConfirmOrder()
        {
            var orderItems = _orderItemBasket.OrderItems;
            var order = await CreateOrderAsync(orderItems);
            var path = string.Format("{0}{1}",HttpClientProvider.HttpClient.BaseAddress, Orders_Base_Address);

            //var path = string.Format("{0}{1}",HttpClientProvider.HttpClient.BaseAddress, ConfirmOrder_Base_Address);
            var orderPostResult = await _apiClient.PostAsync(path, _mapper.Map<OrderDto>(order));
            var confirmedOrder = _mapper.Map<OrderViewModel>(orderPostResult);
            return View(confirmedOrder);
        }

        // GET: ShoppingCartController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ShoppingCartController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShoppingCartController/Create
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

        // GET: ShoppingCartController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ShoppingCartController/Edit/5
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

        // GET: ShoppingCartController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ShoppingCartController/Delete/5
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

        private ProductViewModel PopulateUriKey(ProductViewModel product)
        {
            product.UriKey = GuidEncoder.Encode(product.ProductId);
            return product;
        }

        private async Task<IEnumerable<PricesViewModel>> GetPricesAsync()
        {
            var path = string.Format("{0}{1}",
                        HttpClientProvider.HttpClient.BaseAddress, PricesList_Base_Address);
           var result = _mapper.Map<IEnumerable<PricesViewModel>>(
                    await _apiClient.ListAsync<PricesDto>(path));
            return result;
        }

        private async Task<ProductViewModel> PopulatePricesAsync(ProductViewModel product)
        {
            product.Prices = (await GetPricesAsync()).ToList();
            return product;
        }

        private async Task<List<ProductViewModel>> PopulateAndCreateTypesAsync(ProductViewModel product)
        {
            var products = new List<ProductViewModel>();
            product = await PopulatePricesAsync(product);
            return await Task.Run(() =>
            {
                products =  PopulateAndCreateTypes(product);
                return products;
            });
        }

        private List<ProductViewModel> PopulateAndCreateTypes(ProductViewModel product)
        {
            var detailedProducts = new List<ProductViewModel>();
            var prices = product.Prices;
            var totalPrices = prices.Count;
            for (int i = 0;  i < totalPrices; i++)
            {
                var price = prices[i];
                var type = price.Type;
                if (string.Compare(type, PricesType.XXSmallType, true) == 0)
                {
                    product.XXSmallType = price.Type;
                    var xxSmallTypeProduct = new ProductViewModel();
                   
                    xxSmallTypeProduct = _mapper.Map<ProductViewModel>(product);
                    xxSmallTypeProduct.Type = price.Type;
                    xxSmallTypeProduct.Price = price.Price;
                    detailedProducts.Add(xxSmallTypeProduct);
                }
                else if (string.Compare(type, PricesType.XSmallType, true) == 0)
                {
                    product.XSmallType = price.Type;
                    var xSmallTypeProduct = new ProductViewModel();

                    xSmallTypeProduct = _mapper.Map<ProductViewModel>(product);
                    xSmallTypeProduct.Type = price.Type;
                    xSmallTypeProduct.Price = price.Price;
                    detailedProducts.Add(xSmallTypeProduct);
                }
                else if (string.Compare(type, PricesType.SmallType, true) == 0)
                {
                    product.SmallType = price.Type;
                    var smallTypeProduct = new ProductViewModel();

                    smallTypeProduct = _mapper.Map<ProductViewModel>(product);
                    smallTypeProduct.Type = price.Type;
                    smallTypeProduct.Price = price.Price;
                    detailedProducts.Add(smallTypeProduct);
                }
                else if (string.Compare(type, PricesType.MediumType, true) == 0)
                {
                    product.MediumType = price.Type;
                    var mediumTypeProduct = new ProductViewModel();

                    mediumTypeProduct = _mapper.Map<ProductViewModel>(product);
                    mediumTypeProduct.Type = price.Type;
                    mediumTypeProduct.Price = price.Price;
                    detailedProducts.Add(mediumTypeProduct);
                }
                else if (string.Compare(type, PricesType.XMediumType, true) == 0)
                {
                    product.XMediumType = price.Type;
                    var xMediumTypeProduct = new ProductViewModel();

                    xMediumTypeProduct = _mapper.Map<ProductViewModel>(product);
                    xMediumTypeProduct.Type = price.Type;
                    xMediumTypeProduct.Price = price.Price;
                    detailedProducts.Add(xMediumTypeProduct);
                }
                else if (string.Compare(type, PricesType.XXMediumType, true) == 0)
                {
                    product.XXMediumType = price.Type;
                    var xxMediumTypeProduct = new ProductViewModel();

                    xxMediumTypeProduct = _mapper.Map<ProductViewModel>(product);
                    xxMediumTypeProduct.Type = price.Type;
                    xxMediumTypeProduct.Price = price.Price;
                    detailedProducts.Add(xxMediumTypeProduct);
                }

                else if (string.Compare(type, PricesType.LargeType, true) == 0)
                {
                    product.LargeType = price.Type;
                    var largeTypeProduct = new ProductViewModel();

                    largeTypeProduct = _mapper.Map<ProductViewModel>(product);
                    largeTypeProduct.Type = price.Type;
                    largeTypeProduct.Price = price.Price;
                    detailedProducts.Add(largeTypeProduct);
                }
                else if (string.Compare(type, PricesType.XLargeType, true) == 0)
                {
                    product.XLargeType = price.Type;
                    var xLargeTypeProduct = new ProductViewModel();

                    xLargeTypeProduct = _mapper.Map<ProductViewModel>(product);
                    xLargeTypeProduct.Type = price.Type;
                    xLargeTypeProduct.Price = price.Price;
                    detailedProducts.Add(xLargeTypeProduct);
                }
                else if (string.Compare(type, PricesType.XXLargeType, true) == 0)
                {
                    product.XXLargeType = price.Type;
                    var xxLargeTypeProduct = new ProductViewModel();

                    xxLargeTypeProduct = _mapper.Map<ProductViewModel>(product);
                    xxLargeTypeProduct.Type = price.Type;
                    xxLargeTypeProduct.Price = price.Price;
                    detailedProducts.Add(xxLargeTypeProduct);
                }
            }
            return detailedProducts;
        }



        private ProductViewModel PopulateTypes(ProductViewModel product)
        {
            var prices = product.Prices;
            var totalPrices = prices.Count;

            for (int i = 0; i < totalPrices; i++)
            {
                var price = prices[i];
                var type = price.Type;
                if (string.Compare(type, PricesType.XXSmallType, true) == 0)
                {
                    product.XXSmallType = price.Type;
                }
                else if (string.Compare(type, PricesType.XSmallType, true) == 0)
                {
                    product.XSmallType = price.Type;
                }
                else if (string.Compare(type, PricesType.SmallType, true) == 0)
                {
                    product.SmallType = price.Type;
                }
                else if (string.Compare(type, PricesType.MediumType, true) == 0)
                {
                    product.MediumType = price.Type;
                }
                else if (string.Compare(type, PricesType.XMediumType, true) == 0)
                {
                    product.XMediumType = price.Type;
                }
                else if (string.Compare(type, PricesType.XXMediumType, true) == 0)
                {
                    product.XXMediumType = price.Type;
                }

                else if (string.Compare(type, PricesType.LargeType, true) == 0)
                {
                    product.LargeType = price.Type;
                }
                else if (string.Compare(type, PricesType.XLargeType, true) == 0)
                {
                    product.XLargeType = price.Type;
                }
                else if (string.Compare(type, PricesType.XXLargeType, true) == 0)
                {
                    product.XXLargeType = price.Type;
                }
            }
            return product;
        }


        private async Task<OrderViewModel> CreateOrderAsync(List<OrderItemViewModel> orderItems)
        {
            return await Task.Run(() =>
            {
                var order = CreateOrders(orderItems);
                return order;
            });
        }

        private OrderViewModel CreateOrders(List<OrderItemViewModel> orderItems)
        {
            var newOrder = new OrderViewModel()
            {
                OrderId = Guid.NewGuid().ToString(),
                CreatedDate = DateTime.UtcNow,
                //Todo: Needs The Identity.User
                AppUserId = "16DC732D-F6D0-4D1B-B166-3E0451E93DCA",
                Status = "InProcess"
            };
            if (orderItems.Count() >= 1)
            {
                foreach (var item in orderItems)
                {
                    var orderItem = _mapper.Map<OrderItemViewModel>(item);
                    orderItem.OrderId = newOrder.OrderId;
                    orderItem.CreatedDate = DateTime.UtcNow;
                    orderItem.Order = newOrder;



                    //var orderItem = new OrderItemViewModel() 
                    //{
                    //    CreatedDate = DateTime.UtcNow,
                    //    OrderId = newOrder.OrderId,
                    //    ProductName = item.ProductName,
                    //    Quantity = item.Quantity,
                    //    TotalQuantityPrice = item.TotalQuantityPrice,
                    //    Order = newOrder
                    //};
                    var orderProduct = new OrderProductViewModel()
                    {
                        OrderId = newOrder.OrderId,
                        ProductId = item.ProductId,
                    };
                    newOrder.TotalPrice += orderItem.TotalQuantityPrice;
                    newOrder.OrderItems.Add(orderItem);
                    newOrder.OrderProducts.Add(orderProduct);
                }
            }
            return newOrder;
        }
    }
}