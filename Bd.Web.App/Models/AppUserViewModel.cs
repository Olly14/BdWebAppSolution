using Bd.Web.App.DtoModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bd.Web.App.Models
{
    

    public class AppUserViewModel
    {

        public AppUserViewModel()
        {
            Orders = new List<OrderViewModel>();
            OrderHistories = new List<OrderHistoryViewModel>();
        }


        public string AppUserId { get; set; }

        public string UriKey { get; set; }
        public string SubjectId { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public string UserName { get; set; }

        public string MobileNumber { get; set; }

        public string FirstLineOfAddress { get; set; }

        public string SecondLineOfAddress { get; set; }

        public string Town { get; set; }

        public string PostCode { get; set; }


        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsBlocked { get; set; }


        public DateTime CreatedDate { get; set; }

        [Display(Name = "Modified Date")]
        public DateTime ModifiedDate { get; set; }

        [Display(Name = "ModifierAppUserId")]
        public string ModifierAppUserId { get; set; }


        public CountryDto Country { get; set; }
        [Display(Name = "Origin")]
        public string CountryId { get; set; }
        public string CountryIdValue { get; set; }

        [Display(Name = "Gender")]
        public string GenderId { get; set; }
        public string GenderIdValue { get; set; }

        public virtual GenderDto Gender { get; set; }
        public virtual UserViewModel User { get; set; }

        public virtual List<OrderViewModel> Orders { get; set; }

        public virtual List<OrderHistoryViewModel> OrderHistories { get; set; }

        public virtual ICollection<string> Roles { get; set; }
        public virtual ICollection<string> Claims { get; set; }

        public int OrderHistoryCount { get; set; }

        public string UiControl { get; set; }

        public string DisplayName { get; set; }


    }
}
