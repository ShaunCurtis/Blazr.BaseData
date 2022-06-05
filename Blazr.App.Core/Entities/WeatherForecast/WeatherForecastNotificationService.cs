/// ============================================================
/// Author: Shaun Curtis, Cold Elm Coders
/// License: Use And Donate
/// If you use it, donate something to a charity somewhere
/// ============================================================

namespace Blazr.App.Core;

public class WeatherForecastNotificationService
{
    public event EventHandler? ListChanged;

    public void NotifyListChanged()
        => this.ListChanged?.Invoke(null, EventArgs.Empty);
}
