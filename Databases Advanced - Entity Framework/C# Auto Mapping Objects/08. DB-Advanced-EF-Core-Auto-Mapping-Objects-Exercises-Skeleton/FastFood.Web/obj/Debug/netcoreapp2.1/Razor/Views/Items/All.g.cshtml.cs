#pragma checksum "E:\Volen\Programming\Databases Entity Framework\C# Auto Mapping Objects\08. DB-Advanced-EF-Core-Auto-Mapping-Objects-Exercises-Skeleton\FastFood.Web\Views\Items\All.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "10c97971fafe34da9279cc239f3c95d11c5ea885"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Items_All), @"mvc.1.0.view", @"/Views/Items/All.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Items/All.cshtml", typeof(AspNetCore.Views_Items_All))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"10c97971fafe34da9279cc239f3c95d11c5ea885", @"/Views/Items/All.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6e2355b4d2dd102d586b09f0f668ac669855f614", @"/Views/_ViewImports.cshtml")]
    public class Views_Items_All : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IList<FastFood.Web.ViewModels.Items.ItemsAllViewModels>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(64, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "E:\Volen\Programming\Databases Entity Framework\C# Auto Mapping Objects\08. DB-Advanced-EF-Core-Auto-Mapping-Objects-Exercises-Skeleton\FastFood.Web\Views\Items\All.cshtml"
  
    ViewData["Title"] = "All Items";

#line default
#line hidden
            BeginContext(111, 351, true);
            WriteLiteral(@"<h1 class=""text-center"">All Items</h1>
<hr class=""hr-2"" />
<table class=""table mx-auto"">
    <thead>
        <tr class=""row"">
            <th class=""col-md-1"">#</th>
            <th class=""col-md-2"">Name</th>
            <th class=""col-md-2"">Price</th>
            <th class=""col-md-2"">Category</th>
        </tr>
    </thead>
    <tbody>
");
            EndContext();
#line 18 "E:\Volen\Programming\Databases Entity Framework\C# Auto Mapping Objects\08. DB-Advanced-EF-Core-Auto-Mapping-Objects-Exercises-Skeleton\FastFood.Web\Views\Items\All.cshtml"
         for(var i = 0; i < Model.Count(); i++)
    {

#line default
#line hidden
            BeginContext(518, 59, true);
            WriteLiteral("        <tr class=\"row\">\r\n            <th class=\"col-md-1\">");
            EndContext();
            BeginContext(579, 3, false);
#line 21 "E:\Volen\Programming\Databases Entity Framework\C# Auto Mapping Objects\08. DB-Advanced-EF-Core-Auto-Mapping-Objects-Exercises-Skeleton\FastFood.Web\Views\Items\All.cshtml"
                             Write(i+1);

#line default
#line hidden
            EndContext();
            BeginContext(583, 40, true);
            WriteLiteral("</th>\r\n            <td class=\"col-md-2\">");
            EndContext();
            BeginContext(624, 13, false);
#line 22 "E:\Volen\Programming\Databases Entity Framework\C# Auto Mapping Objects\08. DB-Advanced-EF-Core-Auto-Mapping-Objects-Exercises-Skeleton\FastFood.Web\Views\Items\All.cshtml"
                            Write(Model[i].Name);

#line default
#line hidden
            EndContext();
            BeginContext(637, 40, true);
            WriteLiteral("</td>\r\n            <td class=\"col-md-2\">");
            EndContext();
            BeginContext(678, 14, false);
#line 23 "E:\Volen\Programming\Databases Entity Framework\C# Auto Mapping Objects\08. DB-Advanced-EF-Core-Auto-Mapping-Objects-Exercises-Skeleton\FastFood.Web\Views\Items\All.cshtml"
                            Write(Model[i].Price);

#line default
#line hidden
            EndContext();
            BeginContext(692, 40, true);
            WriteLiteral("</td>\r\n            <td class=\"col-md-2\">");
            EndContext();
            BeginContext(733, 17, false);
#line 24 "E:\Volen\Programming\Databases Entity Framework\C# Auto Mapping Objects\08. DB-Advanced-EF-Core-Auto-Mapping-Objects-Exercises-Skeleton\FastFood.Web\Views\Items\All.cshtml"
                            Write(Model[i].Category);

#line default
#line hidden
            EndContext();
            BeginContext(750, 22, true);
            WriteLiteral("</td>\r\n        </tr>\r\n");
            EndContext();
#line 26 "E:\Volen\Programming\Databases Entity Framework\C# Auto Mapping Objects\08. DB-Advanced-EF-Core-Auto-Mapping-Objects-Exercises-Skeleton\FastFood.Web\Views\Items\All.cshtml"
    }

#line default
#line hidden
            BeginContext(779, 22, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IList<FastFood.Web.ViewModels.Items.ItemsAllViewModels>> Html { get; private set; }
    }
}
#pragma warning restore 1591
