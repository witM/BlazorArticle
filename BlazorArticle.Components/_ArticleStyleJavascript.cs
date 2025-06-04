using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorArticle.Components
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class _ArticleStyleJavascript : ComponentBase
    {
        struct Data
        {
            public string Style { get; set; }
            public string StyleId { get; set; }
        }


        [Inject]
        public BlazorArticle.Components.Services.ArticleHeadManager ArticleHeadManager { get; set; }

        [Inject]
        public IJSRuntime JS { get; set; }

        [Parameter]
        public string Style { get; set; }

        Data _data;


        protected override async Task OnParametersSetAsync()
        {
            _data.Style = Style;
            _data.StyleId = ArticleHeadManager.ArticleStyleId;
        }



        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await JS.InvokeVoidAsync("JS_BlazorArticle_RenderArticleStyle", _data);
        }
    }
}

