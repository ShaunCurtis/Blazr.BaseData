/// ============================================================
/// Author: Shaun Curtis, Cold Elm Coders
/// License: Use And Donate
/// If you use it, donate something to a charity somewhere
/// ============================================================
namespace Blazr.App.Data;

public class ServerInMemoryDataBroker<TDbContext>
    : ServerEFDataBroker<TDbContext>
    where TDbContext : DbContext, IWeatherDbContext
{
    public ServerInMemoryDataBroker(IDbContextFactory<TDbContext> db)
        : base(db)
    {
        if (db is IDbContextFactory<InMemoryWeatherDbContext>)
            TestWeatherDataBuilder.GetInstance().LoadDbContext((IDbContextFactory<InMemoryWeatherDbContext>)db);
    }
}
