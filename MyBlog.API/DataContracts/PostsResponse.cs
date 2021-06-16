namespace MyBlog.API.DataContracts
{
    public class PostsResponse
    {
        public int pageCount { get; set; }

        public Post[] Posts { get; set; }
    }
}