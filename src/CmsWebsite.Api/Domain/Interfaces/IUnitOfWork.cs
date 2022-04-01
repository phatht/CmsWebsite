namespace CmsWebsite.Api.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IArticleRepository ArticleRepository { get; }
        Task CommitAsync();
        Task RollbackAsync();
    }
}
