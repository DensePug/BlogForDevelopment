namespace MyBlog.API.DataContracts
{
    public class LikeRequest
    {
        public int PostId { get; set; }

        public long DateUserLoggedInLiked { get; set; }
    }
}