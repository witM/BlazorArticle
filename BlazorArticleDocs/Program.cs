using BlazorArticle;
using BlazorArticle.Components;
using BlazorArticle.Components.Services;
using BlazorArticleDocs;
using BlazorArticleDocs.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Linq;
using System.Net.Http.Json;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddHttpClient("default", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));

/*** APPLICATION WEB SERVICES ***/
builder.Services.AddSingleton<ArticleDocsProvider>();
builder.Services.AddSingleton<ArticleExamplesProvider>();
/************************************************************/

/*** BLAZOR ARTICLE SERVICES ***/
builder.Services.AddBlazorArticle();
//manage the head tag depended from article style
builder.Services.AddBlazorArticleStyle();
//register default markers to be used in articles
builder.Services.AddBlazorArticleDefaultMarkers();

/*** READ CONFIGURATION ***/
//base
var configSection = builder.Configuration.GetSection("AppConfig");
builder.Services.Configure<AppConfig>(configSection);
//articles
builder.Services.Configure<ArticleConfig>(builder.Configuration.GetSection("ArticleConfig"));




await builder.Build().RunAsync();
