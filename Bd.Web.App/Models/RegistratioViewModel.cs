using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bd.Web.App.Models
{
    public class RegistratioViewModel
    {
        public string SubjectId { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        [Display(Name="Confirmed Password")]
        public string ConfirmedPassword { get; set; }

        public bool IsActive { get; set; }

        public bool IsBlocked { get; set; }


    }
}
