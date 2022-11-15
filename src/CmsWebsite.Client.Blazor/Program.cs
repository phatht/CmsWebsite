using Blazored.LocalStorage;
using CmsWebsite.Client.Blazor;
using CmsWebsite.Client.Blazor.Services;
using CmsWebsite.Client.Blazor.Services.Article;
using CmsWebsite.Client.Blazor.Services.ArticleCategory;
using CmsWebsite.Client.Blazor.Services.Category;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;
var builder = WebAssemblyHostBuilder.CreateDefault(args);


 
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

string urlApiOne = builder.Configuration["UrlCmsWebsiteApi:ClientOne"].ToString();
builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(urlApiOne) });

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, CustomStateProvider>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IArticleService, ArticleService>();
builder.Services.AddScoped<IArticleCategoryService, ArticleCategoryService>();

builder.Services.AddScoped<ICategoryService, CategoryService>();

// Add Radzen
builder.Services.AddScoped<DialogService>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<TooltipService>();
builder.Services.AddScoped<ContextMenuService>();

await builder.Build().RunAsync();
    
