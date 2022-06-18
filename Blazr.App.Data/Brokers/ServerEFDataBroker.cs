/// ============================================================
/// Author: Shaun Curtis, Cold Elm Coders
/// License: Use And Donate
/// If you use it, donate something to a charity somewhere
/// ============================================================
namespace Blazr.App.Data;

public class ServerEFDataBroker<TDbContext>
    : IDataBroker
    where TDbContext : DbContext, IWeatherDbContext
{
    protected readonly IDbContextFactory<TDbContext> database;
    private bool _success;
    private string? _message;

    public ServerEFDataBroker(IDbContextFactory<TDbContext> db)
        => this.database = db;

    public async ValueTask<ListProviderResult<TRecord>> GetRecordsAsync<TRecord>(ListProviderRequest options) where TRecord : class, new()
    {
        _message = null;
        _success = true;
        var list = await this.GetItemsAsync<TRecord>(options);
        var count = await this.GetCountAsync<TRecord>(options);
        return new ListProviderResult<TRecord>(list, count, _success, _message);    
    }

    protected async ValueTask<IEnumerable<TRecord>> GetItemsAsync<TRecord>(ListProviderRequest options) where TRecord : class, new()
    {
        using var dbContext = database.CreateDbContext();

        IQueryable<TRecord> query = dbContext.Set<TRecord>();

        if (options.Count > 0)
            query = query
                .Skip(options.StartIndex)
                .Take(options.Count);

        try
        {
            return await query.ToListAsync();
        }
        catch
        {
            _success = false;
            _message = "Error in Executing Query.";
            return new List<TRecord>();
        }
    }

    protected async ValueTask<int> GetCountAsync<TRecord>(ListProviderRequest options) where TRecord : class, new()
    {
        using var dbContext = database.CreateDbContext();

        IQueryable<TRecord> query = dbContext.Set<TRecord>();

        try
        {
            return await query.CountAsync();
        }
        catch
        {
            _success = false;
            _message = "Error in Executing Query.";
            return 0;
        }
    }
}
