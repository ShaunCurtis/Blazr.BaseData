using Microsoft.AspNetCore.Mvc;
/// ============================================================
/// Author: Shaun Curtis, Cold Elm Coders
/// License: Use And Donate
/// If you use it, donate something to a charity somewhere
/// ============================================================
namespace Blazr.App.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class WeatherForecastController : ControllerBase
{
    private IDataBroker _dataBroker;

    public WeatherForecastController(IDataBroker dataBroker)
        => _dataBroker = dataBroker;

    [Route("/api/weatherforecast/list")]
    [HttpPost]
    public async ValueTask<ListProviderResult<WeatherForecast>> GetForecastsAsync([FromBody] ListProviderRequest request)
        => await _dataBroker.GetRecordsAsync<WeatherForecast>(request);
}

