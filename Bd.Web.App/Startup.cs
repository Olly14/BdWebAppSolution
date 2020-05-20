
using AutoMapper;
using Bd.Web.App.HttpHandlers;
using Bd.Web.App.ModelMappers.AppUser;
using Bd.Web.App.ModelMappers.Order;
using Bd.Web.App.ModelMappers.Products;
using Bd.Web.App.Utilities;
using Bd.Web.App.WebApiClient;
using Bd.Web.App.WebApiClients;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Bd.Web.App
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = Microsoft.AspNetCore.Http.SameSiteMode.None;
            });
            

            services.AddMvc(options => { options.EnableEndpointRouting = false; }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            //var mappingConfig = new MapperConfiguration(mc =>
            //{
            //    mc.AddProfile(new ProductsViewModelAutoMapperProfiles());
            //    mc.AddProfile(new AppUserViewModelAutoMapperProfiles());
            //    mc.AddProfile(new OrderViewModelAutoMapperProfiles());
            //    //mc.AddProfile(new DropDownListsDtoAutoMapperProfile());

            //});

            //IMapper mapper = mappingConfig.CreateMapper();
            //services.AddSingleton(mapper);

            services.AddHttpContextAccessor();

            services.AddTransient<BearerTokenHandler>();

            services.AddHttpClient("ApiClient", client =>
            {
                client.BaseAddress = new Uri("https://localhost:44301/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");

            }).AddHttpMessageHandler<BearerTokenHandler>();

            services.AddHttpClient("IdpClient", client =>
            {
                client.BaseAddress = new Uri("https://localhost:44314/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");

            });

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = "BdWebAppCookies";
                options.DefaultChallengeScheme = "oidc";
            })
         .AddCookie("BdWebAppCookies", options =>
         {
             options.AccessDeniedPath = "/Authentication/AccessDenied";
         })
         .AddOpenIdConnect("oidc", options =>
         {
             options.Authority = "https://localhost:44314/";
             options.RequireHttpsMetadata = true;
             options.ClientId = "BdWebAppClientId";
             options.Scope.Add("openid");
             options.Scope.Add("profile");
             options.Scope.Add("address");
             options.Scope.Add("roles");
             options.Scope.Add("Bd.Web.Api");
             //TODO: why add offline access
             options.Scope.Add("offline_access");
             options.ClientSecret = "secret";
             options.ResponseType = "code id_token";
             options.SignInScheme = "BdWebAppCookies";
             options.SignOutScheme = "oidc";
             options.ClaimActions.DeleteClaim("idp");
             options.ClaimActions.DeleteClaim("s_hash");
             options.ClaimActions.DeleteClaim("auth_time");
             options.ClaimActions.MapUniqueJsonKey("role", "role");
             //options.SignOutScheme = "LimdoWebAppCookies";
             options.SaveTokens = true;
             options.GetClaimsFromUserInfoEndpoint = true;
                         //options.CallbackPath = new PathString(".....");
                         options.SignedOutCallbackPath = new PathString();
             options.Events = new OpenIdConnectEvents()
             {
                 OnTokenValidated = TokenValidatedContext =>
                 {
                     var identity = TokenValidatedContext.Principal.Identity as ClaimsIdentity;

                     var subjectClaims = identity.Claims.FirstOrDefault(c => string.Compare(c.Type, "sub", true) == 0);


                     var newClaimsIdentity = new ClaimsIdentity("AuthenticationScheme",
                         "given_name",
                         "role");

                     newClaimsIdentity.AddClaim(subjectClaims);


                     var ticket = new AuthenticationTicket(
                         new ClaimsPrincipal(newClaimsIdentity),
                         TokenValidatedContext.Properties,
                         authenticationScheme: "BdWebAppCookies");
                     return Task.FromResult(0);
                 },

                 OnUserInformationReceived = userInformationReceivedContext =>
                 {
                                 //userInformationReceivedContext.User.Remove("address");
                                 return Task.FromResult(0);
                 }
             };
         });
                    services.AddAuthorization(authorizationOptions =>
                    {
                        authorizationOptions.AddPolicy("Admin", options =>
                        {
                            options.RequireAuthenticatedUser();
                            options.RequireClaim("country", "uk");
                            options.RequireClaim("region", "all");
                            options.RequireClaim("branch", "all");
                            options.RequireClaim("ownerGroup", "employee");
                            options.RequireClaim("ownerGroupLevel", "admin");
                        });
                        authorizationOptions.AddPolicy("Customer", options =>
                        {
                            options.RequireAuthenticatedUser();
                            options.RequireClaim("country", "uk");
                            options.RequireClaim("region", "kent");
                            options.RequireClaim("branch", "maidstone");
                            options.RequireClaim("ownerGroup", "customer");
                            options.RequireClaim("ownerGroupLevel", "saving", "current");
                        });
                    });





            services.AddScoped<IApiClient, ApiClient>();
            services.AddSingleton<IOrderItemBasket, OrderItemBasket>();



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
