namespace CmsWebsite.Share.Models.Authentication
{
    public class CurrentUser
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public bool IsAuthenticated { get; set; }
        public Dictionary<string, string>? Claims { get; set; }
    }
}
