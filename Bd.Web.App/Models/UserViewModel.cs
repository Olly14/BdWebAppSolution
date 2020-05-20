

namespace Bd.Web.App.Models
{
    public class UserViewModel
    {
        public string SubjectId { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string UriKey { get; set; }

        public bool IsActive { get; set; }

        public bool IsBlocked { get; set; }

        //public ICollection<UserClaim> Claims { get; set; }
        //public ICollection<UserLogin> Logins { get; set; }
        public string Email { get; set; }

        public AppUserViewModel AppUser { get; set; }
    }
}
