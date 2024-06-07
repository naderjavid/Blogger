﻿namespace Blogger.Application.Articles.GetArticles;

public class GetArticlesQueryHandler(IArticleRepository articleRepository)
    : IRequestHandler<GetArticlesQuery, IReadOnlyCollection<GetArticlesQueryResponse>>
{
    private readonly IArticleRepository _articleRepository = articleRepository;

    public async Task<IReadOnlyCollection<GetArticlesQueryResponse>> Handle(GetArticlesQuery request, CancellationToken cancellationToken)
    {
        var articles = await _articleRepository.GetLatestArticlesAsync(request.PageNumber, request.PageSize, cancellationToken);

        return [.. articles.Select(x => (GetArticlesQueryResponse)x)];
    }
}
