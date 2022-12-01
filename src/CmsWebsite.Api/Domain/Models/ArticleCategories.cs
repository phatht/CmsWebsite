using System.ComponentModel.DataAnnotations;

namespace CmsWebsite.Api.Domain.Models
{
    public class ArticleCategories
    {
        [Key]
        public Guid ID { get; set; }
        public Guid ArticleID { get; set; }
        public Guid? CategoryID { get; set; }


    }
}
