#pragma checksum "C:\Users\HP\Documents\proyectos\DIRECTION_GESTOR\DIRECTION_GESTOR\Views\Archivos\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5d14c64c40963fde36bfd3888986e645c519bc9e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Archivos_Delete), @"mvc.1.0.view", @"/Views/Archivos/Delete.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Archivos/Delete.cshtml", typeof(AspNetCore.Views_Archivos_Delete))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5d14c64c40963fde36bfd3888986e645c519bc9e", @"/Views/Archivos/Delete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"91e03f9cc5c3734ddbcd9b55de29f9d8b3cdee5b", @"/Views/_ViewImports.cshtml")]
    public class Views_Archivos_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DIRECTION_GESTOR.Models.Archivos>
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
            BeginContext(41, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\HP\Documents\proyectos\DIRECTION_GESTOR\DIRECTION_GESTOR\Views\Archivos\Delete.cshtml"
  
    ViewData["Title"] = "Delete";

#line default
#line hidden
            BeginContext(85, 219, true);
            WriteLiteral("\r\n<h2>Delete</h2>\r\n\r\n<h3>Estas seguro de Eliminar este archivo?</h3>\r\n<div>\r\n    <h4>Archivos</h4>\r\n    <hr />\r\n    <dl class=\"dl-horizontal\">\r\n        <dt>\r\n            Enlace\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(305, 45, false);
#line 18 "C:\Users\HP\Documents\proyectos\DIRECTION_GESTOR\DIRECTION_GESTOR\Views\Archivos\Delete.cshtml"
       Write(Html.DisplayFor(model => model.EnlaceArchivo));

#line default
#line hidden
            EndContext();
            BeginContext(350, 102, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            Fecha de Ingreso\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(453, 44, false);
#line 24 "C:\Users\HP\Documents\proyectos\DIRECTION_GESTOR\DIRECTION_GESTOR\Views\Archivos\Delete.cshtml"
       Write(Html.DisplayFor(model => model.FechaArchivo));

#line default
#line hidden
            EndContext();
            BeginContext(497, 101, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            Hora de Ingreso\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(599, 36, false);
#line 30 "C:\Users\HP\Documents\proyectos\DIRECTION_GESTOR\DIRECTION_GESTOR\Views\Archivos\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Hora));

#line default
#line hidden
            EndContext();
            BeginContext(635, 92, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            Estado\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(728, 70, false);
#line 36 "C:\Users\HP\Documents\proyectos\DIRECTION_GESTOR\DIRECTION_GESTOR\Views\Archivos\Delete.cshtml"
       Write(Html.DisplayFor(model => model.IdEstadoFkNavigation.DescripcionEstado));

#line default
#line hidden
            EndContext();
            BeginContext(798, 93, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            Persona\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(892, 68, false);
#line 42 "C:\Users\HP\Documents\proyectos\DIRECTION_GESTOR\DIRECTION_GESTOR\Views\Archivos\Delete.cshtml"
       Write(Html.DisplayFor(model => model.IdPersonaFkNavigation.NombrePersonas));

#line default
#line hidden
            EndContext();
            BeginContext(960, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(962, 70, false);
#line 42 "C:\Users\HP\Documents\proyectos\DIRECTION_GESTOR\DIRECTION_GESTOR\Views\Archivos\Delete.cshtml"
                                                                             Write(Html.DisplayFor(model => model.IdPersonaFkNavigation.ApellidoPersonas));

#line default
#line hidden
            EndContext();
            BeginContext(1032, 101, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            Tipo de Archivo\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1134, 80, false);
#line 48 "C:\Users\HP\Documents\proyectos\DIRECTION_GESTOR\DIRECTION_GESTOR\Views\Archivos\Delete.cshtml"
       Write(Html.DisplayFor(model => model.IdTipoArchivoFkNavigation.DescripcionTipoArchivo));

#line default
#line hidden
            EndContext();
            BeginContext(1214, 38, true);
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n    \r\n    ");
            EndContext();
            BeginContext(1252, 215, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "483e4b177c7742adaeb617bf19529e8d", async() => {
                BeginContext(1278, 10, true);
                WriteLiteral("\r\n        ");
                EndContext();
                BeginContext(1288, 43, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "10098fddca0848e5a6abff87168c6376", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#line 53 "C:\Users\HP\Documents\proyectos\DIRECTION_GESTOR\DIRECTION_GESTOR\Views\Archivos\Delete.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.IdArchivo);

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
                BeginContext(1331, 85, true);
                WriteLiteral("\r\n        <input type=\"submit\" value=\"Eliminar\" class=\"btn btn-danger\" /> |\r\n        ");
                EndContext();
                BeginContext(1416, 38, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e9826000482c4b04aaa280688796448e", async() => {
                    BeginContext(1438, 12, true);
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
                BeginContext(1454, 6, true);
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
            BeginContext(1467, 10, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DIRECTION_GESTOR.Models.Archivos> Html { get; private set; }
    }
}
#pragma warning restore 1591
