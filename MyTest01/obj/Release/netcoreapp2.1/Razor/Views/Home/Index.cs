#pragma checksum "D:\Projects-Hub\AzureTesting\MyTest01\MyTest01\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "91986f2b353a45c806732e44194026d870dab8e2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Index.cshtml", typeof(AspNetCore.Views_Home_Index))]
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
#line 1 "D:\Projects-Hub\AzureTesting\MyTest01\MyTest01\Views\_ViewImports.cshtml"
using ActiveBusinessEdi;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"91986f2b353a45c806732e44194026d870dab8e2", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ea18ff2606a3709e426566c4e0bd3b0a0888d0a8", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/Download.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.SingleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(120, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
#line 5 "D:\Projects-Hub\AzureTesting\MyTest01\MyTest01\Views\Home\Index.cshtml"
  
    var obj = ViewBag.GridData;
    string msg = "";
    if (ViewData["Message"] != null)
    {
        msg = ViewData["Message"].ToString();
    }

#line default
#line hidden
            BeginContext(285, 648, true);
            WriteLiteral(@"
<style>
    .table th,
    .table td {
        font-family: activesans-light !important;
        font-weight: 400;
        padding: 0.25rem;
        vertical-align: top;
        border-top: 1px solid #dee2e6;
    }

    .fontclass {
        font-family: activesans-regular !important;
    }


    .the-legend {
        border-style: none;
        border-width: 0;
        font-size: 14px;
        line-height: 20px;
        margin-bottom: 0;
        width: auto;
        padding: 0 10px;
    }

    .the-fieldset {
        border: 2px solid #dee2e6;
        padding: 5px;
        border-radius: 8px;
    }
</style>
");
            EndContext();
#line 45 "D:\Projects-Hub\AzureTesting\MyTest01\MyTest01\Views\Home\Index.cshtml"
 using (Html.BeginForm("Index", "Home", FormMethod.Post))
{
    

#line default
#line hidden
#line 47 "D:\Projects-Hub\AzureTesting\MyTest01\MyTest01\Views\Home\Index.cshtml"
     if (obj != null)
    {

#line default
#line hidden
            BeginContext(1025, 11, true);
            WriteLiteral("        <p>");
            EndContext();
            BeginContext(1037, 3, false);
#line 49 "D:\Projects-Hub\AzureTesting\MyTest01\MyTest01\Views\Home\Index.cshtml"
      Write(msg);

#line default
#line hidden
            EndContext();
            BeginContext(1040, 6, true);
            WriteLiteral("</p>\r\n");
            EndContext();
            BeginContext(1048, 425, true);
            WriteLiteral(@"        <fieldset class=""containerBox"">
            <h4 style=""color:#3d70b2;"">Kroger Data Exports</h4>


            <fieldset class=""the-fieldset"">
                <legend class=""the-legend"">Filter</legend>
                <label class=""col-md-1 control-label"" for=""radios"">File Type</label>
                <div class=""col-md-1"">
                    <label class=""radio-inline fontclass"">
                        ");
            EndContext();
            BeginContext(1474, 37, false);
#line 60 "D:\Projects-Hub\AzureTesting\MyTest01\MyTest01\Views\Home\Index.cshtml"
                   Write(Html.RadioButton("Type", "All", true));

#line default
#line hidden
            EndContext();
            BeginContext(1511, 183, true);
            WriteLiteral("All\r\n                    </label>\r\n                </div>\r\n                <div class=\"col-md-1\">\r\n                    <label class=\"radio-inline fontclass\">\r\n                        ");
            EndContext();
            BeginContext(1695, 32, false);
#line 65 "D:\Projects-Hub\AzureTesting\MyTest01\MyTest01\Views\Home\Index.cshtml"
                   Write(Html.RadioButton("Type", ".XLS"));

#line default
#line hidden
            EndContext();
            BeginContext(1727, 185, true);
            WriteLiteral(" .XLS\r\n                    </label>\r\n                </div>\r\n                <div class=\"col-md-1\">\r\n                    <label class=\"radio-inline fontclass\">\r\n                        ");
            EndContext();
            BeginContext(1913, 32, false);
#line 70 "D:\Projects-Hub\AzureTesting\MyTest01\MyTest01\Views\Home\Index.cshtml"
                   Write(Html.RadioButton("Type", ".CSV"));

#line default
#line hidden
            EndContext();
            BeginContext(1945, 185, true);
            WriteLiteral(" .CSV\r\n                    </label>\r\n                </div>\r\n                <div class=\"col-md-1\">\r\n                    <label class=\"radio-inline fontclass\">\r\n                        ");
            EndContext();
            BeginContext(2131, 32, false);
#line 75 "D:\Projects-Hub\AzureTesting\MyTest01\MyTest01\Views\Home\Index.cshtml"
                   Write(Html.RadioButton("Type", ".PDF"));

#line default
#line hidden
            EndContext();
            BeginContext(2163, 268, true);
            WriteLiteral(@" .PDF
                    </label>
                </div>
                <label class=""col-md-1 control-label"" for=""radios"">Status</label>
                <div class=""col-md-1"">
                    <label class=""radio-inline fontclass"">
                        ");
            EndContext();
            BeginContext(2432, 39, false);
#line 81 "D:\Projects-Hub\AzureTesting\MyTest01\MyTest01\Views\Home\Index.cshtml"
                   Write(Html.RadioButton("Status", "All", true));

#line default
#line hidden
            EndContext();
            BeginContext(2471, 202, true);
            WriteLiteral(" All\r\n                    </label>\r\n                </div>\r\n                <div class=\"col-md-1\" style=\"width:12%\">\r\n                    <label class=\"radio-inline fontclass\">\r\n                        ");
            EndContext();
            BeginContext(2674, 39, false);
#line 86 "D:\Projects-Hub\AzureTesting\MyTest01\MyTest01\Views\Home\Index.cshtml"
                   Write(Html.RadioButton("Status", "Published"));

#line default
#line hidden
            EndContext();
            BeginContext(2713, 208, true);
            WriteLiteral(" Published\r\n                    </label>\r\n                </div>\r\n                <div class=\"col-md-1\" style=\"width:12%\">\r\n                    <label class=\"radio-inline fontclass\">\r\n                        ");
            EndContext();
            BeginContext(2922, 40, false);
#line 91 "D:\Projects-Hub\AzureTesting\MyTest01\MyTest01\Views\Home\Index.cshtml"
                   Write(Html.RadioButton("Status", "Downloaded"));

#line default
#line hidden
            EndContext();
            BeginContext(2962, 405, true);
            WriteLiteral(@" Downloaded
                    </label>
                </div>
                <div class=""col-md-2"" style=""padding-bottom:5px;"">
                    <input type=""submit"" value=""Apply"" id=""btn-submit"" class=""btn btn-primary"" />
                    <input type=""button"" value=""Reset"" id=""btn-reset"" class=""btn btn-primary"" />
                </div>
            </fieldset>

            <br />

");
            EndContext();
            BeginContext(3682, 203, true);
            WriteLiteral("\r\n\r\n            <table class=\"table\" style=\"font-size:13px;\">\r\n                <tr style=\"background-color: #3d70b2; color:white\">\r\n                    <th class=\"header-label\">\r\n                        ");
            EndContext();
            BeginContext(3886, 18, false);
#line 109 "D:\Projects-Hub\AzureTesting\MyTest01\MyTest01\Views\Home\Index.cshtml"
                   Write(Html.Label("TRN#"));

#line default
#line hidden
            EndContext();
            BeginContext(3904, 100, true);
            WriteLiteral("\r\n                    </th>\r\n                    <th class=\"header-label\">\r\n                        ");
            EndContext();
            BeginContext(4005, 18, false);
#line 112 "D:\Projects-Hub\AzureTesting\MyTest01\MyTest01\Views\Home\Index.cshtml"
                   Write(Html.Label("Type"));

#line default
#line hidden
            EndContext();
            BeginContext(4023, 100, true);
            WriteLiteral("\r\n                    </th>\r\n                    <th class=\"header-label\">\r\n                        ");
            EndContext();
            BeginContext(4124, 20, false);
#line 115 "D:\Projects-Hub\AzureTesting\MyTest01\MyTest01\Views\Home\Index.cshtml"
                   Write(Html.Label("Status"));

#line default
#line hidden
            EndContext();
            BeginContext(4144, 100, true);
            WriteLiteral("\r\n                    </th>\r\n                    <th class=\"header-label\">\r\n                        ");
            EndContext();
            BeginContext(4245, 22, false);
#line 118 "D:\Projects-Hub\AzureTesting\MyTest01\MyTest01\Views\Home\Index.cshtml"
                   Write(Html.Label("Division"));

#line default
#line hidden
            EndContext();
            BeginContext(4267, 102, true);
            WriteLiteral("\r\n                    </th>\r\n\r\n                    <th class=\"header-label\">\r\n                        ");
            EndContext();
            BeginContext(4370, 20, false);
#line 122 "D:\Projects-Hub\AzureTesting\MyTest01\MyTest01\Views\Home\Index.cshtml"
                   Write(Html.Label("Period"));

#line default
#line hidden
            EndContext();
            BeginContext(4390, 102, true);
            WriteLiteral("\r\n                    </th>\r\n\r\n                    <th class=\"header-label\">\r\n                        ");
            EndContext();
            BeginContext(4493, 23, false);
#line 126 "D:\Projects-Hub\AzureTesting\MyTest01\MyTest01\Views\Home\Index.cshtml"
                   Write(Html.Label("File Name"));

#line default
#line hidden
            EndContext();
            BeginContext(4516, 100, true);
            WriteLiteral("\r\n                    </th>\r\n                    <th class=\"header-label\">\r\n                        ");
            EndContext();
            BeginContext(4617, 20, false);
#line 129 "D:\Projects-Hub\AzureTesting\MyTest01\MyTest01\Views\Home\Index.cshtml"
                   Write(Html.Label("Action"));

#line default
#line hidden
            EndContext();
            BeginContext(4637, 102, true);
            WriteLiteral("\r\n                    </th>\r\n\r\n                    <th class=\"header-label\">\r\n                        ");
            EndContext();
            BeginContext(4740, 28, false);
#line 133 "D:\Projects-Hub\AzureTesting\MyTest01\MyTest01\Views\Home\Index.cshtml"
                   Write(Html.Label("Published Date"));

#line default
#line hidden
            EndContext();
            BeginContext(4768, 52, true);
            WriteLiteral("\r\n                    </th>\r\n                </tr>\r\n");
            EndContext();
#line 136 "D:\Projects-Hub\AzureTesting\MyTest01\MyTest01\Views\Home\Index.cshtml"
                 if (obj != null)
                {
                    foreach (var row in obj)
                    {
                        string link = (string)row.FILENAME;

#line default
#line hidden
            BeginContext(5004, 62, true);
            WriteLiteral("                        <tr>\r\n                            <td>");
            EndContext();
            BeginContext(5067, 6, false);
#line 142 "D:\Projects-Hub\AzureTesting\MyTest01\MyTest01\Views\Home\Index.cshtml"
                           Write(row.ID);

#line default
#line hidden
            EndContext();
            BeginContext(5073, 39, true);
            WriteLiteral("</td>\r\n                            <td>");
            EndContext();
            BeginContext(5113, 8, false);
#line 143 "D:\Projects-Hub\AzureTesting\MyTest01\MyTest01\Views\Home\Index.cshtml"
                           Write(row.TYPE);

#line default
#line hidden
            EndContext();
            BeginContext(5121, 39, true);
            WriteLiteral("</td>\r\n                            <td>");
            EndContext();
            BeginContext(5161, 10, false);
#line 144 "D:\Projects-Hub\AzureTesting\MyTest01\MyTest01\Views\Home\Index.cshtml"
                           Write(row.STATUS);

#line default
#line hidden
            EndContext();
            BeginContext(5171, 39, true);
            WriteLiteral("</td>\r\n                            <td>");
            EndContext();
            BeginContext(5211, 14, false);
#line 145 "D:\Projects-Hub\AzureTesting\MyTest01\MyTest01\Views\Home\Index.cshtml"
                           Write(row.GROUP_NAME);

#line default
#line hidden
            EndContext();
            BeginContext(5225, 39, true);
            WriteLiteral("</td>\r\n                            <td>");
            EndContext();
            BeginContext(5265, 11, false);
#line 146 "D:\Projects-Hub\AzureTesting\MyTest01\MyTest01\Views\Home\Index.cshtml"
                           Write(row.PERIODS);

#line default
#line hidden
            EndContext();
            BeginContext(5276, 73, true);
            WriteLiteral("</td>\r\n                            <td>\r\n                                ");
            EndContext();
            BeginContext(5350, 254, false);
#line 148 "D:\Projects-Hub\AzureTesting\MyTest01\MyTest01\Views\Home\Index.cshtml"
                           Write(Html.ActionLink(link, "DownloadFile", "Home", routeValues: new
                                {
                                    fileName = link
                                }, htmlAttributes: new { @title = "Click here to download the file" }));

#line default
#line hidden
            EndContext();
            BeginContext(5604, 105, true);
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                <a");
            EndContext();
            BeginWriteAttribute("href", " href=\'", 5709, "\'", 5776, 1);
#line 154 "D:\Projects-Hub\AzureTesting\MyTest01\MyTest01\Views\Home\Index.cshtml"
WriteAttributeValue("", 5716, Url.Action("DownloadFile", "Home", new { fileName = link }), 5716, 60, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(5777, 101, true);
            WriteLiteral(" data-toggle=\"tooltip\" title=\"Click here to download the file\">\r\n                                    ");
            EndContext();
            BeginContext(5878, 35, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "b914c192be66483ab6ffeb49f2f7bf4e", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(5913, 109, true);
            WriteLiteral("\r\n                                </a>\r\n                            </td>\r\n\r\n                            <td>");
            EndContext();
            BeginContext(6023, 16, false);
#line 159 "D:\Projects-Hub\AzureTesting\MyTest01\MyTest01\Views\Home\Index.cshtml"
                           Write(row.PUBLISH_DATE);

#line default
#line hidden
            EndContext();
            BeginContext(6039, 38, true);
            WriteLiteral("</td>\r\n                        </tr>\r\n");
            EndContext();
#line 161 "D:\Projects-Hub\AzureTesting\MyTest01\MyTest01\Views\Home\Index.cshtml"
                    }
                }

#line default
#line hidden
            BeginContext(6119, 43, true);
            WriteLiteral("            </table>\r\n        </fieldset>\r\n");
            EndContext();
#line 165 "D:\Projects-Hub\AzureTesting\MyTest01\MyTest01\Views\Home\Index.cshtml"
    }

#line default
#line hidden
#line 165 "D:\Projects-Hub\AzureTesting\MyTest01\MyTest01\Views\Home\Index.cshtml"
     
}

#line default
#line hidden
            BeginContext(6172, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(6192, 494, true);
                WriteLiteral(@"
    <script>
        $(document).ready(function () {
            window.onbeforeunload = function () { location.reload(); };
            window.history.pushState(null, """", window.location.href);
            window.onpopstate = function () {
                window.history.pushState(null, """", window.location.href);
            };

            $(""#btn-reset"").click(function () {
                window.location.href = ""/Home/Index"";
            });

        });

    </script>
");
                EndContext();
            }
            );
            BeginContext(6689, 2, true);
            WriteLiteral("\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
