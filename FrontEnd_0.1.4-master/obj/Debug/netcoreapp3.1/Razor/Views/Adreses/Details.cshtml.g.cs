#pragma checksum "C:\Users\artursk\Documents\Proj\Dev\FrontEnd_0.1.4-master\Views\Adreses\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5dae0ff6d78c5ad27fdc79a1b528588b684d9565"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Adreses_Details), @"mvc.1.0.view", @"/Views/Adreses/Details.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\artursk\Documents\Proj\Dev\FrontEnd_0.1.4-master\Views\_ViewImports.cshtml"
using FrontEnd;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\artursk\Documents\Proj\Dev\FrontEnd_0.1.4-master\Views\_ViewImports.cshtml"
using FrontEnd.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\artursk\Documents\Proj\Dev\FrontEnd_0.1.4-master\Views\Adreses\Details.cshtml"
using System;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\artursk\Documents\Proj\Dev\FrontEnd_0.1.4-master\Views\Adreses\Details.cshtml"
using Microsoft.CSharp.RuntimeBinder;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5dae0ff6d78c5ad27fdc79a1b528588b684d9565", @"/Views/Adreses/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d901de1ffd77aac20439ad9b0e2444f7bc8c7e8e", @"/Views/_ViewImports.cshtml")]
    public class Views_Adreses_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<FrontEnd.Models.Arg_Adrese>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/semantic/semantic.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/semantic/themes/semantic.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\artursk\Documents\Proj\Dev\FrontEnd_0.1.4-master\Views\Adreses\Details.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("\n\n");
            WriteLiteral("\n\n");
            WriteLiteral("<!DOCTYPE html>\n<html>\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5dae0ff6d78c5ad27fdc79a1b528588b684d95655155", async() => {
                WriteLiteral("\n    <meta name=\"viewport\" content=\"width=device-width\" />\n    <title>Details</title>\n\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "5dae0ff6d78c5ad27fdc79a1b528588b684d95655508", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "5dae0ff6d78c5ad27fdc79a1b528588b684d95656684", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\n\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5dae0ff6d78c5ad27fdc79a1b528588b684d95658564", async() => {
                WriteLiteral("\n    <table class=\"ui celled table\">\n        <tr>\n            <th>Adrese:</th>\n            <td data-label=\"\">");
#nullable restore
#line 113 "C:\Users\artursk\Documents\Proj\Dev\FrontEnd_0.1.4-master\Views\Adreses\Details.cshtml"
                         Write(Model.STD);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\n        </tr>\n        <tr>\n            <th>Vēsturiskie nosaukumi:</th>\n            <td data-label=\"\">\n");
#nullable restore
#line 118 "C:\Users\artursk\Documents\Proj\Dev\FrontEnd_0.1.4-master\Views\Adreses\Details.cshtml"
                 foreach (var x in Model.AdrArhKods)
                {

#line default
#line hidden
#nullable disable
                WriteLiteral("<p>");
#nullable restore
#line 119 "C:\Users\artursk\Documents\Proj\Dev\FrontEnd_0.1.4-master\Views\Adreses\Details.cshtml"
               Write(x.STD);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>");
#nullable restore
#line 119 "C:\Users\artursk\Documents\Proj\Dev\FrontEnd_0.1.4-master\Views\Adreses\Details.cshtml"
                              }

#line default
#line hidden
#nullable disable
                WriteLiteral("\n            </td>\n        </tr>\n");
#nullable restore
#line 123 "C:\Users\artursk\Documents\Proj\Dev\FrontEnd_0.1.4-master\Views\Adreses\Details.cshtml"
         if (Model.Art_KonstApst_Pak != null)
        {

#line default
#line hidden
#nullable disable
                WriteLiteral("            <tr>\n                <th>Apstiprinājuma pakāpe:</th>\n                <td data-label=\"\">\n                    ");
#nullable restore
#line 128 "C:\Users\artursk\Documents\Proj\Dev\FrontEnd_0.1.4-master\Views\Adreses\Details.cshtml"
               Write(Model.Art_KonstApst_Pak.NOSAUKUMS);

#line default
#line hidden
#nullable disable
                WriteLiteral("\n            </tr>\n");
#nullable restore
#line 130 "C:\Users\artursk\Documents\Proj\Dev\FrontEnd_0.1.4-master\Views\Adreses\Details.cshtml"
        }

#line default
#line hidden
#nullable disable
                WriteLiteral("\n");
#nullable restore
#line 132 "C:\Users\artursk\Documents\Proj\Dev\FrontEnd_0.1.4-master\Views\Adreses\Details.cshtml"
         if (Model.Art_KonstStatuss.NOSAUKUMS != null)
        {

#line default
#line hidden
#nullable disable
                WriteLiteral("            <tr>\n                <th> Adreses statuss:</th>\n                <td data-label=\"\"> ");
#nullable restore
#line 136 "C:\Users\artursk\Documents\Proj\Dev\FrontEnd_0.1.4-master\Views\Adreses\Details.cshtml"
                              Write(Html.DisplayFor(model => model.Art_KonstStatuss.NOSAUKUMS));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\n            </tr>\n");
#nullable restore
#line 138 "C:\Users\artursk\Documents\Proj\Dev\FrontEnd_0.1.4-master\Views\Adreses\Details.cshtml"
        }

#line default
#line hidden
#nullable disable
                WriteLiteral("\n        <tr>\n            <th> Vieta, kurā ietilpst adrese:</th>\n\n            <td href> Skatīt </td>\n\n        </tr>\n\n        <tr>\n            <th> Adreses, kuras ietilpst vietā:</th>\n\n            <td> <a");
                BeginWriteAttribute("href", " href=\"", 2714, "\"", 2782, 2);
                WriteAttributeValue("", 2721, "https://localhost:44308/Adreses/satur/", 2721, 38, true);
#nullable restore
#line 150 "C:\Users\artursk\Documents\Proj\Dev\FrontEnd_0.1.4-master\Views\Adreses\Details.cshtml"
WriteAttributeValue("", 2759, ViewBag.detalas.adR_CD, 2759, 23, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("> Skatīt </a> </td>\n\n\n        </tr>\n\n");
#nullable restore
#line 155 "C:\Users\artursk\Documents\Proj\Dev\FrontEnd_0.1.4-master\Views\Adreses\Details.cshtml"
         if (Model.DAT_BEIG != null)
         { 

#line default
#line hidden
#nullable disable
                WriteLiteral("            <tr>\n                <th>Pēdējās modifikācijas datums:</th>\n                <td data-label=\"\"> ");
#nullable restore
#line 159 "C:\Users\artursk\Documents\Proj\Dev\FrontEnd_0.1.4-master\Views\Adreses\Details.cshtml"
                              Write(Html.DisplayFor(model => model.DAT_BEIG));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\n            </tr>\n");
#nullable restore
#line 161 "C:\Users\artursk\Documents\Proj\Dev\FrontEnd_0.1.4-master\Views\Adreses\Details.cshtml"
         }

#line default
#line hidden
#nullable disable
                WriteLiteral("\n");
#nullable restore
#line 163 "C:\Users\artursk\Documents\Proj\Dev\FrontEnd_0.1.4-master\Views\Adreses\Details.cshtml"
         if (Model.CiemiKods != null)
        {


#line default
#line hidden
#nullable disable
                WriteLiteral("            <tr>\n                <th> IR 11 ciparu Ielas kods:</th>\n                <td data -");
                BeginWriteAttribute("label", " label=\"", 3196, "\"", 3204, 0);
                EndWriteAttribute();
                WriteLiteral(">\n                    ");
#nullable restore
#line 169 "C:\Users\artursk\Documents\Proj\Dev\FrontEnd_0.1.4-master\Views\Adreses\Details.cshtml"
               Write(Html.DisplayFor(model => model.CiemiKods.KODS));

#line default
#line hidden
#nullable disable
                WriteLiteral("\n                </td>\n            </tr>\n");
#nullable restore
#line 172 "C:\Users\artursk\Documents\Proj\Dev\FrontEnd_0.1.4-master\Views\Adreses\Details.cshtml"
        }

#line default
#line hidden
#nullable disable
                WriteLiteral("\n\n    </table>\n\n");
#nullable restore
#line 177 "C:\Users\artursk\Documents\Proj\Dev\FrontEnd_0.1.4-master\Views\Adreses\Details.cshtml"
     if (Model.Art_Dokuments.Count > 0)
     { 

#line default
#line hidden
#nullable disable
                WriteLiteral(@"        <table class=""ui celled table"">
            <thead>
                <tr>
                    <th>Dok. tips</th>
                    <th>Pieņemšanas datums</th>
                    <th>Dokumenta nosaukums</th>
                    <th>Dok. numurs</th>
                    <th>Statuss</th>
                    <th>Pieņēmusi</th>
                    <th>Arhīva lietas Nr.</th>
                    <th>Numurs AR</th>
                    <th>Piezīmes</th>
                </tr>
            </thead>

");
#nullable restore
#line 194 "C:\Users\artursk\Documents\Proj\Dev\FrontEnd_0.1.4-master\Views\Adreses\Details.cshtml"
            foreach (var x in Model.Art_Dokuments)
            { 

#line default
#line hidden
#nullable disable
                WriteLiteral("                <tbody>\n                    <tr>\n                        <td data-label=\"\">");
#nullable restore
#line 198 "C:\Users\artursk\Documents\Proj\Dev\FrontEnd_0.1.4-master\Views\Adreses\Details.cshtml"
                                     Write(x.Art_KonstKods.NOSAUKUMS);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\n                        <td data-label=\"\">");
#nullable restore
#line 199 "C:\Users\artursk\Documents\Proj\Dev\FrontEnd_0.1.4-master\Views\Adreses\Details.cshtml"
                                     Write(x.DATUMS);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\n                        <td data-label=\"\">");
#nullable restore
#line 200 "C:\Users\artursk\Documents\Proj\Dev\FrontEnd_0.1.4-master\Views\Adreses\Details.cshtml"
                                     Write(x.NOSAUKUMS);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\n                        <td data-label=\"\">");
#nullable restore
#line 201 "C:\Users\artursk\Documents\Proj\Dev\FrontEnd_0.1.4-master\Views\Adreses\Details.cshtml"
                                     Write(x.NUMURS);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\n                        <td data-label=\"\">");
#nullable restore
#line 202 "C:\Users\artursk\Documents\Proj\Dev\FrontEnd_0.1.4-master\Views\Adreses\Details.cshtml"
                                     Write(x.Art_KonstStatuss.NOSAUKUMS);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\n                        <td data-label=\"\">");
#nullable restore
#line 203 "C:\Users\artursk\Documents\Proj\Dev\FrontEnd_0.1.4-master\Views\Adreses\Details.cshtml"
                                     Write(x.Art_Organiz.NOSAUKUMS);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\n\n                        <td data-label=\"\">");
#nullable restore
#line 205 "C:\Users\artursk\Documents\Proj\Dev\FrontEnd_0.1.4-master\Views\Adreses\Details.cshtml"
                                     Write(x.LIETA_NUM);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\n                        <td data-label=\"\">");
#nullable restore
#line 206 "C:\Users\artursk\Documents\Proj\Dev\FrontEnd_0.1.4-master\Views\Adreses\Details.cshtml"
                                     Write(x.IENAK_NUM);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\n                        <td data-label=\"\">");
#nullable restore
#line 207 "C:\Users\artursk\Documents\Proj\Dev\FrontEnd_0.1.4-master\Views\Adreses\Details.cshtml"
                                     Write(x.PIEZIMES);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\n\n                    </tr>\n                </tbody>\n");
#nullable restore
#line 211 "C:\Users\artursk\Documents\Proj\Dev\FrontEnd_0.1.4-master\Views\Adreses\Details.cshtml"
            }

#line default
#line hidden
#nullable disable
                WriteLiteral("\n\n        </table>\n");
#nullable restore
#line 215 "C:\Users\artursk\Documents\Proj\Dev\FrontEnd_0.1.4-master\Views\Adreses\Details.cshtml"
     }

#line default
#line hidden
#nullable disable
                WriteLiteral("\n\n\n\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n</html>");
        }
        #pragma warning restore 1998
#nullable restore
#line 11 "C:\Users\artursk\Documents\Proj\Dev\FrontEnd_0.1.4-master\Views\Adreses\Details.cshtml"
           
    public string Aizvieto(dynamic ccc)
    {
        var propertyType = ccc.GetType();

        if (ccc != null)
        {
            return ccc + ", šo datu tips ir " + propertyType;


        }
        else
        {
            return string.Empty;

        }
    }


    public string Aizvieto2(dynamic ccc)
    {

        try
        {

            if (ccc != null)
            {
                return ccc;


            }
            else
            {
                // return string.Empty;
                return "nav datu";

            }



        }
        catch (RuntimeBinderException)
        {
            Console.WriteLine("RuntimeBinderException nostrādāja RuntimeBinderException nostrādāja                ");
            return string.Empty;

        }



    }



    //public static string Class1(this object cc)
    //{

    //       return "I m in Display" ;

    //}

    //public static void addstr(dynamic s1)
    //{
    //    Console.WriteLine(s1);
    //}




    //public dynamic Extension(this string ccc)
    //{
    //    if (ccc != null)
    //    {
    //        //return ccc;
    //        return ccc;
    //    }
    //    else
    //    {

    //        //return string.Empty;
    //        return "nav datu";
    //    }

    //}




#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<FrontEnd.Models.Arg_Adrese> Html { get; private set; }
    }
}
#pragma warning restore 1591
