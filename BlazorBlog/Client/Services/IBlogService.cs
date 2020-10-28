using BlazorBlog.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorBlog.Client.Services
{
    interface IBlogService
    {
        List<BlogPost> GetBlogPosts();
        BlogPost GetBlogPostByUrl(string url);
    }
}
