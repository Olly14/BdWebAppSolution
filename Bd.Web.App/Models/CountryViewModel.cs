using System;
using System.Collections.Generic;

namespace Bd.Web.App.Models
{
    public class CountryViewModel
    {
        public string CountryId { get; set; }

        public string UriKey { get; set; }
        public string CountryName { get; set; }
        public string CountryCode { get; set; }

        //Navigation property
        public IEnumerable<AppUserViewModel> AppUsers { get; set; }
    }
}
