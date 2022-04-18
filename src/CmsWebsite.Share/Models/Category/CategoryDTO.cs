namespace CmsWebsite.Share.Models.Category
{
    public class CategoryDTO
    {
        public long CategoryId { get; set; }
        public string CategoryName { get; set; }
        public long ParentCategoryId { get; set; }
        public string Abbreviation { get; set; }
        public string IconFile { get; set; }
        public int Level { get; set; }
        public bool isDeleted { get; set; }

    }
}
