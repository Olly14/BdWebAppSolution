using System;
using System.Collections.Generic;
using System.Text;

namespace Bd.Web.App.DtoModels
{
    public class OrderDto
    {
        public string OrderId { get; set; }

        public string AppUserId { get; set; }

        public DateTime CreatedDate { get; set; }

        public string Status { get; set; }

        public double TotalPrice { get; set; }

        public virtual List<OrderItemDto> OrderItems { get; set; }
        public AppUserDto AppUser { get; set; }
    }
}
