/// ============================================================
/// Author: Shaun Curtis, Cold Elm Coders
/// License: Use And Donate
/// If you use it, donate something to a charity somewhere
/// ============================================================
namespace Blazr.App.Data;

public interface IWeatherDbContext
{
    public DbSet<WeatherForecast> WeatherForecast { get; set; }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    public EntityEntry Add(object entity);

    public EntityEntry Update(object entity);

    public EntityEntry Remove(object entity);

    public DbSet<TEntity> Set<TEntity>() where TEntity : class;
}
