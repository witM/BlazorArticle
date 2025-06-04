using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.JSInterop;
using System.ComponentModel;

namespace BlazorArticleWebClient
{
    public class RouteViewApp : ComponentBase
    {

        [Inject]
        IJSRuntime JS { get; set; }

        [Parameter] public RouteData? RouteData { get; set; }
        [Parameter] public Type? DefaultLayout { get; set; }


        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            //JS.InvokeVoidAsync("JS_ParsePage");
        }

        protected override void OnAfterRender(bool firstRender)
        {
            JS.InvokeVoidAsync("JS_ParsePage");

        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);
            builder.OpenComponent<RouteView>(0);
            builder.AddComponentParameter(1, "RouteData", RouteData);
            builder.AddComponentParameter(2, "DefaultLayout", DefaultLayout);
            builder.CloseComponent();
        }
    }
}
