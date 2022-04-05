using CmsWebsite.Client.Blazor;
using CmsWebsite.Client.Blazor.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;

var builder = WebAssemblyHostBuilder.CreateDefault(args);


 
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

string urlApiOne = builder.Configuration["UrlCmsWebsiteApi:ClientOne"].ToString();
builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(urlApiOne) });


builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<CustomStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(s => s.GetRequiredService<CustomStateProvider>());
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IArticleService, ArticleService>();
builder.Services.AddScoped<DialogService>();
builder.Services.AddScoped<NotificationService>();
await builder.Build().RunAsync();
    
