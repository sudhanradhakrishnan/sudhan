#pragma checksum "C:\Users\Admin\source\repos\CreditCardsPreQualificationTool\CreditCardsPreQualificationTool\Views\CheckEligibility\CheckEligibility.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d4a8da4f6715c081849a40c2fb7066eec7aecd02"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_CheckEligibility_CheckEligibility), @"mvc.1.0.view", @"/Views/CheckEligibility/CheckEligibility.cshtml")]
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
#line 1 "C:\Users\Admin\source\repos\CreditCardsPreQualificationTool\CreditCardsPreQualificationTool\Views\_ViewImports.cshtml"
using CreditCardsPreQualificationWeb;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Admin\source\repos\CreditCardsPreQualificationTool\CreditCardsPreQualificationTool\Views\_ViewImports.cshtml"
using CreditCardsPreQualificationWeb.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d4a8da4f6715c081849a40c2fb7066eec7aecd02", @"/Views/CheckEligibility/CheckEligibility.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eb81c14c1dc6bacc3de6ed5635fc6598b745d1c6", @"/Views/_ViewImports.cshtml")]
    public class Views_CheckEligibility_CheckEligibility : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<CreditCardsPreQualificationWeb.Models.ApplicantDetailsViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Admin\source\repos\CreditCardsPreQualificationTool\CreditCardsPreQualificationTool\Views\CheckEligibility\CheckEligibility.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
    <div class=""container"">
        <div class=""row"">
            <div>
                <h3 class=""control-label col-md-10"">Reporting Tool</h3>
                <p class=""control-label col-md-10"">This page will show who has used the tool, and what results they were shown.</p>

            </div>
");
#nullable restore
#line 14 "C:\Users\Admin\source\repos\CreditCardsPreQualificationTool\CreditCardsPreQualificationTool\Views\CheckEligibility\CheckEligibility.cshtml"
             if (!Model.Any())
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <h3 class=\"control-label col-md-10\">No recourds found</h3>\r\n");
#nullable restore
#line 17 "C:\Users\Admin\source\repos\CreditCardsPreQualificationTool\CreditCardsPreQualificationTool\Views\CheckEligibility\CheckEligibility.cshtml"
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        <div class=""col-md-offset-2 col-md-10"">
                            <table id=""t01"">
                                <thead>
                                <th>Full Name</th>
                                <th>Age</th>
                                <th>Annual Income</th>
                                <th>Bank Details</th>
                                <th>Attempt Date</th>
                                </thead>
");
#nullable restore
#line 29 "C:\Users\Admin\source\repos\CreditCardsPreQualificationTool\CreditCardsPreQualificationTool\Views\CheckEligibility\CheckEligibility.cshtml"
                                 foreach (var item in Model)
                                {


#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <tr>\r\n                                        <td>\r\n                                            ");
#nullable restore
#line 34 "C:\Users\Admin\source\repos\CreditCardsPreQualificationTool\CreditCardsPreQualificationTool\Views\CheckEligibility\CheckEligibility.cshtml"
                                       Write(item.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </td>\r\n                                        <td>\r\n                                            ");
#nullable restore
#line 37 "C:\Users\Admin\source\repos\CreditCardsPreQualificationTool\CreditCardsPreQualificationTool\Views\CheckEligibility\CheckEligibility.cshtml"
                                       Write(item.Age);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </td>\r\n                                        <td>\r\n                                            ");
#nullable restore
#line 40 "C:\Users\Admin\source\repos\CreditCardsPreQualificationTool\CreditCardsPreQualificationTool\Views\CheckEligibility\CheckEligibility.cshtml"
                                       Write(item.AnnualIncome);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </td>\r\n                                        <td>\r\n                                                        ");
#nullable restore
#line 43 "C:\Users\Admin\source\repos\CreditCardsPreQualificationTool\CreditCardsPreQualificationTool\Views\CheckEligibility\CheckEligibility.cshtml"
                                                   Write(item.BankDetails);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                    </td>\r\n                                                    <td>\r\n                                                        ");
#nullable restore
#line 46 "C:\Users\Admin\source\repos\CreditCardsPreQualificationTool\CreditCardsPreQualificationTool\Views\CheckEligibility\CheckEligibility.cshtml"
                                                   Write(item.AttemptDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                    </td>\r\n                                                </tr>\r\n");
#nullable restore
#line 49 "C:\Users\Admin\source\repos\CreditCardsPreQualificationTool\CreditCardsPreQualificationTool\Views\CheckEligibility\CheckEligibility.cshtml"

                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </table>\r\n                                    </div>\r\n");
#nullable restore
#line 54 "C:\Users\Admin\source\repos\CreditCardsPreQualificationTool\CreditCardsPreQualificationTool\Views\CheckEligibility\CheckEligibility.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                </div>\r\n");
            WriteLiteral(@"                <style>
                    table#t01 {
                        width: 100%;
                        background-color: #f1f1c1;
                    }

                        table#t01 tr:nth-child(even) {
                            background-color: #eee;
                        }

                        table#t01 tr:nth-child(odd) {
                            background-color: #fff;
                        }

                        table#t01 th {
                            color: white;
                            background-color: steelBlue;
                        }

                    table, th, td {
                        border: 1px solid black;
                    }

                    table, th, td {
                        border: 1px solid black;
                        border-collapse: collapse;
                    }

                    table, th, td {
                        border: 1px solid black;
                        border-collapse: co");
            WriteLiteral("llapse;\r\n                    }\r\n\r\n                    th, td {\r\n                        padding: 15px;\r\n                    }\r\n                </style>\r\n\r\n            </div>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<CreditCardsPreQualificationWeb.Models.ApplicantDetailsViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
