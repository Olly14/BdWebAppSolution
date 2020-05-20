using System;
using System.Collections.Generic;
using System.Text;

namespace Bd.Web.App.Models
{
    public class GenderViewModel
    {
        public string GenderId { get; set; }
        public string Type { get; set; }

        public string UriKey { get; set; }

        //Navigation property
        public virtual IEnumerable<AppUserViewModel> AppUsers { get; set; }
    }
}
