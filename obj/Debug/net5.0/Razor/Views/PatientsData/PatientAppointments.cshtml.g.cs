#pragma checksum "D:\Microsoft Visual Studio\source\repos\ClinicManagement\src\ClinicManagement\Views\PatientsData\PatientAppointments.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c7be35da78bde238b94d4b96a5fce367c46ce209"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_PatientsData_PatientAppointments), @"mvc.1.0.view", @"/Views/PatientsData/PatientAppointments.cshtml")]
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
#line 1 "D:\Microsoft Visual Studio\source\repos\ClinicManagement\src\ClinicManagement\Views\_ViewImports.cshtml"
using ClinicManagement;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Microsoft Visual Studio\source\repos\ClinicManagement\src\ClinicManagement\Views\_ViewImports.cshtml"
using ClinicManagement.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c7be35da78bde238b94d4b96a5fce367c46ce209", @"/Views/PatientsData/PatientAppointments.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"66b2c6c1808a4525931aa99d11800b593e658ba9", @"/Views/_ViewImports.cshtml")]
    public class Views_PatientsData_PatientAppointments : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ClinicManagement.Models.AppointmentsModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "PatientsData", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n<div class=\"container\" style=\"margin-top: 20px;\">\r\n");
#nullable restore
#line 9 "D:\Microsoft Visual Studio\source\repos\ClinicManagement\src\ClinicManagement\Views\PatientsData\PatientAppointments.cshtml"
     using (Html.BeginForm("PatientAppointments", "PatientsData", FormMethod.Post))
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h4>");
#nullable restore
#line 11 "D:\Microsoft Visual Studio\source\repos\ClinicManagement\src\ClinicManagement\Views\PatientsData\PatientAppointments.cshtml"
   Write(Model.Appointments[0].BkdPatient);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h4>
        <hr />
        <table cellpadding=""0"" cellspacing=""0"" border=""1"" class=""table table-bordered"">
            <tr>
                <th>Booking Number</th>
                <th>Date</th>
                <th>Booking Slot #</th>
                <th>Doctor Name</th>
            </tr>
");
#nullable restore
#line 20 "D:\Microsoft Visual Studio\source\repos\ClinicManagement\src\ClinicManagement\Views\PatientsData\PatientAppointments.cshtml"
             foreach (var appointment in Model.Appointments)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>");
#nullable restore
#line 23 "D:\Microsoft Visual Studio\source\repos\ClinicManagement\src\ClinicManagement\Views\PatientsData\PatientAppointments.cshtml"
                   Write(appointment.BookingNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 24 "D:\Microsoft Visual Studio\source\repos\ClinicManagement\src\ClinicManagement\Views\PatientsData\PatientAppointments.cshtml"
                   Write(appointment.BookingDate.Value.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>\r\n");
#nullable restore
#line 26 "D:\Microsoft Visual Studio\source\repos\ClinicManagement\src\ClinicManagement\Views\PatientsData\PatientAppointments.cshtml"
                         if (@appointment.BookingSlot == 1)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <span>10AM:11AM</span>\r\n");
#nullable restore
#line 29 "D:\Microsoft Visual Studio\source\repos\ClinicManagement\src\ClinicManagement\Views\PatientsData\PatientAppointments.cshtml"
                        }
                        else
                        {
                            if (@appointment.BookingSlot == 2)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <span>12AM:01PM</span>\r\n");
#nullable restore
#line 35 "D:\Microsoft Visual Studio\source\repos\ClinicManagement\src\ClinicManagement\Views\PatientsData\PatientAppointments.cshtml"
                            }
                            else
                            {
                                if (@appointment.BookingSlot == 3)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <span>12AM:01PM</span>\r\n");
#nullable restore
#line 41 "D:\Microsoft Visual Studio\source\repos\ClinicManagement\src\ClinicManagement\Views\PatientsData\PatientAppointments.cshtml"
                                }
                                else
                                {
                                    if (@appointment.BookingSlot == 4)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <span>02PM:03PM</span>\r\n");
#nullable restore
#line 47 "D:\Microsoft Visual Studio\source\repos\ClinicManagement\src\ClinicManagement\Views\PatientsData\PatientAppointments.cshtml"
                                    }
                                    else
                                    {
                                        if (@appointment.BookingSlot == 5)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <span>03PM:04PM</span>\r\n");
#nullable restore
#line 53 "D:\Microsoft Visual Studio\source\repos\ClinicManagement\src\ClinicManagement\Views\PatientsData\PatientAppointments.cshtml"
                                        }
                                        else
                                        {
                                            if (@appointment.BookingSlot == 6)
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <span>04PM:05PM</span>\r\n");
#nullable restore
#line 59 "D:\Microsoft Visual Studio\source\repos\ClinicManagement\src\ClinicManagement\Views\PatientsData\PatientAppointments.cshtml"
                                            }
                                            else
                                            {
                                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 62 "D:\Microsoft Visual Studio\source\repos\ClinicManagement\src\ClinicManagement\Views\PatientsData\PatientAppointments.cshtml"
                                           Write(appointment.BookingSlot);

#line default
#line hidden
#nullable disable
#nullable restore
#line 62 "D:\Microsoft Visual Studio\source\repos\ClinicManagement\src\ClinicManagement\Views\PatientsData\PatientAppointments.cshtml"
                                                                        
                                            }
                                        }
                                    }
                                }
                            }
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </td>\r\n                    <td>");
#nullable restore
#line 70 "D:\Microsoft Visual Studio\source\repos\ClinicManagement\src\ClinicManagement\Views\PatientsData\PatientAppointments.cshtml"
                   Write(appointment.AppDoctor);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                </tr>\r\n");
#nullable restore
#line 72 "D:\Microsoft Visual Studio\source\repos\ClinicManagement\src\ClinicManagement\Views\PatientsData\PatientAppointments.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </table>\r\n        <br />\r\n        <table cellpadding=\"0\" cellspacing=\"0\">\r\n            <tr>\r\n");
#nullable restore
#line 77 "D:\Microsoft Visual Studio\source\repos\ClinicManagement\src\ClinicManagement\Views\PatientsData\PatientAppointments.cshtml"
                 for (int i = 1; i <= Model.PageCount; i++)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td style=\"padding: 5px 10px 5px 10px;  border: 1px solid #ccc;\">\r\n");
#nullable restore
#line 80 "D:\Microsoft Visual Studio\source\repos\ClinicManagement\src\ClinicManagement\Views\PatientsData\PatientAppointments.cshtml"
                         if (i != Model.CurrentPageIndex)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <a");
            BeginWriteAttribute("href", " href=\"", 3426, "\"", 3459, 3);
            WriteAttributeValue("", 3433, "javascript:PagerClick(", 3433, 22, true);
#nullable restore
#line 82 "D:\Microsoft Visual Studio\source\repos\ClinicManagement\src\ClinicManagement\Views\PatientsData\PatientAppointments.cshtml"
WriteAttributeValue("", 3455, i, 3455, 2, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3457, ");", 3457, 2, true);
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 82 "D:\Microsoft Visual Studio\source\repos\ClinicManagement\src\ClinicManagement\Views\PatientsData\PatientAppointments.cshtml"
                                                            Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n");
#nullable restore
#line 83 "D:\Microsoft Visual Studio\source\repos\ClinicManagement\src\ClinicManagement\Views\PatientsData\PatientAppointments.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <span>");
#nullable restore
#line 86 "D:\Microsoft Visual Studio\source\repos\ClinicManagement\src\ClinicManagement\Views\PatientsData\PatientAppointments.cshtml"
                             Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n");
#nullable restore
#line 87 "D:\Microsoft Visual Studio\source\repos\ClinicManagement\src\ClinicManagement\Views\PatientsData\PatientAppointments.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </td>\r\n");
#nullable restore
#line 89 "D:\Microsoft Visual Studio\source\repos\ClinicManagement\src\ClinicManagement\Views\PatientsData\PatientAppointments.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tr>\r\n        </table>\r\n        <input type=\"hidden\" id=\"hfCurrentPageIndex\" name=\"currentPageIndex\" />\r\n");
#nullable restore
#line 93 "D:\Microsoft Visual Studio\source\repos\ClinicManagement\src\ClinicManagement\Views\PatientsData\PatientAppointments.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("    <script type=\"text/javascript\">\r\n        function PagerClick(index) {\r\n            document.getElementById(\"hfCurrentPageIndex\").value = index;\r\n            document.forms[0].submit();\r\n        }\r\n    </script>\r\n</div>\r\n<h2>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c7be35da78bde238b94d4b96a5fce367c46ce20914278", async() => {
                WriteLiteral("Back to Patients List");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</h2>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ClinicManagement.Models.AppointmentsModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
