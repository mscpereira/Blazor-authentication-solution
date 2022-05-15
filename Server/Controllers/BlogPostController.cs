using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Shared.Models;

namespace Server.Controllers
{
    [Route("api/data/[controller]")]
    [ApiController]
    public class BlogPostController : ControllerBase
    {
        //In order to Go to DB get the data.
        private readonly DataContext _bPostContext;
        public BlogPostController(DataContext bPostContext)   //In order to Go to DB get the data.
        {
            _bPostContext = bPostContext;
        }

        [HttpGet]
        public ActionResult<List<BlogPost>> GetAllBlogPosts()
        {
            object post = _bPostContext.BlogPosts.Include(list => list.Reviewers).ToList();
            return Ok(post);
        }


        [HttpGet("{url}")]
        public ActionResult<BlogPost> GetSingleBlogPost(string url)
        {
            var post = _bPostContext.BlogPosts
                .Include(list => list.Reviewers).ToList()
                .FirstOrDefault(p => p.Url.ToLower().Equals(url.ToLower()));

            if (post == null)
            {
                return NotFound("This post doesn't exist.");

            }

            return Ok(post);
        }

        [HttpPost]
        public async Task<ActionResult<BlogPost>> CrateNewBlogPost(BlogPost request)
        {
            _bPostContext.Add(request);
            await _bPostContext.SaveChangesAsync();
            return request;
        }
    }
}
