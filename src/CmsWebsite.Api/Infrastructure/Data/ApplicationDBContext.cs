
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
            entity.HasQueryFilter(r => !r.isDeleted); //isDeleted == false
            entity.Property(r => r.Title).IsRequired();
        }

        private void ConfigureArticleCategories(EntityTypeBuilder<ArticleCategories> entity)
        {
            entity.ToTable("CmsArticleCategories");
            entity.HasKey(ac => ac.ID);
            //entity.HasKey(ac => new { ac.ArticleID, ac.CategoryID });
            //entity.HasOne(ac => ac.Article)
            //    .WithMany(a => a.ArticleCategories)
            //    .HasForeignKey(ac => ac.ArticleID);
            //entity.HasOne(ac => ac.Category)
            //    .WithMany(c => c.ArticleCategories)
            //    .HasForeignKey(ac => ac.CategoryID);
        }

        private void ConfigureCategories(EntityTypeBuilder<Category> entity)
        {
            entity.ToTable("CmsCategories");
            entity.HasKey(r => r.CategoryId);
            entity.Property(r => r.CategoryName).IsRequired();
        }

        public override int SaveChanges()
        {
            UpdateSoftDeleteStatuses();
            return base.SaveChanges();
        }



        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            UpdateSoftDeleteStatuses();
            return await base.SaveChangesAsync(cancellationToken);
        }

        private void UpdateSoftDeleteStatuses()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                var entity = entry.Entity.GetType().Name;
                switch (entry.State)
                {
                    case EntityState.Added:
                        if (entity == "Article" || entity == "Category")
                        {
                            entry.CurrentValues["isDeleted"] = false;
                            entry.CurrentValues["CreatedDate"] = DateTime.Now;
                        }

                        break;
                    case EntityState.Deleted:
                        if (entity == "Article" || entity == "Category")
                        {
                            entry.State = EntityState.Modified;
                            entry.CurrentValues["isDeleted"] = true;
                            entry.CurrentValues["DateDeleted"] = DateTime.Now;
                        }
                        break;
                }
            }
        }
    }
}
