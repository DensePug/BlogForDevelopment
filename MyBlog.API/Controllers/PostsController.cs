using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MyBlog.API.DataContracts;
using MyBlog.API.Helpers;
using System.Collections.Generic;
using System.Linq;
using System;

namespace MyBlog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        public BlogContext Context { get; }

        public PostsController(BlogContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult Get(int postCount = 10, int page = 1)
        {
            var pageCount = (int)Math.Ceiling((decimal)(Context.Posts.Count() / postCount));
            return Ok(new PostsResponse { pageCount = pageCount, Posts = Context.Posts.OrderByDescending(p => p.DateCreated).Skip((page - 1) * postCount).Take(postCount).ToArray() });
        }

        [HttpGet("{id}")]
        public IActionResult GetPost(int id)
        {
            Post result = Context.Posts.FirstOrDefault(p => p.Id == id);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPatch]
        [Route("like")]
        public IActionResult Like(LikeRequest request)
        {
            Post postToLike = Context.Posts.FirstOrDefault(p => p.Id == request.PostId);
            if (postToLike == null)
                return NotFound();

            if (postToLike.DateLoggedInUserLiked != null && postToLike.DateLoggedInUserLiked.Contains(request.DateUserLoggedInLiked))
                return NoContent();

            postToLike.LikeCount++;

            if (postToLike.DateLoggedInUserLiked == null)
                postToLike.DateLoggedInUserLiked = new List<long>();

            postToLike.DateLoggedInUserLiked.Add(request.DateUserLoggedInLiked);

            Context.SaveChanges();
            return Ok();
        }

        [HttpGet]
        [Route("likeCount")]
        public IActionResult GetLikeCount(int postId)
        {
            Post post = Context.Posts.FirstOrDefault(p => p.Id == postId);
            if (post == null)
                return NotFound();

            return Ok(post.LikeCount);
        }

        [HttpPost]
        public IActionResult CreatePost(Post post)
        {
            EntityEntry<Post> entry = Context.Posts.Add(post);
            Post result = entry?.Entity;

            Context.SaveChanges();

            return Ok(result);
        }

        [HttpDelete]
        public IActionResult DeletePost(int id)
        {
            Post toDelete = Context.Posts.FirstOrDefault(p => p.Id == id);
            if (toDelete == null)
                return NotFound();

            Context.Posts.Remove(toDelete);

            Context.SaveChanges();

            return Ok(toDelete);
        }

        [HttpPut]
        public IActionResult UpdatePost(Post post)
        {
            Post toChange = Context.Posts.FirstOrDefault(p => p.Id == post.Id);
            if (toChange == null)
                return NotFound();

            Context.Posts.Remove(toChange);

            EntityEntry<Post> entry = Context.Posts.Add(post);

            Context.SaveChanges();

            Post result = entry?.Entity;

            return Ok(result);
        }
    }
}