using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bd.Web.App.Controllers
{
    public class BdAppBaseController : Controller
    {
        private IHttpContextAccessor _httpContextAccessor;

        public BdAppBaseController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public ClaimsPrincipal CurrentUser
        {
            get
            {
                return _httpContextAccessor.HttpContext.User;
            }
        }
    }
}