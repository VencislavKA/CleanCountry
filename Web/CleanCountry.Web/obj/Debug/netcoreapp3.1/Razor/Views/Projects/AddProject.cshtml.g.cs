#pragma checksum "C:\Users\Ventcy\Documents\GitHub\CleanCountry\Web\CleanCountry.Web\Views\Projects\AddProject.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0d625cc1e9e05d31c8c57fd36d91b9b2da37b0c4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Projects_AddProject), @"mvc.1.0.view", @"/Views/Projects/AddProject.cshtml")]
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
#line 1 "C:\Users\Ventcy\Documents\GitHub\CleanCountry\Web\CleanCountry.Web\Views\_ViewImports.cshtml"
using CleanCountry.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Ventcy\Documents\GitHub\CleanCountry\Web\CleanCountry.Web\Views\_ViewImports.cshtml"
using CleanCountry.Web.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0d625cc1e9e05d31c8c57fd36d91b9b2da37b0c4", @"/Views/Projects/AddProject.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"92809903db706d12ed4d3d4fe5dc604cc0120b66", @"/Views/_ViewImports.cshtml")]
    public class Views_Projects_AddProject : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\Ventcy\Documents\GitHub\CleanCountry\Web\CleanCountry.Web\Views\Projects\AddProject.cshtml"
  
    ViewData["Title"] = "AddProject";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>AddProject</h1>\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0d625cc1e9e05d31c8c57fd36d91b9b2da37b0c43596", async() => {
                WriteLiteral(@"
    <div class=""row mb-3"">
        <label for=""inputEmail3"" class=""col-sm-2 col-form-label"">Email</label>
        <div class=""col-sm-10"">
            <input type=""email"" class=""form-control"" id=""inputEmail3"">
        </div>
    </div>
    <div class=""row mb-3"">
        <label for=""inputPassword3"" class=""col-sm-2 col-form-label"">Password</label>
        <div class=""col-sm-10"">
            <input type=""password"" class=""form-control"" id=""inputPassword3"">
        </div>
    </div>
    <fieldset class=""row mb-3"">
        <legend class=""col-form-label col-sm-2 pt-0"">Radios</legend>
        <div class=""col-sm-10"">
            <div class=""form-check"">
                <input class=""form-check-input"" type=""radio"" name=""gridRadios"" id=""gridRadios1"" value=""option1"" checked>
                <label class=""form-check-label"" for=""gridRadios1"">
                    First radio
                </label>
            </div>
            <div class=""form-check"">
                <input class=""form-check-input""");
                WriteLiteral(@" type=""radio"" name=""gridRadios"" id=""gridRadios2"" value=""option2"">
                <label class=""form-check-label"" for=""gridRadios2"">
                    Second radio
                </label>
            </div>
            <div class=""form-check disabled"">
                <input class=""form-check-input"" type=""radio"" name=""gridRadios"" id=""gridRadios3"" value=""option3"" disabled>
                <label class=""form-check-label"" for=""gridRadios3"">
                    Third disabled radio
                </label>
            </div>
        </div>
    </fieldset>
    <div class=""row mb-3"">
        <div class=""col-sm-10 offset-sm-2"">
            <div class=""form-check"">
                <input class=""form-check-input"" type=""checkbox"" id=""gridCheck1"">
                <label class=""form-check-label"" for=""gridCheck1"">
                    Example checkbox
                </label>
            </div>
        </div>
    </div>
    <button type=""submit"" class=""btn btn-primary"">Sign in</button>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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