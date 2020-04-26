using Bd.Web.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bd.Web.App.Utilities
{
    public interface IOrderItemBasket
    {
        List<OrderItemViewModel> OrderItems { get; set; }

        int TotalOrderItemsOrdered { get; set; }

        void Clear();
    }
}
