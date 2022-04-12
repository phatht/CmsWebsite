using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsWebsite.Share.Models.ArticleCategory
{
    public class ArticleCategoryCreateRequest
    {
        public long ArticleID { get; set; }
        public long CategoryID { get; set; }
    }
}
