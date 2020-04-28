using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bd.Web.App.Models
{
    public class PricesViewModel
    {
        public string PricesId { get; set; }

        public string Type { get; set; }

        public double Price { get; set; }

        public string UriKey { get; set; }
    }
}
