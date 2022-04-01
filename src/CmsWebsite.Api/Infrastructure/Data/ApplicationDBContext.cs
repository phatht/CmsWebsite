
using CmsWebsite.Api.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CmsWebsite.Api.Infrastructure.Data
{
    public class ApplicationDBContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Article> Article { get; set; }
        public DbSet<ArticleCategories> ArticleCategories { get; set; }
        public DbSet<Categories> Categories { get; set; }


        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
          
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Fluent API
            modelBuilder.Entity<Article>(ConfigureArticle);
            modelBuilder.Entity<ArticleCategories>(ConfigureArticleCategories);
            modelBuilder.Entity<Categories>(ConfigureCategories);
        }
        private void ConfigureArticle(EntityTypeBuilder<Article> entity)
        {
            entity.ToTable("CmsArticle");
            entity.HasKey(r => r.ArticleID);
            entity.Property(r => r.Title).IsRequired();
        }

        private void ConfigureArticleCategories(EntityTypeBuilder<ArticleCategories> entity)
        {
            entity.ToTable("CmsArticleCategories");
            entity.HasKey(r => r.ID); 
        }

        private void ConfigureCategories(EntityTypeBuilder<Categories> entity)
        {
            entity.ToTable("CmsCategories");
            entity.HasKey(r => r.CategoryId);
            entity.Property(r => r.CategoryName).IsRequired();
        }

    }
}
