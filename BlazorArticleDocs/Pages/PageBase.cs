using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorArticleDocs.Pages
{
    /// <summary>
    /// Page components inherit from this component to invoke the default implementation on "OnAfterRenderAsync" for parsing the page after it has been rendered.
    /// </summary>
    public class PageBase : ComponentBase
    {


        [Inject]
        IJSRuntime JS { get; set; }
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await JS.InvokeVoidAsync("JS_ParsePage");

        }

    }
}
