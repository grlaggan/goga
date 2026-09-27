using Goga.Backend.Application.Interfaces;
using MediatR;

namespace Goga.Backend.Application.News.Queries;

public sealed record GetNewsQuery : IRequest<IReadOnlyList<NewsResult>>;
public sealed record NewsResult(Guid Id, string Title, string Description);

public sealed class GetNewsQueryHandler(INewsRepository news)
    : IRequestHandler<GetNewsQuery, IReadOnlyList<NewsResult>>
{
    public async Task<IReadOnlyList<NewsResult>> Handle(GetNewsQuery request, CancellationToken cancellationToken)
    {
        var items = await news.GetAllAsync(cancellationToken);
        return items.Select(item => new NewsResult(item.Id, item.Title, item.Description)).ToList();
    }
}
