#pragma checksum "C:\Users\Admin\source\repos\CreditCardsPreQualificationPortal\CreditCardsPreQualificationTool\Views\CheckEligibility\Under18.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c04a6d1c268c8e16326d1f6677e32ce8510864ea"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_CheckEligibility_Under18), @"mvc.1.0.view", @"/Views/CheckEligibility/Under18.cshtml")]
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
#nullable restore
#line 1 "C:\Users\Admin\source\repos\CreditCardsPreQualificationPortal\CreditCardsPreQualificationTool\Views\_ViewImports.cshtml"
using CreditCardsPreQualificationWeb;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Admin\source\repos\CreditCardsPreQualificationPortal\CreditCardsPreQualificationTool\Views\_ViewImports.cshtml"
using CreditCardsPreQualificationWeb.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c04a6d1c268c8e16326d1f6677e32ce8510864ea", @"/Views/CheckEligibility/Under18.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eb81c14c1dc6bacc3de6ed5635fc6598b745d1c6", @"/Views/_ViewImports.cshtml")]
    public class Views_CheckEligibility_Under18 : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CreditCardsPreQualificationWeb.Models.PersonalInfoViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Admin\source\repos\CreditCardsPreQualificationPortal\CreditCardsPreQualificationTool\Views\CheckEligibility\Under18.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"container\">\r\n    <div class=\"row\">\r\n        <div class=\"col-md-10\">\r\n            <h3 class=\"control-label col-md-10\">Sorry! ");
#nullable restore
#line 10 "C:\Users\Admin\source\repos\CreditCardsPreQualificationPortal\CreditCardsPreQualificationTool\Views\CheckEligibility\Under18.cshtml"
                                                  Write(Model.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 10 "C:\Users\Admin\source\repos\CreditCardsPreQualificationPortal\CreditCardsPreQualificationTool\Views\CheckEligibility\Under18.cshtml"
                                                                   Write(Model.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" You are Under 18</h3>\r\n            <br/>\r\n            <h3 class=\"control-label col-md-10\">No credit cards are available</h3>           \r\n\r\n        </div>\r\n\r\n    </div>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CreditCardsPreQualificationWeb.Models.PersonalInfoViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
