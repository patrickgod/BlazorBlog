using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using BlazorBlog.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorBlog.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        public List<BlogPost> Posts { get; set; } = new List<BlogPost>
        {
            new BlogPost { Url = "new-tutorial", Title = "A New Tutorial about Blazor with Web API", Description = "This is a new tutorial, showing you how to build a blog with Blazor", Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Facilisi morbi tempus iaculis urna id volutpat lacus laoreet. Eget lorem dolor sed viverra ipsum nunc aliquet. Id aliquet lectus proin nibh nisl condimentum. Diam in arcu cursus euismod quis. Ac turpis egestas maecenas pharetra convallis posuere morbi leo urna. Convallis aenean et tortor at risus viverra adipiscing at. Fermentum posuere urna nec tincidunt praesent semper feugiat nibh. Arcu felis bibendum ut tristique et egestas quis ipsum suspendisse. Ante in nibh mauris cursus mattis."},
            new BlogPost { Url = "first-post", Title = "My First Blog Post with Web API", Description = "Hi! This is my new shiny blog. Enjoy!", Content = "This is my beautiful short blog post. Isn't it nice? :)"}
        };

        [HttpGet]
        public ActionResult<List<BlogPost>> GimmeAllTheBlogPosts()
        {
            return Ok(Posts);
        }

        [HttpGet("{url}")]
        public ActionResult<BlogPost> GimmeThatSingleBlogPost(string url)
        {
            var post = Posts.FirstOrDefault(p => p.Url.ToLower().Equals(url.ToLower()));
            if (post == null)
            {
                return NotFound("This post does not exist.");
            }

            return Ok(post);
        }
    }
}
