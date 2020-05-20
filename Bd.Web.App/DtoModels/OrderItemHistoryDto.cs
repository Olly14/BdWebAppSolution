﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bd.Web.App.DtoModels
{
    public class OrderItemHistoryDto
    {

        public string OrderItemHistoryId { get; set; }

        public string ProductName { get; set; }

        public string Description { get; set; }

        public string ProductType { get; set; }

        public DateTime CreatedDate { get; set; }

        public double UnitPrice { get; set; }

        public int Quantity { get; set; }

        public double TotalQuantityPrice { get; set; }

    }
}
