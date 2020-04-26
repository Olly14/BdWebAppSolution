using Bd.Web.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bd.Web.App.Utilities
{
    public class OrderItemBasket : IOrderItemBasket
    {
        private List<OrderItemViewModel> _orderItems;


        public OrderItemBasket()
        {
            _orderItems = new List<OrderItemViewModel>();
            OrderItems = _orderItems;
        }

        public List<OrderItemViewModel> OrderItems { get ; set; }


        public int TotalOrderItemsOrdered 
        {
            get { return OrderItems.Count; } set { TotalOrderItemsOrdered = value; }
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }
    }
}
