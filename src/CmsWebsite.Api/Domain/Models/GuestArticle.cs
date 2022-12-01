using System.ComponentModel.DataAnnotations;

namespace CmsWebsite.Api.Domain.Models
{
    public class GuestArticle
    {
        [Key]
        public Guid GuestArticleID { get; set; }
        public string FullName { get; set; }
        [MaxLength(10)]
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string SummaryArticle { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
