using System;
using System.Collections.Generic;

namespace MyBlog.API.DataContracts
{
    public class Post
    {
        public Post(string title, string imageUrl, string content, string previewContent, params string[] tags)
        {
            Title = title;
            ImageUrl = imageUrl;
            Content = content;
            Tags = tags;
            PreviewContent = previewContent;
            DateCreated = DateTime.Now;
            LikeCount = 0;
            DateLoggedInUserLiked = new List<long>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string ImageUrl { get; set; }

        public string Content { get; set; }

        public string[] Tags { get; set; }

        public string PreviewContent { get; set; }

        public DateTime DateCreated { get; set; }

        public int LikeCount { get; set; }

        public List<long> DateLoggedInUserLiked { get; set; } = new List<long>();
    }
}