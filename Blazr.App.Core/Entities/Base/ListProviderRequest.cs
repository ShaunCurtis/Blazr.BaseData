/// ============================================================
/// Author: Shaun Curtis, Cold Elm Coders
/// License: Use And Donate
/// If you use it, donate something to a charity somewhere
/// ============================================================

namespace Blazr.App.Core;

public record ListProviderRequest
{
    public Guid TransactionId { get; init; }

    public int StartIndex { get; init; }

    public int Count { get; init; }

    public ListProviderRequest() 
    {
        TransactionId = Guid.NewGuid();
        StartIndex = 0;
        Count = 1000;
    }

    public ListProviderRequest(int startIndex, int count)
    {
        TransactionId = Guid.NewGuid();
        StartIndex = startIndex;
        Count = count;
    }

    public ListProviderRequest(ItemsProviderRequest request)
    {
        TransactionId = Guid.NewGuid();
        StartIndex = request.StartIndex;
        Count = request.Count;
    }
}
