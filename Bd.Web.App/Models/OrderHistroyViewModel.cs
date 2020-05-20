using Bd.Web.App.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bd.Web.App.Models
{
    public class OrderHistoryViewModel
    {
        public string OrderHistoryId { get; set; }

        public string ProductIdDetail { get; set; }

        public string AppUserId { get; set; }

        public AppUserDto AppUser { get; set; }

        public virtual List<OrderItemHistoryViewModel> OrderItems { get; set; }
    }
}
