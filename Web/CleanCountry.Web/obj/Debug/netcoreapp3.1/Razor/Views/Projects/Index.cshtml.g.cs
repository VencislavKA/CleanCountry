#pragma checksum "C:\Users\Ibryam\Desktop\CleanCountry\Web\CleanCountry.Web\Views\Projects\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "180c66329c866f096ba2729236d657348e29d73a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Projects_Index), @"mvc.1.0.view", @"/Views/Projects/Index.cshtml")]
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
#line 1 "C:\Users\Ibryam\Desktop\CleanCountry\Web\CleanCountry.Web\Views\_ViewImports.cshtml"
using CleanCountry.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Ibryam\Desktop\CleanCountry\Web\CleanCountry.Web\Views\_ViewImports.cshtml"
using CleanCountry.Web.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Ibryam\Desktop\CleanCountry\Web\CleanCountry.Web\Views\_ViewImports.cshtml"
using CleanCountry.Web.ViewModels.Projects;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Ibryam\Desktop\CleanCountry\Web\CleanCountry.Web\Views\_ViewImports.cshtml"
using CleanCountry.Data.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"180c66329c866f096ba2729236d657348e29d73a", @"/Views/Projects/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"259f4ce6368bca56ca1255239e4666ccd0f89331", @"/Views/_ViewImports.cshtml")]
    public class Views_Projects_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Project>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-info float-right"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Projects", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AddProject", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#nullable restore
#line 2 "C:\Users\Ibryam\Desktop\CleanCountry\Web\CleanCountry.Web\Views\Projects\Index.cshtml"
  
    ViewData["Title"] = "Projects";

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "180c66329c866f096ba2729236d657348e29d73a4669", async() => {
                WriteLiteral("Добави проект");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n<h2>Проекти</h2>\r\n<hr/>\r\n<div class=\"card-columns\">\r\n");
#nullable restore
#line 9 "C:\Users\Ibryam\Desktop\CleanCountry\Web\CleanCountry.Web\Views\Projects\Index.cshtml"
     foreach (var project in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"card projectAnimated\"");
            BeginWriteAttribute("href", " href=\"", 309, "\"", 316, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n            <img class=\"card-img-top\"");
            BeginWriteAttribute("src", " src=\"", 357, "\"", 378, 1);
#nullable restore
#line 12 "C:\Users\Ibryam\Desktop\CleanCountry\Web\CleanCountry.Web\Views\Projects\Index.cshtml"
WriteAttributeValue("", 363, project.Images, 363, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"Card image cap\">\r\n            <div class=\"card-body text-center\">\r\n                <h5 class=\"card-title\">");
#nullable restore
#line 14 "C:\Users\Ibryam\Desktop\CleanCountry\Web\CleanCountry.Web\Views\Projects\Index.cshtml"
                                  Write(project.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                <p class=\"card-text\">");
#nullable restore
#line 15 "C:\Users\Ibryam\Desktop\CleanCountry\Web\CleanCountry.Web\Views\Projects\Index.cshtml"
                                Write(project.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                <a");
            BeginWriteAttribute("href", " href=\"", 593, "\"", 629, 2);
            WriteAttributeValue("", 600, "/Projects/Project/", 600, 18, true);
#nullable restore
#line 16 "C:\Users\Ibryam\Desktop\CleanCountry\Web\CleanCountry.Web\Views\Projects\Index.cshtml"
WriteAttributeValue("", 618, project.Id, 618, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-primary w-100\">Повече информация</a>\r\n            </div>\r\n        </div>\r\n");
#nullable restore
#line 19 "C:\Users\Ibryam\Desktop\CleanCountry\Web\CleanCountry.Web\Views\Projects\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div>
<nav>
    <ul class=""pagination justify-content-center"">
        <li class=""page-item disabled"">
            <a class=""page-link"" href=""#"" tabindex=""-1"">Previous</a>
        </li>
        <li class=""page-item active""><a class=""page-link"" href=""#"">1</a></li>
        <li class=""page-item""><a class=""page-link"" href=""#"">2</a></li>
        <li class=""page-item""><a class=""page-link"" href=""#"">3</a></li>
        <li class=""page-item"">
            <a class=""page-link"" href=""#"">Next</a>
        </li>
    </ul>
</nav>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Project>> Html { get; private set; }
    }
}
#pragma warning restore 1591
