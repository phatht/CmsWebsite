namespace CmsWebsite.Api.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IArticleRepository ArticleRepository { get; }
        ICategoryRepository CategoryRepository { get; }

        Task CommitAsync();
        Task RollbackAsync();
    }
}
