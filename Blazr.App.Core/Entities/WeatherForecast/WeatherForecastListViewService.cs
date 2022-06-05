/// ============================================================
/// Author: Shaun Curtis, Cold Elm Coders
/// License: Use And Donate
/// If you use it, donate something to a charity somewhere
/// ============================================================

namespace Blazr.App.Core;

public class WeatherForecastListViewService 
{
    private readonly IDataBroker _dataBroker;
    private readonly WeatherForecastNotificationService _weatherForecastNotificationService;
    private ListProviderRequest _request;

    public IEnumerable<WeatherForecast> WeatherForecasts => this.ProviderResult.Items;
    
    public ListProviderResult<WeatherForecast> ProviderResult { get; private set; } = default!;

    public bool IsLoading { get; private set; } = true;

    public WeatherForecastListViewService(IDataBroker dataBroker, WeatherForecastNotificationService notificationService)
    { 
        _dataBroker = dataBroker;
        _weatherForecastNotificationService = notificationService;
    }

    public async ValueTask GetWeatherForecastsAsync(ListProviderRequest request)
    {
        this.IsLoading = true;
        _request = request;
        this.ProviderResult = await _dataBroker.GetRecordsAsync<WeatherForecast>(_request);
        this.IsLoading = false;
    }

    public async ValueTask<ItemsProviderResult<WeatherForecast>> GetVirtualizeWeatherForecastsAsync(ItemsProviderRequest itemsProviderRequest)
    {
        _request = new ListProviderRequest(itemsProviderRequest);
        await this.GetWeatherForecastsAsync(_request);
        return ProviderResult.ItemsProviderResult;
    }

    public async ValueTask<int> GetPagedWeatherForecastsAsync(ItemsProviderRequest itemsProviderRequest)
    {
        _request = new ListProviderRequest(itemsProviderRequest);
        await this.GetWeatherForecastsAsync(_request);
        this.NotifyListChanged();
        return ProviderResult.TotalItemCount;
    }

    private void NotifyListChanged()
        => _weatherForecastNotificationService.NotifyListChanged();
}
