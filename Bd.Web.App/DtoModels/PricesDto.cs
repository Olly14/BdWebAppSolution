using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bd.Web.App.DtoModels
{
    public class PricesDto
    {
        public string PricesId { get; set; }

        public string ProductId { get; set; }

        public string Type { get; set; }

        public string Price { get; set; }
    }
}
