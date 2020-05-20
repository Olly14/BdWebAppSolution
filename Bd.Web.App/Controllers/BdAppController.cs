using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace Bd.Web.App.Controllers
{
    public class BdAppController : Controller
    {
        private IHttpContextAccessor _httpContextAccessor;

        public BdAppController(IHttpContextAccessor httpContextAccessor)
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

        public async Task WriteOutIdentityInformation()
        {
            var identityTokens = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.IdToken);
            

            Debug.WriteLine($"Claim type: {identityTokens}");
            //write it out
            foreach (var claim in User.Claims)
            {
                Debug.WriteLine($"Claim type: {claim.Type} - Claim value: {claim.Value}");
            }

        }
    }
}