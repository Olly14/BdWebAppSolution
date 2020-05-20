using Bd.Web.App.DtoModels;
using Bd.Web.App.HttpService;
using Bd.Web.App.Models;
using Bd.Web.App.WebApiClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bd.Web.App.Helpers
{
    public class ItemsHistoryComparer : IItemsHistoryComparer
    {
        private readonly string OrderItemsHistoryByOrderHistoryId_Url = 
            "OrderItemHistories/OrderItemHistories";
        private readonly string OrderHistoryByAppUserId_Url =
           "OrderHistories/GetOrderHistoriesByAppUserId";


        private List<OrderHistoryDto> _appUserOrderHistories;
        private List<OrderItemHistoryDto> _orderItemHistoryDtos;
        private List<OrderItemViewModel> _currentOrderItemToRecord;
        private string _appUserId;

        private readonly IApiClient _apiClient;
       

        public ItemsHistoryComparer(IApiClient apiClient)
        {
            _apiClient = apiClient;
            _orderItemHistoryDtos = new List<OrderItemHistoryDto>();
            _currentOrderItemToRecord = new List<OrderItemViewModel>();
            _appUserOrderHistories = new List<OrderHistoryDto>();
            _appUserId = string.Empty;
        }


        public async Task<List<OrderItemViewModel>>  GetOrderHistoryToRecordAsync(AppUserDto appUserDto, List<OrderItemViewModel> currentOrderItems)
        {
            _appUserId = appUserDto.AppUserId;
            var orderPath = string.Format("{0}{1}/{2}",HttpClientProvider.HttpClient.BaseAddress,
                OrderHistoryByAppUserId_Url, _appUserId);
            _appUserOrderHistories = (await _apiClient.ListAsync<OrderHistoryDto>(orderPath)).ToList();
            _appUserOrderHistories = await PopulateOrderHistoryOrderItemsAsync(_appUserOrderHistories);

            foreach (var item in _appUserOrderHistories)
            {
                _orderItemHistoryDtos = item.OrderItems;
                if (CompareCurrentToHistory(currentOrderItems, _orderItemHistoryDtos))
                {
                    _currentOrderItemToRecord = currentOrderItems;
                }
            }
            return _currentOrderItemToRecord;

        }

        private bool CompareCurrentToHistory(List<OrderItemViewModel> currentOrderItems, List<OrderItemHistoryDto> orderItemHistoryDtos)
        {
            var result = false;
            var currentItemsSize = currentOrderItems.Count;
            var orderItemHistoryDtosSize = orderItemHistoryDtos.Count;
            if (currentItemsSize != orderItemHistoryDtosSize)
            {
                return result;
            }
            Task.Run(() => 
            {
                for (int i = 0; i < currentItemsSize; i++)
                {
                    foreach (var item in orderItemHistoryDtos)
                    {
                        if (CompareTwoItems(currentOrderItems[i], item))
                        {
                            result = true;
                        }
                        else
                        {
                            result = false;
                            return result;
                        }
                    }
                }
                return result;
            });

            return result;
        }

        private bool CompareTwoItems(OrderItemViewModel currentItem, OrderItemHistoryDto oldItem)
        {
            var result = currentItem.ProductName.Equals(oldItem.ProductName) &&
                         currentItem.UnitPrice.Equals(oldItem.UnitPrice) &&
                          currentItem.TotalQuantityPrice.Equals(oldItem.TotalQuantityPrice);
            return result;
        }


        private async Task<List<OrderHistoryDto>> PopulateOrderHistoryOrderItemsAsync(List<OrderHistoryDto> orderHistoryDtos)
        {
            var size = orderHistoryDtos.Count;

            for (int i = 0; i < size; i++)
            {
                var orderHist = orderHistoryDtos[i];
                orderHist =
                    await PopulateOrderItemsAsync(orderHist);
            }

            return orderHistoryDtos;
        }

        private async  Task<OrderHistoryDto> PopulateOrderItemsAsync(OrderHistoryDto orderHistoryDto)
        {
            var orderItemsPath = string.Format("{0}{1}/{2}", HttpClientProvider.HttpClient.BaseAddress,
                OrderItemsHistoryByOrderHistoryId_Url, _appUserId);
            if (orderHistoryDto.OrderItems.Count == 0)
            {
                orderHistoryDto.OrderItems = (await _apiClient.ListAsync<OrderItemHistoryDto>(orderItemsPath)).ToList();
            }
            return orderHistoryDto;
        }



    }
}
