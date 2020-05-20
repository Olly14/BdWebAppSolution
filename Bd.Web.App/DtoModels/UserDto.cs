using Bd.Web.App.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bd.Web.App.DtoModels
{
    public class UserDto
    {
        public string SubjectId { get; set; }
        public string Username { get; set; }

        public string Password { get; set; }


        public bool IsActive { get; set; }

        public bool IsBlocked { get; set; }

        //public ICollection<UserClaim> Claims { get; set; }
        //public ICollection<UserLogin> Logins { get; set; }
        public string Email { get; set; }

        public AppUserDto AppUser { get; set; }
    }
}
