using BlazorBlog.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorBlog.Client.Services
{
    public class BlogService : IBlogService
    {
        private readonly HttpClient _http;

        public BlogService(HttpClient http)
        {
            _http = http;
        }

        public async Task<BlogPost> CreateNewBlogPost(BlogPost request)
        {
            var result = await _http.PostAsJsonAsync("api/Blog", request);
            return await result.Content.ReadFromJsonAsync<BlogPost>();
        }

        public async Task<BlogPost> GetBlogPostByUrl(string url)
        {
            //var post = await _http.GetFromJsonAsync<BlogPost>($"api/Blog/{url}");
            //return post;

            var result = await _http.GetAsync($"api/Blog/{url}");
            if (result.StatusCode != System.Net.HttpStatusCode.OK)
            {
                var message = await result.Content.ReadAsStringAsync();
                Console.WriteLine(message);
                return new BlogPost { Title = message };
            }
            else
            {
                return await result.Content.ReadFromJsonAsync<BlogPost>();
            }
        }

        public async Task<List<BlogPost>> GetBlogPosts()
        {
            return await _http.GetFromJsonAsync<List<BlogPost>>("api/Blog");
        }
    }
}
