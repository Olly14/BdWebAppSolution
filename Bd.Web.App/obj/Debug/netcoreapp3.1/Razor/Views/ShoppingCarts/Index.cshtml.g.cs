#pragma checksum "C:\Users\Olayinka.Ayoola\source\repos\BdWebAppSolution\Bd.Web.App\Views\ShoppingCarts\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e1c41ce226b39beca53d2840ce16a8dc8de92b55"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ShoppingCarts_Index), @"mvc.1.0.view", @"/Views/ShoppingCarts/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e1c41ce226b39beca53d2840ce16a8dc8de92b55", @"/Views/ShoppingCarts/Index.cshtml")]
    public class Views_ShoppingCarts_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Bd.Web.App.Models.ProductViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AddItem", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 5 "C:\Users\Olayinka.Ayoola\source\repos\BdWebAppSolution\Bd.Web.App\Views\ShoppingCarts\Index.cshtml"
  
    Layout = "_Layout";
    ViewData["Title"] = "Shopping Cart";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>Shooping Cart</h2>\r\n\r\n<div class=\"container\">\r\n    <div class=\"row py-5\">\r\n        <div class=\"col-md-3 col-sm-6 my-3 my-md-0\">\r\n");
#nullable restore
#line 15 "C:\Users\Olayinka.Ayoola\source\repos\BdWebAppSolution\Bd.Web.App\Views\ShoppingCarts\Index.cshtml"
              
                foreach (var item in Model)
                {
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "C:\Users\Olayinka.Ayoola\source\repos\BdWebAppSolution\Bd.Web.App\Views\ShoppingCarts\Index.cshtml"
               Write(Html.Hidden("UriKey"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 19 "C:\Users\Olayinka.Ayoola\source\repos\BdWebAppSolution\Bd.Web.App\Views\ShoppingCarts\Index.cshtml"
               Write(Html.Hidden("Type"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 20 "C:\Users\Olayinka.Ayoola\source\repos\BdWebAppSolution\Bd.Web.App\Views\ShoppingCarts\Index.cshtml"
               Write(Html.Hidden("Name"));

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"glyphicon-credit-card\">\r\n                        <div>\r\n                            <img src=\"/\"");
            BeginWriteAttribute("alt", " alt=\"", 659, "\"", 681, 2);
            WriteAttributeValue("", 665, "Image", 665, 5, true);
#nullable restore
#line 23 "C:\Users\Olayinka.Ayoola\source\repos\BdWebAppSolution\Bd.Web.App\Views\ShoppingCarts\Index.cshtml"
WriteAttributeValue(" ", 670, item.Type, 671, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" class=""img-fluid glyphicon-credit-card"" />
                        </div>
                    </div>
                    <div class=""glyphicon-credit-card"">
                        <h5>
                            <small class=""price text-secondary"">");
#nullable restore
#line 28 "C:\Users\Olayinka.Ayoola\source\repos\BdWebAppSolution\Bd.Web.App\Views\ShoppingCarts\Index.cshtml"
                                                           Write(item.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</small>\r\n                            <span class=\"price text-secondary\">£ ");
#nullable restore
#line 29 "C:\Users\Olayinka.Ayoola\source\repos\BdWebAppSolution\Bd.Web.App\Views\ShoppingCarts\Index.cshtml"
                                                            Write(item.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                        </h5>\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e1c41ce226b39beca53d2840ce16a8dc8de92b556279", async() => {
                WriteLiteral(" Add Item To Basket");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 31 "C:\Users\Olayinka.Ayoola\source\repos\BdWebAppSolution\Bd.Web.App\Views\ShoppingCarts\Index.cshtml"
                                                  WriteLiteral(item.UriKey);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute(",", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 31 "C:\Users\Olayinka.Ayoola\source\repos\BdWebAppSolution\Bd.Web.App\Views\ShoppingCarts\Index.cshtml"
                                                                                  WriteLiteral(item.Type);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["type"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-type", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["type"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </div>\r\n");
#nullable restore
#line 33 "C:\Users\Olayinka.Ayoola\source\repos\BdWebAppSolution\Bd.Web.App\Views\ShoppingCarts\Index.cshtml"
                }
            

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n\r\n    </div>\r\n</div>\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Bd.Web.App.Models.ProductViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591