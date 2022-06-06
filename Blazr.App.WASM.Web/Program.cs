using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Blazr.App.Core;
using Blazr.App.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddRazorPages();

var services = builder.Services;
{
    services.AddDbContextFactory<InMemoryWeatherDbContext>(options => options.UseInMemoryDatabase("WeatherDatabase"));
    services.AddSingleton<IDataBroker, ServerInMemoryDataBroker<InMemoryWeatherDbContext>>();
    services.AddControllers().PartManager.ApplicationParts.Add(new AssemblyPart(typeof(Blazr.App.Controllers.WeatherForecastController).Assembly));
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();

