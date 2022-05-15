using Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorWASMAuthentication.Client.Services
{
    interface IBlogPostService
    {
        Task<List<BlogPost>> GetBlogPosts();
        Task<BlogPost> GetBlogPostByUrl(string url);
        Task<BlogPost> CreateNewBlogPost(BlogPost request);
    }
}
