#pragma checksum "C:\Users\HP\Documents\proyectos\DIRECTION_GESTOR\DIRECTION_GESTOR\Views\Direcciones\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9f145741ff5ba4a8a50ea4acada61d1ef13b7ff3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Direcciones_Details), @"mvc.1.0.view", @"/Views/Direcciones/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Direcciones/Details.cshtml", typeof(AspNetCore.Views_Direcciones_Details))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9f145741ff5ba4a8a50ea4acada61d1ef13b7ff3", @"/Views/Direcciones/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"91e03f9cc5c3734ddbcd9b55de29f9d8b3cdee5b", @"/Views/_ViewImports.cshtml")]
    public class Views_Direcciones_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DIRECTION_GESTOR.Models.Direcciones>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(44, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\HP\Documents\proyectos\DIRECTION_GESTOR\DIRECTION_GESTOR\Views\Direcciones\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
            BeginContext(89, 190, true);
            WriteLiteral("<br><br>\r\n<h2>Detalles</h2>\r\n<br>\r\n<div>\r\n    <h4>Direcciones</h4>\r\n    <hr />\r\n    <dl class=\"dl-horizontal\">\r\n        <dt>\r\n            Direccion\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(280, 52, false);
#line 17 "C:\Users\HP\Documents\proyectos\DIRECTION_GESTOR\DIRECTION_GESTOR\Views\Direcciones\Details.cshtml"
       Write(Html.DisplayFor(model => model.DescripcionDireccion));

#line default
#line hidden
            EndContext();
            BeginContext(332, 92, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            Barrio\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(425, 70, false);
#line 23 "C:\Users\HP\Documents\proyectos\DIRECTION_GESTOR\DIRECTION_GESTOR\Views\Direcciones\Details.cshtml"
       Write(Html.DisplayFor(model => model.IdBarrioFkNavigation.DescripcionBarrio));

#line default
#line hidden
            EndContext();
            BeginContext(495, 2, true);
            WriteLiteral(", ");
            EndContext();
            BeginContext(498, 91, false);
#line 23 "C:\Users\HP\Documents\proyectos\DIRECTION_GESTOR\DIRECTION_GESTOR\Views\Direcciones\Details.cshtml"
                                                                                Write(Html.DisplayFor(model => model.IdBarrioFkNavigation.IdCiudadFkNavigation.DescripcionCiudad));

#line default
#line hidden
            EndContext();
            BeginContext(589, 92, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            Estado\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(682, 70, false);
#line 29 "C:\Users\HP\Documents\proyectos\DIRECTION_GESTOR\DIRECTION_GESTOR\Views\Direcciones\Details.cshtml"
       Write(Html.DisplayFor(model => model.IdEstadoFkNavigation.DescripcionEstado));

#line default
#line hidden
            EndContext();
            BeginContext(752, 64, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt style=\"display:none\">\r\n            ");
            EndContext();
            BeginContext(817, 61, false);
#line 32 "C:\Users\HP\Documents\proyectos\DIRECTION_GESTOR\DIRECTION_GESTOR\Views\Direcciones\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.IdInstitucionFkNavigation));

#line default
#line hidden
            EndContext();
            BeginContext(878, 64, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd style=\"display:none\">\r\n            ");
            EndContext();
            BeginContext(943, 80, false);
#line 35 "C:\Users\HP\Documents\proyectos\DIRECTION_GESTOR\DIRECTION_GESTOR\Views\Direcciones\Details.cshtml"
       Write(Html.DisplayFor(model => model.IdInstitucionFkNavigation.DescripcionInstitucion));

#line default
#line hidden
            EndContext();
            BeginContext(1023, 47, true);
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
            EndContext();
            BeginContext(1070, 92, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "aa286e56b35e49d4b3e6ea6ace49d326", async() => {
                BeginContext(1149, 9, true);
                WriteLiteral("Modificar");
                EndContext();
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
#line 40 "C:\Users\HP\Documents\proyectos\DIRECTION_GESTOR\DIRECTION_GESTOR\Views\Direcciones\Details.cshtml"
                           WriteLiteral(Model.IdDireccion);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1162, 8, true);
            WriteLiteral(" |\r\n    ");
            EndContext();
            BeginContext(1170, 38, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2497698811044268853e88498b9032eb", async() => {
                BeginContext(1192, 12, true);
                WriteLiteral("Volver Atras");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1208, 10, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DIRECTION_GESTOR.Models.Direcciones> Html { get; private set; }
    }
}
#pragma warning restore 1591
