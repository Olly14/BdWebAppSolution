using System;

namespace Bd.Web.App.Models
{
    public class OrderItemModel
    {
        public string OrderItemId { get; set; }

        public string OrderId { get; set; }

        public string ProductId { get; set; }

        public DateTime CreatedDate { get; set; }

        public double UnitPrice { get; set; }

        public int Quantity { get; set; }

        public OrderModel Order { get; set; }

        public ProductModel Product { get; set; }

    }
}