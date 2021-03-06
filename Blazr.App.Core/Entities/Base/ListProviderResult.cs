/// ============================================================
/// Author: Shaun Curtis, Cold Elm Coders
/// License: Use And Donate
/// If you use it, donate something to a charity somewhere
/// ============================================================
namespace Blazr.App.Core;

public record ListProviderResult<TItem>
{
    public IEnumerable<TItem> Items { get; init; }

    public int TotalItemCount { get; init; }

    public bool Success { get; init; }

    public string? Message { get; init; }

    public ItemsProviderResult<TItem> ItemsProviderResult => new ItemsProviderResult<TItem>(this.Items, this.TotalItemCount);

    public ListProviderResult() 
    {
        Items = Enumerable.Empty<TItem>();
        TotalItemCount = 0;
        Success = false;
        Message = "Empty New Initialization";
    }

    public ListProviderResult(IEnumerable<TItem> items, int totalItemCount, bool success = true, string? message = null)
    {
        Items = items;
        TotalItemCount = totalItemCount;
        Success = success;
        Message = message;
    }
}
