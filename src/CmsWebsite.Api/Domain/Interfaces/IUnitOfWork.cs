namespace CmsWebsite.Api.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IArticleRepository ArticleRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        IArticleCategoryRepository ArticleCategoryRepository { get; }
        IGuestArticleRepository GuestArticleRepository { get; }
        Task CommitAsync();
        Task RollbackAsync();
    }
}
