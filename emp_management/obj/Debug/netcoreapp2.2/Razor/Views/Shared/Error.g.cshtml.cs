#pragma checksum "C:\Users\HPz400\projects\emp_management\emp_management\Views\Shared\Error.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9a9568746faabcb545d4826cd7a20c4a081804c3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Error), @"mvc.1.0.view", @"/Views/Shared/Error.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Error.cshtml", typeof(AspNetCore.Views_Shared_Error))]
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
#line 1 "C:\Users\HPz400\projects\emp_management\emp_management\Views\_ViewImports.cshtml"
using emp_management.ViewModes;

#line default
#line hidden
#line 2 "C:\Users\HPz400\projects\emp_management\emp_management\Views\_ViewImports.cshtml"
using emp_management.Models;

#line default
#line hidden
#line 3 "C:\Users\HPz400\projects\emp_management\emp_management\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9a9568746faabcb545d4826cd7a20c4a081804c3", @"/Views/Shared/Error.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1b7ed5e89a2d8ba4e8750e4c3876e705dfd53599", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Error : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "C:\Users\HPz400\projects\emp_management\emp_management\Views\Shared\Error.cshtml"
 if (ViewBag.ErrorTitle == null)
{


#line default
#line hidden
            BeginContext(39, 245, true);
            WriteLiteral("<h3>\r\n    An Error occured while processing the request. The support team is notified and working on the fix.\r\n</h3>\r\n<hr />\r\n<h3>\r\n    Exception Details:\r\n</h3>\r\n<div class=\"alert alert-danger\">\r\n    <h5>Exception Path</h5>\r\n    <hr />\r\n    <p>");
            EndContext();
            BeginContext(285, 21, false);
#line 14 "C:\Users\HPz400\projects\emp_management\emp_management\Views\Shared\Error.cshtml"
  Write(ViewBag.ExceptionPath);

#line default
#line hidden
            EndContext();
            BeginContext(306, 14, true);
            WriteLiteral("</p>\r\n</div>\r\n");
            EndContext();
            BeginContext(322, 85, true);
            WriteLiteral("<div class=\"alert alert-danger\">\r\n    <h5>Exception Message</h5>\r\n    <hr />\r\n    <p>");
            EndContext();
            BeginContext(408, 24, false);
#line 20 "C:\Users\HPz400\projects\emp_management\emp_management\Views\Shared\Error.cshtml"
  Write(ViewBag.ExceptionMessage);

#line default
#line hidden
            EndContext();
            BeginContext(432, 14, true);
            WriteLiteral("</p>\r\n</div>\r\n");
            EndContext();
            BeginContext(448, 88, true);
            WriteLiteral("<div class=\"alert alert-danger\">\r\n    <h5>Exception StackTrace</h5>\r\n    <hr />\r\n    <p>");
            EndContext();
            BeginContext(537, 18, false);
#line 26 "C:\Users\HPz400\projects\emp_management\emp_management\Views\Shared\Error.cshtml"
  Write(ViewBag.StackTrace);

#line default
#line hidden
            EndContext();
            BeginContext(555, 14, true);
            WriteLiteral("</p>\r\n</div>\r\n");
            EndContext();
#line 28 "C:\Users\HPz400\projects\emp_management\emp_management\Views\Shared\Error.cshtml"
}
else
{

#line default
#line hidden
            BeginContext(581, 28, true);
            WriteLiteral("    <h1 class=\"text-danger\">");
            EndContext();
            BeginContext(610, 18, false);
#line 31 "C:\Users\HPz400\projects\emp_management\emp_management\Views\Shared\Error.cshtml"
                       Write(ViewBag.ErrorTitle);

#line default
#line hidden
            EndContext();
            BeginContext(628, 35, true);
            WriteLiteral("</h1>\r\n    <h6 class=\"text-danger\">");
            EndContext();
            BeginContext(664, 20, false);
#line 32 "C:\Users\HPz400\projects\emp_management\emp_management\Views\Shared\Error.cshtml"
                       Write(ViewBag.ErrorMessage);

#line default
#line hidden
            EndContext();
            BeginContext(684, 7, true);
            WriteLiteral("</h6>\r\n");
            EndContext();
#line 33 "C:\Users\HPz400\projects\emp_management\emp_management\Views\Shared\Error.cshtml"
}

#line default
#line hidden
            BeginContext(694, 4, true);
            WriteLiteral("\r\n\r\n");
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
