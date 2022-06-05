/// ============================================================
/// Author: Shaun Curtis, Cold Elm Coders
/// License: Use And Donate
/// If you use it, donate something to a charity somewhere
/// ============================================================

namespace Blazr.App.UI;

public static class WeatherForecastExtensions
{
    public static int TemperatureF(this WeatherForecast weatherForecast)
        => (32 + (int)(weatherForecast.TemperatureC / 0.5556));
}
