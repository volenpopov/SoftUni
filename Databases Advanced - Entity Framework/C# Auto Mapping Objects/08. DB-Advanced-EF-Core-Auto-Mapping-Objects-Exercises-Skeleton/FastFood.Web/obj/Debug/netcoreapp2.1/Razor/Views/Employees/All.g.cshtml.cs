#pragma checksum "E:\Volen\Programming\Databases Entity Framework\C# Auto Mapping Objects\08. DB-Advanced-EF-Core-Auto-Mapping-Objects-Exercises-Skeleton\FastFood.Web\Views\Employees\All.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8ea6fcb3c2b77052a428108da6043ca3cc49ff16"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Employees_All), @"mvc.1.0.view", @"/Views/Employees/All.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Employees/All.cshtml", typeof(AspNetCore.Views_Employees_All))]
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
#line 1 "E:\Volen\Programming\Databases Entity Framework\C# Auto Mapping Objects\08. DB-Advanced-EF-Core-Auto-Mapping-Objects-Exercises-Skeleton\FastFood.Web\Views\_ViewImports.cshtml"
using FastFood.Web;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8ea6fcb3c2b77052a428108da6043ca3cc49ff16", @"/Views/Employees/All.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6e2355b4d2dd102d586b09f0f668ac669855f614", @"/Views/_ViewImports.cshtml")]
    public class Views_Employees_All : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IList<FastFood.Web.ViewModels.Employees.EmployeesAllViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(71, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "E:\Volen\Programming\Databases Entity Framework\C# Auto Mapping Objects\08. DB-Advanced-EF-Core-Auto-Mapping-Objects-Exercises-Skeleton\FastFood.Web\Views\Employees\All.cshtml"
  
    ViewData["Title"] = "All Employees";

#line default
#line hidden
            BeginContext(122, 400, true);
            WriteLiteral(@"<h1 class=""text-center"">All Employees</h1>
<hr class=""hr-2"" />
<table class=""table mx-auto"">
    <thead>
        <tr class=""row"">
            <th class=""col-md-1"">#</th>
            <th class=""col-md-2"">Name</th>
            <th class=""col-md-2"">Age</th>
            <th class=""col-md-2"">Address</th>
            <th class=""col-md-2"">Position</th>
        </tr>
    </thead>
    <tbody>
");
            EndContext();
#line 19 "E:\Volen\Programming\Databases Entity Framework\C# Auto Mapping Objects\08. DB-Advanced-EF-Core-Auto-Mapping-Objects-Exercises-Skeleton\FastFood.Web\Views\Employees\All.cshtml"
         for(var i = 0; i < Model.Count(); i++)
    {

#line default
#line hidden
            BeginContext(578, 59, true);
            WriteLiteral("        <tr class=\"row\">\r\n            <th class=\"col-md-1\">");
            EndContext();
            BeginContext(639, 5, false);
#line 22 "E:\Volen\Programming\Databases Entity Framework\C# Auto Mapping Objects\08. DB-Advanced-EF-Core-Auto-Mapping-Objects-Exercises-Skeleton\FastFood.Web\Views\Employees\All.cshtml"
                             Write(i + 1);

#line default
#line hidden
            EndContext();
            BeginContext(645, 40, true);
            WriteLiteral("</th>\r\n            <td class=\"col-md-2\">");
            EndContext();
            BeginContext(686, 13, false);
#line 23 "E:\Volen\Programming\Databases Entity Framework\C# Auto Mapping Objects\08. DB-Advanced-EF-Core-Auto-Mapping-Objects-Exercises-Skeleton\FastFood.Web\Views\Employees\All.cshtml"
                            Write(Model[i].Name);

#line default
#line hidden
            EndContext();
            BeginContext(699, 40, true);
            WriteLiteral("</td>\r\n            <td class=\"col-md-2\">");
            EndContext();
            BeginContext(740, 12, false);
#line 24 "E:\Volen\Programming\Databases Entity Framework\C# Auto Mapping Objects\08. DB-Advanced-EF-Core-Auto-Mapping-Objects-Exercises-Skeleton\FastFood.Web\Views\Employees\All.cshtml"
                            Write(Model[i].Age);

#line default
#line hidden
            EndContext();
            BeginContext(752, 40, true);
            WriteLiteral("</td>\r\n            <td class=\"col-md-2\">");
            EndContext();
            BeginContext(793, 16, false);
#line 25 "E:\Volen\Programming\Databases Entity Framework\C# Auto Mapping Objects\08. DB-Advanced-EF-Core-Auto-Mapping-Objects-Exercises-Skeleton\FastFood.Web\Views\Employees\All.cshtml"
                            Write(Model[i].Address);

#line default
#line hidden
            EndContext();
            BeginContext(809, 40, true);
            WriteLiteral("</td>\r\n            <td class=\"col-md-2\">");
            EndContext();
            BeginContext(850, 17, false);
#line 26 "E:\Volen\Programming\Databases Entity Framework\C# Auto Mapping Objects\08. DB-Advanced-EF-Core-Auto-Mapping-Objects-Exercises-Skeleton\FastFood.Web\Views\Employees\All.cshtml"
                            Write(Model[i].Position);

#line default
#line hidden
            EndContext();
            BeginContext(867, 22, true);
            WriteLiteral("</td>\r\n        </tr>\r\n");
            EndContext();
#line 28 "E:\Volen\Programming\Databases Entity Framework\C# Auto Mapping Objects\08. DB-Advanced-EF-Core-Auto-Mapping-Objects-Exercises-Skeleton\FastFood.Web\Views\Employees\All.cshtml"
    }

#line default
#line hidden
            BeginContext(896, 22, true);
            WriteLiteral("    </tbody>\r\n</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IList<FastFood.Web.ViewModels.Employees.EmployeesAllViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
