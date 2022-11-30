using CmsWebsite.Share.Models.Article;
using CmsWebsite.Share.Models.Category;

namespace CmsWebsite.Share.Models.ArticleCategory
{
    public class ArticleCategoryDTO
    {
        public long ArticleID { get; set; }
        public long CategoryID { get; set; }
    }
    public class GroupArticleByCategoryDTO
    {
        public CategoryDTO? Category { get; set; } 
        public List<ArticleDTO>? Articles { get; set; } 
        public GroupArticleByCategoryDTO() { }
        public GroupArticleByCategoryDTO(CategoryDTO category) { 
            Category = category;    
        }
        public GroupArticleByCategoryDTO(CategoryDTO category , List<ArticleDTO>? articles)
        {
            Category = category;
            Articles = articles;
        }

    }
}
