using System;

namespace MyBlog.API.DataContracts
{
    public class Post
    {
        public Post(string title, string imageUrl, string content, params string[] tags)
        {
            Title = title;
            ImageUrl = imageUrl;
            Content = content;
            Tags = tags;
            DateCreated = DateTime.Now;
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string ImageUrl { get; set; }

        public string Content { get; set; }

        public string[] Tags { get; set; }

        public DateTime DateCreated { get; set; }
    }
}