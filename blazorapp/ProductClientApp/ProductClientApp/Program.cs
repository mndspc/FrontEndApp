using ProductClientApp;
using ProductClientApp.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
var baseUrl = builder.Configuration.GetValue<string>("ApiBaseUrl");
// Set API Base URL (change port if needed)
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(baseUrl) });

// Register Product Service
builder.Services.AddScoped<IProductService, ProductService>();

await builder.Build().RunAsync();
