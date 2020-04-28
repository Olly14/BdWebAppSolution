using System;

namespace Bd.Web.App.Models
{
    public class OrderItemViewModel
    {
        public string OrderItemId { get; set; }

        public string OrderId { get; set; }

        public string ProductId { get; set; }

        public string ProductName { get; set; }

        public string Description { get; set; }

        public DateTime CreatedDate { get; set; }

        public double UnitPrice { get; set; }

        public int Quantity { get; set; }

        public OrderViewModel Order { get; set; }

        public ProductViewModel Product { get; set; }

        public double TotalQuantityPrice { get; set; }

        public string ProductType { get; internal set; }

        public string ProductDescription { get; internal set; }

        public string UriKey { get; internal set; }
    }
}