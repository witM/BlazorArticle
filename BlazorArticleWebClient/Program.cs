using BlazorArticleWebClient;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

using BlazorArticle;
using BlazorArticle.Components.Services;

using BlazorArticleWebClient.Services;
using Microsoft.AspNetCore.Components;
using BlazorArticle.Components;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddHttpClient("default", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));

/*** APPLICATION WEB SERVICES ***/
//test
builder.Services.AddSingleton<ArticleLoader>();
builder.Services.AddScoped<AppStateService>();
/************************************************************/

/*** BLAZOR ARTICLE SERVICES ***/
builder.Services.AddBlazorArticle();
//manage the head tag depended from article style
builder.Services.AddBlazorArticleStyle();


builder.RootComponents.RegisterCustomElement<ArticleStyleOutlet>("article-style-outlet");

await builder.Build().RunAsync();
