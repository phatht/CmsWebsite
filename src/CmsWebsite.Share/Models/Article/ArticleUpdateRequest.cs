using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsWebsite.Share.Models.Article
{
    public class ArticleUpdateRequest
    {
        public long ArticleID { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string SummaryArticle { get; set; }
        public IFormFile ImageFile { get; set; }
        public DateTime PublishDate { get; set; }
        public int NumberOfViews { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public int Status { get; set; }
        public string KeyWords { get; set; }
        public string SubHead { get; set; }
        public bool taked { get; set; }
    }
}
