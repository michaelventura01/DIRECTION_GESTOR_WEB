#pragma checksum "C:\Users\HP\Documents\proyectos\DIRECTION_GESTOR\DIRECTION_GESTOR\Views\Asignaturasempleadosestudiantes\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fb1e0b2aefc2710a291e21b88c06e3cc218dc6ec"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Asignaturasempleadosestudiantes_Index), @"mvc.1.0.view", @"/Views/Asignaturasempleadosestudiantes/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Asignaturasempleadosestudiantes/Index.cshtml", typeof(AspNetCore.Views_Asignaturasempleadosestudiantes_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fb1e0b2aefc2710a291e21b88c06e3cc218dc6ec", @"/Views/Asignaturasempleadosestudiantes/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"91e03f9cc5c3734ddbcd9b55de29f9d8b3cdee5b", @"/Views/_ViewImports.cshtml")]
    public class Views_Asignaturasempleadosestudiantes_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<DIRECTION_GESTOR.Models.Asignaturasempleadosestudiantes>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(77, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\HP\Documents\proyectos\DIRECTION_GESTOR\DIRECTION_GESTOR\Views\Asignaturasempleadosestudiantes\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
            BeginContext(120, 67, true);
            WriteLiteral("<br><br>\r\n<h2>Estudiantes Asignados a Asignaturas</h2>\r\n\r\n<p>\r\n    ");
            EndContext();
            BeginContext(187, 64, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "af4200ea258c487fa852bf1c5979a286", async() => {
                BeginContext(234, 13, true);
                WriteLiteral("Agregar Nuevo");
                EndContext();
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
            EndContext();
            BeginContext(251, 374, true);
            WriteLiteral(@"
</p>
<table class=""table"">
    <thead>
        <tr>
            <th>
                Estudiante
            </th>
            <th>
                Profesor
            </th>
            <th>
                Estado
            </th>
            <th>
                Periodo
            </th>
            <th></th>
        </tr>
    </thead>
    <tbody>
");
            EndContext();
#line 31 "C:\Users\HP\Documents\proyectos\DIRECTION_GESTOR\DIRECTION_GESTOR\Views\Asignaturasempleadosestudiantes\Index.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
            BeginContext(657, 48, true);
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(706, 100, false);
#line 34 "C:\Users\HP\Documents\proyectos\DIRECTION_GESTOR\DIRECTION_GESTOR\Views\Asignaturasempleadosestudiantes\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.CodigoEstudianteFkNavigation.IdPersonaFkNavigation.NombrePersonas));

#line default
#line hidden
            EndContext();
            BeginContext(806, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(808, 102, false);
#line 34 "C:\Users\HP\Documents\proyectos\DIRECTION_GESTOR\DIRECTION_GESTOR\Views\Asignaturasempleadosestudiantes\Index.cshtml"
                                                                                                                 Write(Html.DisplayFor(modelItem => item.CodigoEstudianteFkNavigation.IdPersonaFkNavigation.ApellidoPersonas));

#line default
#line hidden
            EndContext();
            BeginContext(910, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(966, 131, false);
#line 37 "C:\Users\HP\Documents\proyectos\DIRECTION_GESTOR\DIRECTION_GESTOR\Views\Asignaturasempleadosestudiantes\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.IdAsignaturaEmpleadoFkNavigation.CodigoEmpleadoFkNavigation.IdPersonaFkNavigation.NombrePersonas));

#line default
#line hidden
            EndContext();
            BeginContext(1097, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(1099, 133, false);
#line 37 "C:\Users\HP\Documents\proyectos\DIRECTION_GESTOR\DIRECTION_GESTOR\Views\Asignaturasempleadosestudiantes\Index.cshtml"
                                                                                                                                                Write(Html.DisplayFor(modelItem => item.IdAsignaturaEmpleadoFkNavigation.CodigoEmpleadoFkNavigation.IdPersonaFkNavigation.ApellidoPersonas));

#line default
#line hidden
            EndContext();
            BeginContext(1232, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1288, 73, false);
#line 40 "C:\Users\HP\Documents\proyectos\DIRECTION_GESTOR\DIRECTION_GESTOR\Views\Asignaturasempleadosestudiantes\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.IdEstadoFkNavigation.DescripcionEstado));

#line default
#line hidden
            EndContext();
            BeginContext(1361, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1417, 75, false);
#line 43 "C:\Users\HP\Documents\proyectos\DIRECTION_GESTOR\DIRECTION_GESTOR\Views\Asignaturasempleadosestudiantes\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.IdPeriodoFkNavigation.DescripcionPeriodo));

#line default
#line hidden
            EndContext();
            BeginContext(1492, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1547, 117, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2116aca3da1f487cbc9dff67930b0169", async() => {
                BeginContext(1620, 40, true);
                WriteLiteral("<i class=\"glyphicon glyphicon-edit\"></i>");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 46 "C:\Users\HP\Documents\proyectos\DIRECTION_GESTOR\DIRECTION_GESTOR\Views\Asignaturasempleadosestudiantes\Index.cshtml"
                                       WriteLiteral(item.IdAsignaturaEmpleadoEstudiante);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1664, 20, true);
            WriteLiteral(" |\r\n                ");
            EndContext();
            BeginContext(1684, 120, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3d90abb82d324556919ab18dcb718507", async() => {
                BeginContext(1760, 40, true);
                WriteLiteral("<i class=\"glyphicon glyphicon-book\"></i>");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 47 "C:\Users\HP\Documents\proyectos\DIRECTION_GESTOR\DIRECTION_GESTOR\Views\Asignaturasempleadosestudiantes\Index.cshtml"
                                          WriteLiteral(item.IdAsignaturaEmpleadoEstudiante);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1804, 20, true);
            WriteLiteral(" |\r\n                ");
            EndContext();
            BeginContext(1824, 121, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c40f2f36f2df4d868bf81266792d3a6a", async() => {
                BeginContext(1899, 42, true);
                WriteLiteral("<i class=\"glyphicon glyphicon-remove\"></i>");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 48 "C:\Users\HP\Documents\proyectos\DIRECTION_GESTOR\DIRECTION_GESTOR\Views\Asignaturasempleadosestudiantes\Index.cshtml"
                                         WriteLiteral(item.IdAsignaturaEmpleadoEstudiante);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1945, 36, true);
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
            EndContext();
#line 51 "C:\Users\HP\Documents\proyectos\DIRECTION_GESTOR\DIRECTION_GESTOR\Views\Asignaturasempleadosestudiantes\Index.cshtml"
}

#line default
#line hidden
            BeginContext(1984, 24, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<DIRECTION_GESTOR.Models.Asignaturasempleadosestudiantes>> Html { get; private set; }
    }
}
#pragma warning restore 1591
