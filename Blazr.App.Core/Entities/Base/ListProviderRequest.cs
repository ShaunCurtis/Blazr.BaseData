/// ============================================================
/// Author: Shaun Curtis, Cold Elm Coders
/// License: Use And Donate
/// If you use it, donate something to a charity somewhere
/// ============================================================

namespace Blazr.App.Core;

public readonly struct ListProviderRequest
{
    public readonly Guid TransactionId = Guid.NewGuid();

    public int StartIndex { get; }

    public int Count { get; }

    public CancellationToken CancellationToken { get; }

    public ItemsProviderRequest Request => new (this.StartIndex, this.Count, this.CancellationToken);

    public ListProviderRequest(int startIndex, int count, CancellationToken cancellationToken)
    {
        StartIndex = startIndex;
        Count = count;
        CancellationToken = cancellationToken;
    }

    public ListProviderRequest(ItemsProviderRequest request)
    {
        StartIndex = request.StartIndex;
        Count = request.Count;
        CancellationToken = request.CancellationToken;
    }
}
