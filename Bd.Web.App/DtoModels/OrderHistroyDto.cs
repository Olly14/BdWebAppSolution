using Bd.Web.App.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bd.Web.App.DtoModels
{
    public class OrderHistoryDto
    {
        public string OrderHistoryId { get; set; }

        public string ProductIdDetail { get; set; }

        public string AppUserId { get; set; }

        public AppUserDto AppUser { get; set; }

        public virtual List<OrderItemHistoryDto> OrderItems { get; set; }
    }
}
