using System;
using System.Collections.Generic;

namespace Bd.Web.App.Models
{
    public class OrderViewModel
    {

        public OrderViewModel()
        {
            OrderItems = new List<OrderItemViewModel>();
            OrderProducts = new List<OrderProductViewModel>();
        }
        public string OrderId { get; set; }

        public string AppUserId { get; set; }

        public DateTime CreatedDate { get; set; }

        public string Status { get; set; }

        public double TotalPrice { get; set; }

        public virtual List<OrderItemViewModel> OrderItems { get; set; }

        public virtual List<OrderProductViewModel> OrderProducts { get; set; }
        public AppUserModel AppUser { get; set; }



        public string UriKey { get; set; }

        public string UiControl { get; set; }

    }
}