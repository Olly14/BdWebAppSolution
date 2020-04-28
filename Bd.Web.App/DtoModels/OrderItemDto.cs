using System;
using System.Collections.Generic;
using System.Text;

namespace Bd.Web.App.DtoModels
{
    public class OrderItemDto
    {
        public string OrderItemId { get; set; }

        public string OrderId { get; set; }

        public string ProductId { get; set; }

        public string ProductName { get; set; }

        public string Description { get; set; }

        public DateTime CreatedDate { get; set; }

        public double UnitPrice { get; set; }

        public int Quantity { get; set; }

        public double TotalQuantityPrice { get; set; }

        public OrderDto Order { get; set; }

        public ProductDto Product { get; set; }
    }
}
