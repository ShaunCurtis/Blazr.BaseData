/// ============================================================
/// Author: Shaun Curtis, Cold Elm Coders
/// License: Use And Donate
/// If you use it, donate something to a charity somewhere
/// ============================================================

namespace Blazr.App.Data;

public class APIDataBroker : IDataBroker
{
    private readonly HttpClient httpClient = default!;

    public APIDataBroker(HttpClient httpClient)
        => this.httpClient = httpClient!;

    public async ValueTask<ListProviderResult<TRecord>> GetRecordsAsync<TRecord>(ListProviderRequest request) where TRecord : class, new()
    {
        string recordname =  (new TRecord()).GetType().Name.ToLower();
        var response = await this.httpClient.PostAsJsonAsync<ListProviderRequest>($"/api/{recordname}/list/", request);
        var result = await response.Content.ReadFromJsonAsync<ListProviderResult<TRecord>>();
        return result 
            ?? new ListProviderResult<TRecord>(new List<TRecord>(), 0, false, "No Api Found");
    }
}
