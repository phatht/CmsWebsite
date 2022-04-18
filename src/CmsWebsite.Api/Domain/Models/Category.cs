namespace CmsWebsite.Api.Domain.Models
{
    public class Category
    {
         
        public long CategoryId { get; set; }
        public string CategoryName { get; set; }
        public long ParentCategoryId { get; set; }
        public string Abbreviation { get; set; }
        public string IconFile { get; set; }
        public int Level { get; set; }
        public bool isDeleted  { get; set; }
        public DateTime? DateDeleted { get; set; }
        public DateTime? CreatedDate { get; set; }

    }
}
