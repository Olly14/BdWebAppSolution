#pragma checksum "C:\Users\Olayinka.Ayoola\source\repos\BdWebAppSolution\Bd.Web.App\Views\OrderItems\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "25f99ce9d0d55ef52581ae7ea9ee6d1b4892cc7d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_OrderItems_Details), @"mvc.1.0.view", @"/Views/OrderItems/Details.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"25f99ce9d0d55ef52581ae7ea9ee6d1b4892cc7d", @"/Views/OrderItems/Details.cshtml")]
    public class Views_OrderItems_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Bd.Web.App.Models.OrderItemViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 5 "C:\Users\Olayinka.Ayoola\source\repos\BdWebAppSolution\Bd.Web.App\Views\OrderItems\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>Details</h2>\r\n\r\n<div>\r\n    <h4>OrderItemViewModel</h4>\r\n    <hr />\r\n    <dl class=\"dl-horizontal\">\r\n        <dt>\r\n            ");
#nullable restore
#line 16 "C:\Users\Olayinka.Ayoola\source\repos\BdWebAppSolution\Bd.Web.App\Views\OrderItems\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.OrderItemId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
#nullable restore
#line 19 "C:\Users\Olayinka.Ayoola\source\repos\BdWebAppSolution\Bd.Web.App\Views\OrderItems\Details.cshtml"
       Write(Html.DisplayFor(model => model.OrderItemId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
#nullable restore
#line 22 "C:\Users\Olayinka.Ayoola\source\repos\BdWebAppSolution\Bd.Web.App\Views\OrderItems\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.OrderId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
#nullable restore
#line 25 "C:\Users\Olayinka.Ayoola\source\repos\BdWebAppSolution\Bd.Web.App\Views\OrderItems\Details.cshtml"
       Write(Html.DisplayFor(model => model.OrderId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
#nullable restore
#line 28 "C:\Users\Olayinka.Ayoola\source\repos\BdWebAppSolution\Bd.Web.App\Views\OrderItems\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.ProductId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
#nullable restore
#line 31 "C:\Users\Olayinka.Ayoola\source\repos\BdWebAppSolution\Bd.Web.App\Views\OrderItems\Details.cshtml"
       Write(Html.DisplayFor(model => model.ProductId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
#nullable restore
#line 34 "C:\Users\Olayinka.Ayoola\source\repos\BdWebAppSolution\Bd.Web.App\Views\OrderItems\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Owner));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
#nullable restore
#line 37 "C:\Users\Olayinka.Ayoola\source\repos\BdWebAppSolution\Bd.Web.App\Views\OrderItems\Details.cshtml"
       Write(Html.DisplayFor(model => model.Owner));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
#nullable restore
#line 40 "C:\Users\Olayinka.Ayoola\source\repos\BdWebAppSolution\Bd.Web.App\Views\OrderItems\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.ProductName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
#nullable restore
#line 43 "C:\Users\Olayinka.Ayoola\source\repos\BdWebAppSolution\Bd.Web.App\Views\OrderItems\Details.cshtml"
       Write(Html.DisplayFor(model => model.ProductName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
#nullable restore
#line 46 "C:\Users\Olayinka.Ayoola\source\repos\BdWebAppSolution\Bd.Web.App\Views\OrderItems\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
#nullable restore
#line 49 "C:\Users\Olayinka.Ayoola\source\repos\BdWebAppSolution\Bd.Web.App\Views\OrderItems\Details.cshtml"
       Write(Html.DisplayFor(model => model.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
#nullable restore
#line 52 "C:\Users\Olayinka.Ayoola\source\repos\BdWebAppSolution\Bd.Web.App\Views\OrderItems\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.CreatedDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
#nullable restore
#line 55 "C:\Users\Olayinka.Ayoola\source\repos\BdWebAppSolution\Bd.Web.App\Views\OrderItems\Details.cshtml"
       Write(Html.DisplayFor(model => model.CreatedDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
#nullable restore
#line 58 "C:\Users\Olayinka.Ayoola\source\repos\BdWebAppSolution\Bd.Web.App\Views\OrderItems\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.UnitPrice));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
#nullable restore
#line 61 "C:\Users\Olayinka.Ayoola\source\repos\BdWebAppSolution\Bd.Web.App\Views\OrderItems\Details.cshtml"
       Write(Html.DisplayFor(model => model.UnitPrice));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
#nullable restore
#line 64 "C:\Users\Olayinka.Ayoola\source\repos\BdWebAppSolution\Bd.Web.App\Views\OrderItems\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Quantity));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
#nullable restore
#line 67 "C:\Users\Olayinka.Ayoola\source\repos\BdWebAppSolution\Bd.Web.App\Views\OrderItems\Details.cshtml"
       Write(Html.DisplayFor(model => model.Quantity));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
#nullable restore
#line 70 "C:\Users\Olayinka.Ayoola\source\repos\BdWebAppSolution\Bd.Web.App\Views\OrderItems\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.TotalQuantityPrice));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
#nullable restore
#line 73 "C:\Users\Olayinka.Ayoola\source\repos\BdWebAppSolution\Bd.Web.App\Views\OrderItems\Details.cshtml"
       Write(Html.DisplayFor(model => model.TotalQuantityPrice));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
#nullable restore
#line 76 "C:\Users\Olayinka.Ayoola\source\repos\BdWebAppSolution\Bd.Web.App\Views\OrderItems\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.ProductType));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
#nullable restore
#line 79 "C:\Users\Olayinka.Ayoola\source\repos\BdWebAppSolution\Bd.Web.App\Views\OrderItems\Details.cshtml"
       Write(Html.DisplayFor(model => model.ProductType));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
#nullable restore
#line 82 "C:\Users\Olayinka.Ayoola\source\repos\BdWebAppSolution\Bd.Web.App\Views\OrderItems\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.ProductDescription));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
#nullable restore
#line 85 "C:\Users\Olayinka.Ayoola\source\repos\BdWebAppSolution\Bd.Web.App\Views\OrderItems\Details.cshtml"
       Write(Html.DisplayFor(model => model.ProductDescription));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "25f99ce9d0d55ef52581ae7ea9ee6d1b4892cc7d11377", async() => {
                WriteLiteral("Back to List");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Bd.Web.App.Models.OrderItemViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
