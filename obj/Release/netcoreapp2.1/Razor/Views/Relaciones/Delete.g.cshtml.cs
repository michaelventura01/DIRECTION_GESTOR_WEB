#pragma checksum "C:\Users\HP\Documents\proyectos\DIRECTION_GESTOR\DIRECTION_GESTOR\Views\Relaciones\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fcb541a850f763757cd93d611497f0460c1ccc22"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Relaciones_Delete), @"mvc.1.0.view", @"/Views/Relaciones/Delete.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Relaciones/Delete.cshtml", typeof(AspNetCore.Views_Relaciones_Delete))]
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
#line 1 "C:\Users\HP\Documents\proyectos\DIRECTION_GESTOR\DIRECTION_GESTOR\Views\_ViewImports.cshtml"
using DIRECTION_GESTOR;

#line default
#line hidden
#line 2 "C:\Users\HP\Documents\proyectos\DIRECTION_GESTOR\DIRECTION_GESTOR\Views\_ViewImports.cshtml"
using DIRECTION_GESTOR.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fcb541a850f763757cd93d611497f0460c1ccc22", @"/Views/Relaciones/Delete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"91e03f9cc5c3734ddbcd9b55de29f9d8b3cdee5b", @"/Views/_ViewImports.cshtml")]
    public class Views_Relaciones_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DIRECTION_GESTOR.Models.Relaciones>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "hidden", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(43, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\HP\Documents\proyectos\DIRECTION_GESTOR\DIRECTION_GESTOR\Views\Relaciones\Delete.cshtml"
  
    ViewData["Title"] = "Delete";

#line default
#line hidden
            BeginContext(87, 219, true);
            WriteLiteral("<br><br>\r\n<h2>Eliminar</h2>\r\n<br>\r\n<h3>Deseas eliminar esto?</h3>\r\n<div>\r\n    <h4>Relaciones</h4>\r\n    <hr />\r\n    <dl class=\"dl-horizontal\">\r\n        <dt>\r\n            Persona\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(307, 68, false);
#line 18 "C:\Users\HP\Documents\proyectos\DIRECTION_GESTOR\DIRECTION_GESTOR\Views\Relaciones\Delete.cshtml"
       Write(Html.DisplayFor(model => model.IdPersonaFkNavigation.NombrePersonas));

#line default
#line hidden
            EndContext();
            BeginContext(375, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(377, 70, false);
#line 18 "C:\Users\HP\Documents\proyectos\DIRECTION_GESTOR\DIRECTION_GESTOR\Views\Relaciones\Delete.cshtml"
                                                                             Write(Html.DisplayFor(model => model.IdPersonaFkNavigation.ApellidoPersonas));

#line default
#line hidden
            EndContext();
            BeginContext(447, 97, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            Relacionado\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(545, 76, false);
#line 24 "C:\Users\HP\Documents\proyectos\DIRECTION_GESTOR\DIRECTION_GESTOR\Views\Relaciones\Delete.cshtml"
       Write(Html.DisplayFor(model => model.IdPersonaRelacionFkNavigation.NombrePersonas));

#line default
#line hidden
            EndContext();
            BeginContext(621, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(623, 78, false);
#line 24 "C:\Users\HP\Documents\proyectos\DIRECTION_GESTOR\DIRECTION_GESTOR\Views\Relaciones\Delete.cshtml"
                                                                                     Write(Html.DisplayFor(model => model.IdPersonaRelacionFkNavigation.ApellidoPersonas));

#line default
#line hidden
            EndContext();
            BeginContext(701, 102, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            Tipo de Relacion\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(804, 82, false);
#line 30 "C:\Users\HP\Documents\proyectos\DIRECTION_GESTOR\DIRECTION_GESTOR\Views\Relaciones\Delete.cshtml"
       Write(Html.DisplayFor(model => model.IdTipoRelacionFkNavigation.DescripcionTipoRelacion));

#line default
#line hidden
            EndContext();
            BeginContext(886, 38, true);
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n    \r\n    ");
            EndContext();
            BeginContext(924, 216, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ea8c482c873c4b0893212a9780eeec9b", async() => {
                BeginContext(950, 10, true);
                WriteLiteral("\r\n        ");
                EndContext();
                BeginContext(960, 44, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "6fe11bb42b0f4b2cbebdcbb37d6842df", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#line 35 "C:\Users\HP\Documents\proyectos\DIRECTION_GESTOR\DIRECTION_GESTOR\Views\Relaciones\Delete.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.IdRelacion);

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1004, 85, true);
                WriteLiteral("\r\n        <input type=\"submit\" value=\"Eliminar\" class=\"btn btn-danger\" /> |\r\n        ");
                EndContext();
                BeginContext(1089, 38, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d8c442af87174b28bf7782e5a5ffc568", async() => {
                    BeginContext(1111, 12, true);
                    WriteLiteral("Volver Atras");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1127, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1140, 10, true);
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DIRECTION_GESTOR.Models.Relaciones> Html { get; private set; }
    }
}
#pragma warning restore 1591