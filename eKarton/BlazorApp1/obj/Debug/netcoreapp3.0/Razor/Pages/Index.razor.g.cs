#pragma checksum "E:\eKarton\eKarton\eKarton\BlazorApp1\Pages\Index.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b6356a50dd141576f53ca9914a4665673d0e2cd4"
// <auto-generated/>
#pragma warning disable 1591
namespace BlazorApp1.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "E:\eKarton\eKarton\eKarton\BlazorApp1\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\eKarton\eKarton\eKarton\BlazorApp1\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\eKarton\eKarton\eKarton\BlazorApp1\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "E:\eKarton\eKarton\eKarton\BlazorApp1\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "E:\eKarton\eKarton\eKarton\BlazorApp1\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "E:\eKarton\eKarton\eKarton\BlazorApp1\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "E:\eKarton\eKarton\eKarton\BlazorApp1\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "E:\eKarton\eKarton\eKarton\BlazorApp1\_Imports.razor"
using BlazorApp1;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "E:\eKarton\eKarton\eKarton\BlazorApp1\_Imports.razor"
using BlazorApp1.Shared;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/")]
    public partial class Index : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "style", "width:100%;");
            __builder.AddMarkupContent(2, "\r\n        ");
            __builder.OpenElement(3, "div");
            __builder.AddAttribute(4, "style", "float:left");
            __builder.AddAttribute(5, "class", "doctorHolder");
            __builder.AddMarkupContent(6, "\r\n            ");
            __builder.OpenElement(7, "img");
            __builder.AddAttribute(8, "class", "picture");
            __builder.AddAttribute(9, "src", "/images/doctor.png");
            __builder.AddAttribute(10, "asp-append-version", "true");
            __builder.AddAttribute(11, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 8 "E:\eKarton\eKarton\eKarton\BlazorApp1\Pages\Index.razor"
                                                                                              DoctorFlagChanged

#line default
#line hidden
#nullable disable
            ));
            __builder.CloseElement();
            __builder.AddMarkupContent(12, "\r\n");
#nullable restore
#line 9 "E:\eKarton\eKarton\eKarton\BlazorApp1\Pages\Index.razor"
             if (DoctorFlag)
            {

#line default
#line hidden
#nullable disable
            __builder.AddContent(13, "                ");
            __builder.AddMarkupContent(14, "<label> Broj Faksimila: </label>\r\n                ");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Forms.EditForm>(15);
            __builder.AddAttribute(16, "Model", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Object>(
#nullable restore
#line 12 "E:\eKarton\eKarton\eKarton\BlazorApp1\Pages\Index.razor"
                                  exampleModel

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(17, "OnValidSubmit", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Forms.EditContext>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Forms.EditContext>(this, 
#nullable restore
#line 12 "E:\eKarton\eKarton\eKarton\BlazorApp1\Pages\Index.razor"
                                                                HandleValidSubmit

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(18, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Forms.EditContext>)((context) => (__builder2) => {
                __builder2.AddMarkupContent(19, "\r\n                    ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator>(20);
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(21, "\r\n                    ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.ValidationSummary>(22);
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(23, "\r\n                    \r\n                    ");
                __Blazor.BlazorApp1.Pages.Index.TypeInference.CreateInputNumber_0(__builder2, 24, 25, "name", 26, 
#nullable restore
#line 16 "E:\eKarton\eKarton\eKarton\BlazorApp1\Pages\Index.razor"
                                                        exampleModel.BrojFaksimila

#line default
#line hidden
#nullable disable
                , 27, Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => exampleModel.BrojFaksimila = __value, exampleModel.BrojFaksimila)), 28, () => exampleModel.BrojFaksimila);
                __builder2.AddMarkupContent(29, "\r\n\r\n                    ");
                __builder2.AddMarkupContent(30, "<button type=\"submit\">Submit</button>\r\n                ");
            }
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(31, "\r\n");
#nullable restore
#line 20 "E:\eKarton\eKarton\eKarton\BlazorApp1\Pages\Index.razor"
            }

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(32, "\r\n\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(33, "\r\n\r\n\r\n        ");
            __builder.OpenElement(34, "div");
            __builder.AddAttribute(35, "style", "float:right");
            __builder.AddAttribute(36, "class", "patientHolder");
            __builder.AddMarkupContent(37, "\r\n            ");
            __builder.OpenElement(38, "img");
            __builder.AddAttribute(39, "class", "picture");
            __builder.AddAttribute(40, "src", "/images/patient.png");
            __builder.AddAttribute(41, "asp-append-version", "true");
            __builder.AddAttribute(42, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 27 "E:\eKarton\eKarton\eKarton\BlazorApp1\Pages\Index.razor"
                                                                                               PatientFlagChanged

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(43, "onselect", "");
            __builder.CloseElement();
            __builder.AddMarkupContent(44, "\r\n");
#nullable restore
#line 28 "E:\eKarton\eKarton\eKarton\BlazorApp1\Pages\Index.razor"
             if (PatientFlag)
            {

#line default
#line hidden
#nullable disable
            __builder.AddContent(45, "                ");
            __builder.AddMarkupContent(46, "<label> LBO: </label>\r\n                ");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Forms.EditForm>(47);
            __builder.AddAttribute(48, "Model", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Object>(
#nullable restore
#line 31 "E:\eKarton\eKarton\eKarton\BlazorApp1\Pages\Index.razor"
                                  exampleModel

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(49, "OnValidSubmit", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Forms.EditContext>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Forms.EditContext>(this, 
#nullable restore
#line 31 "E:\eKarton\eKarton\eKarton\BlazorApp1\Pages\Index.razor"
                                                                HandleValidSubmit

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(50, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Forms.EditContext>)((context) => (__builder2) => {
                __builder2.AddMarkupContent(51, "\r\n                    ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator>(52);
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(53, "\r\n                    ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.ValidationSummary>(54);
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(55, "\r\n\r\n                    ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(56);
                __builder2.AddAttribute(57, "id", "name");
                __builder2.AddAttribute(58, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 35 "E:\eKarton\eKarton\eKarton\BlazorApp1\Pages\Index.razor"
                                                      exampleModel.Name

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(59, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => exampleModel.Name = __value, exampleModel.Name))));
                __builder2.AddAttribute(60, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => exampleModel.Name));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(61, "\r\n\r\n                    ");
                __builder2.AddMarkupContent(62, "<button type=\"submit\">Submit</button>\r\n                ");
            }
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(63, "\r\n");
#nullable restore
#line 40 "E:\eKarton\eKarton\eKarton\BlazorApp1\Pages\Index.razor"
                                                                             
            }

#line default
#line hidden
#nullable disable
            __builder.AddContent(64, "        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(65, "\r\n");
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 44 "E:\eKarton\eKarton\eKarton\BlazorApp1\Pages\Index.razor"
                   
            private bool DoctorFlag { get; set; }
            private bool PatientFlag { get; set; }
            private String Name { get; set; }

            public void ShowName()
            {
                Console.WriteLine(Name);
            }

            public void DoctorFlagChanged()
            {
                DoctorFlag = !DoctorFlag;
                if (DoctorFlag == true && PatientFlag == true)
                {
                    PatientFlag = false;
                }
            }

            public void PatientFlagChanged()
            {
                PatientFlag = !PatientFlag;
                if (PatientFlag == true && DoctorFlag == true)
                {
                    DoctorFlag = false;
                }
            }

             private ExampleModel exampleModel = new ExampleModel();

             private void HandleValidSubmit()
             {
             Console.WriteLine("OnValidSubmit");
             Console.WriteLine(exampleModel.Name);
             }
        

#line default
#line hidden
#nullable disable
    }
}
namespace __Blazor.BlazorApp1.Pages.Index
{
    #line hidden
    internal static class TypeInference
    {
        public static void CreateInputNumber_0<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, System.Object __arg0, int __seq1, TValue __arg1, int __seq2, global::Microsoft.AspNetCore.Components.EventCallback<TValue> __arg2, int __seq3, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg3)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.InputNumber<TValue>>(seq);
        __builder.AddAttribute(__seq0, "id", __arg0);
        __builder.AddAttribute(__seq1, "Value", __arg1);
        __builder.AddAttribute(__seq2, "ValueChanged", __arg2);
        __builder.AddAttribute(__seq3, "ValueExpression", __arg3);
        __builder.CloseComponent();
        }
    }
}
#pragma warning restore 1591