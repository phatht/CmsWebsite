namespace CmsWebsite.Share.Method
{
    public class Public
    {
        public bool IsChecked { get; set; }
        public static bool PublishExpiry(DateTime publish, DateTime expiry)
        {

            if (publish < DateTime.Now) 
                return false;
            int result = DateTime.Compare(publish, expiry);

            if (result < 0)
                return true; //Ngày đăng > hết hạn
            else if (result == 0)
                return false; // bằng
            else
                return false; // nhỏ hơn
        }
    }

}
