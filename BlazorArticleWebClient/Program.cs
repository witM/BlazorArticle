using BlazorArticle;
using BlazorArticle.Components;
using BlazorArticle.Components.Services;
using BlazorArticleWebClient;
using BlazorArticleWebClient.Services;
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
builder.Services.AddSingleton<ArticleProviderSite>();
/************************************************************/

/*** BLAZOR ARTICLE SERVICES ***/
builder.Services.AddBlazorArticle();
//manage the head tag depended from article style
builder.Services.AddBlazorArticleStyle();
//register default markers to be used in articles
builder.Services.AddBlazorArticleDefaultMarkers();

/*** READ CONFIGURATION ***/
var configSection = builder.Configuration.GetSection("AppConfig");
//set it as singleton services or by IOption
//var appConfig = configSection.Get<AppConfig>();
//builder.Services.AddSingleton(appConfig);
builder.Services.Configure<AppConfig>(configSection);




await builder.Build().RunAsync();
