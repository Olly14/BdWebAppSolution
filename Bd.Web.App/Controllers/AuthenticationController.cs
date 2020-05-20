using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Bd.Web.App.Controllers
{
    public class AuthenticationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        //[HttpGet]
        public async Task Logout()
        {
            await HttpContext.SignOutAsync();
            await HttpContext.SignOutAsync("oidc");
        }


        //[HttpPost]
        //public IActionResult Logout()
        //{
        //    return SignOut("Cookies", "oidc");
        //}


        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}