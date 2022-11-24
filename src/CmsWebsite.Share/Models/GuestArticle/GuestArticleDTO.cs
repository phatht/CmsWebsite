using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsWebsite.Share.Models.GuestArticle
{
    public class GuestArticleDTO
    {
        public long GuestArticleID { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string SummaryArticle { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
