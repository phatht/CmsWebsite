using CmsWebsite.Share.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsWebsite.Share.Models.Category
{
    public class CategoryUpdateRequest
    {
        public string CategoryName { get; set; }
        public long ParentCategoryId { get; set; }
        public string Abbreviation { get; set; }
        public string IconFile { get; set; }
        public Level Level { get; set; }
    }
}
