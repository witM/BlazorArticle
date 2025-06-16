
using BlazorArticle;
using BlazorArticle.Components.Services;
using BlazorArticleWeb.Components;
using BlazorArticleWeb.Services;
using BlazorArticleWeb.Data;
//
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);

// Add defautl services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

/*** APPLICATION WEB SERVICES ***/
builder.Services.AddScoped<AppStateService>();
builder.Services.AddScoped<ArticleProviderSite>();
/************************************************************/

/*** BLAZOR ARTICLE SERVICES ***/
builder.Services.AddBlazorArticle();
//manage the head tag depended from article style
builder.Services.AddBlazorArticleStyle();
//register default markers to be used in articles
builder.Services.AddBlazorArticleDefaultMarkers();

/************************************************************/

string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));



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
