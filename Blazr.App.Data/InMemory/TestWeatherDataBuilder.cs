/// ============================================================
/// Author: Shaun Curtis, Cold Elm Coders
/// License: Use And Donate
/// If you use it, donate something to a charity somewhere
/// ============================================================
namespace Blazr.App.Data;

public class TestWeatherDataBuilder
{
    private bool _initialized = false;
    private int RecordsToGenerate = 50;
    private readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

    public IEnumerable<WeatherForecast> WeatherForecasts { get; private set; } = new List<WeatherForecast>();

    private TestWeatherDataBuilder()
    {
        if (!_initialized)
        {
            WeatherForecasts = this.GetForecasts();
            _initialized = true;
        }
    }

    public void LoadDbContext(IDbContextFactory<InMemoryWeatherDbContext> factory)
    {
        using var dbContext = factory.CreateDbContext();

        if (dbContext.WeatherForecast.Count() == 0)
        {
            dbContext.AddRange(this.WeatherForecasts);
            dbContext.SaveChanges();
        }
    }

    private IEnumerable<WeatherForecast> GetForecasts()
    {
        return Enumerable.Range(1, RecordsToGenerate).Select(index => new WeatherForecast
        {
            WeatherForecastId = Guid.NewGuid(),
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        }).ToList();
    }


    private static TestWeatherDataBuilder? _weatherTestData;

    public static TestWeatherDataBuilder GetInstance()
    {
        if (_weatherTestData == null)
            _weatherTestData = new TestWeatherDataBuilder();

        return _weatherTestData;
    }
}
