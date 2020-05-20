using Bd.Web.App.DtoModels;
using Bd.Web.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bd.Web.App.Helpers
{
    public interface IItemsHistoryComparer
    {
        Task<List<OrderItemViewModel>> GetOrderHistoryToRecordAsync(
            AppUserDto appUserDto, List<OrderItemViewModel> currentOrderItems);
    }
}
