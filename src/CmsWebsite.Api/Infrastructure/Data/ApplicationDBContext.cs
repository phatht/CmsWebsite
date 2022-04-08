
using CmsWebsite.Api.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CmsWebsite.Api.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Article> Article { get; set; }
        public DbSet<ArticleCategories> ArticleCategories { get; set; }
        public DbSet<Category> Categories { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
          
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Fluent API
            modelBuilder.Entity<Article>(ConfigureArticle);
            modelBuilder.Entity<ArticleCategories>(ConfigureArticleCategories);
            modelBuilder.Entity<Category>(ConfigureCategories);
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
            entity.HasKey(ac => new { ac.ArticleID, ac.CategoryID });
            entity.HasOne(ac => ac.Article)
                .WithMany(a => a.ArticleCategories)
                .HasForeignKey(ac => ac.ArticleID);
            entity.HasOne(ac => ac.Category)
                .WithMany(c => c.ArticleCategories)
                .HasForeignKey(ac => ac.CategoryID);
        }

        private void ConfigureCategories(EntityTypeBuilder<Category> entity)
        {
            entity.ToTable("CmsCategories");
            entity.HasKey(r => r.CategoryId);
            entity.Property(r => r.CategoryName).IsRequired();
        }

    }
}
