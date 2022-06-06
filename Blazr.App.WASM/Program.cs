/// ============================================================
/// Author: Shaun Curtis, Cold Elm Coders
/// License: Use And Donate
/// If you use it, donate something to a charity somewhere
/// ============================================================

using Blazr.App.Core;
using Blazr.App.Data;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<Blazr.App.UI.App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var services = builder.Services;
{
    services.AddScoped<IDataBroker, APIDataBroker>();
    services.AddSingleton<WeatherForecastNotificationService>();
    services.AddTransient<WeatherForecastListViewService>();
    services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
}

await builder.Build().RunAsync();
