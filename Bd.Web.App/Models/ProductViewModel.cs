using System;
using System.Collections.Generic;
using System.Text;

namespace Bd.Web.App.Models
{
    public class ProductViewModel
    {

        public ProductViewModel()
        {
            Prices = new List<PricesViewModel>();
            OrderItems = new List<OrderItemViewModel>();
        }

        public string ProductId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsBlocked { get; set; }

        public string Type { get; set; }

        public string XXSmallType { get; set; }

        public string XSmallType { get; set; }

        public string SmallType { get; set; }

        public string XXMediumType { get; set; }

        public string XMediumType { get; set; }

        public string MediumType { get; set; }

        public string XXLargeType { get; set; }

        public string XLargeType { get; set; }

        public string LargeType { get; set; }

        public string XXXType { get; set; }
        public string UriKey { get; set; }
        public List<PricesViewModel> Prices { get; set; }
        public virtual List<OrderItemViewModel> OrderItems { get; set; }

    }
}
