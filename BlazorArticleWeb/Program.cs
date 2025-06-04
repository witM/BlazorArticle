
using BlazorArticleWeb.Components;

using BlazorArticle.Components.Services;

using BlazorArticleWeb.Services;
using BlazorArticle;


var builder = WebApplication.CreateBuilder(args);

// Add defautl services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

/*** APPLICATION WEB SERVICES ***/
//test
builder.Services.AddSingleton<ArticleLoader>();
builder.Services.AddScoped<AppStateService>();
/************************************************************/

/*** BLAZOR ARTICLE SERVICES ***/
builder.Services.AddBlazorArticle();
//manage the head tag depended from article style
builder.Services.AddBlazorArticleStyle();

/************************************************************/



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
