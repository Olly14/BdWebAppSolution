using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bd.Web.App.Models
{
    public class OrderProductViewModel
    {
        public string OrderId { get; set; }

        public OrderViewModel Order { get; set; }

        public string ProductId { get; set; }

        public ProductViewModel Product { get; set; }
    }
}
