#pragma checksum "C:\Users\Ibryam\Desktop\CleanCountry\Web\CleanCountry.Web\Views\Projects\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3527b1873d219c147462b14e331c7c9be2052389"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3527b1873d219c147462b14e331c7c9be2052389", @"/Views/Projects/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"92809903db706d12ed4d3d4fe5dc604cc0120b66", @"/Views/_ViewImports.cshtml")]
    public class Views_Projects_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\Ibryam\Desktop\CleanCountry\Web\CleanCountry.Web\Views\Projects\Index.cshtml"
  
    ViewData["Title"] = "Projects";

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3527b1873d219c147462b14e331c7c9be20523894292", async() => {
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
            WriteLiteral("\r\n<h2>Проекти</h2>\r\n<hr/>\r\n<div class=\"card-columns\">\r\n    <div class=\"card projectAnimated\"");
            BeginWriteAttribute("href", " href=\"", 241, "\"", 248, 0);
            EndWriteAttribute();
            WriteLiteral(@">
        <img class=""card-img-top"" src=""/images/CleanCountry.png"" alt=""Card image cap"">
        <div class=""card-body text-center"">
            <h5 class=""card-title"">Заглавие на проекта</h5>
            <p class=""card-text"">Тук е краткото описание на проекта можем да го направим като вземем пътвите две изречение от основния текст на обявата или да ги караме да го пишат те при създаването</p>
            <a href=""/Projects/Project"" class=""btn btn-primary w-100"">Повече информация</a>
        </div>
    </div>
    <div class=""card projectAnimated"">
        <img class=""card-img-top"" src=""/images/CleanCountry.png"" alt=""Card image cap"">
        <div class=""card-body"">
            <h5 class=""card-title"">Card title that wraps to a new line</h5>
            <p class=""card-text"">This is a longer card with supporting text below as a natural lead-in to additional content. This content is a little bit longer.</p>
        </div>
    </div>
    <div class=""card projectAnimated"">
        <img class=""card-im");
            WriteLiteral(@"g-top"" src=""/images/CleanCountry.png"" alt=""Card image cap"">
        <div class=""card-body"">
            <h5 class=""card-title"">Card title that wraps to a new line</h5>
            <p class=""card-text"">This is a longer card with supporting text below as a natural lead-in to additional content. This content is a little bit longer.</p>
        </div>
    </div>
    <div class=""card projectAnimated"">
        <img class=""card-img-top"" src=""/images/CleanCountry.png"" alt=""Card image cap"">
        <div class=""card-body"">
            <h5 class=""card-title"">Card title that wraps to a new line</h5>
            <p class=""card-text"">This is a longer card with supporting text below as a natural lead-in to additional content. This content is a little bit longer.</p>
        </div>
    </div>
    <div class=""card projectAnimated"">
        <img class=""card-img-top"" src=""/images/CleanCountry.png"" alt=""Card image cap"">
        <div class=""card-body"">
            <h5 class=""card-title"">Card title that wraps to a ");
            WriteLiteral(@"new line</h5>
            <p class=""card-text"">This is a longer card with supporting text below as a natural lead-in to additional content. This content is a little bit longer.</p>
        </div>
    </div>
    <div class=""card projectAnimated"">
        <img class=""card-img-top"" src=""/images/CleanCountry.png"" alt=""Card image cap"">
        <div class=""card-body"">
            <h5 class=""card-title"">Card title that wraps to a new line</h5>
            <p class=""card-text"">This is a longer card with supporting text below as a natural lead-in to additional content. This content is a little bit longer.</p>
        </div>
    </div>
    <div class=""card projectAnimated"">
        <img class=""card-img-top"" src=""/images/CleanCountry.png"" alt=""Card image cap"">
        <div class=""card-body"">
            <h5 class=""card-title"">Card title that wraps to a new line</h5>
            <p class=""card-text"">This is a longer card with supporting text below as a natural lead-in to additional content. This content is");
            WriteLiteral(@" a little bit longer.</p>
        </div>
    </div>
    <div class=""card projectAnimated"">
        <img class=""card-img-top"" src=""/images/CleanCountry.png"" alt=""Card image cap"">
        <div class=""card-body"">
            <h5 class=""card-title"">Card title that wraps to a new line</h5>
            <p class=""card-text"">This is a longer card with supporting text below as a natural lead-in to additional content. This content is a little bit longer.</p>
        </div>
    </div>
</div>
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
