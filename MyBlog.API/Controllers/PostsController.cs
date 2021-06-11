using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MyBlog.API.DataContracts;
using MyBlog.API.Helpers;
using System.Collections.Generic;
using System.Linq;

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
        public IActionResult Get()
        {
            return Ok(Context.Posts.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetPost(int id)
        {
            Post result = Context.Posts.FirstOrDefault(p => p.Id == id);
            if (result == null)
                return NotFound();

            return Ok(result);
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