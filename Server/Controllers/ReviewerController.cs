using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Data;
using Shared.Models;

namespace Server.Controllers
{
    [Route("api/data/[controller]")]
    [ApiController]
    public class ReviewerController : ControllerBase
    {
        private readonly DataContext _revContext;
        public ReviewerController(DataContext revContext)   //In order to Go to DB get the data.
        {
            _revContext = revContext;
        }

        [HttpGet]
        public ActionResult<List<Reviewer>> GetAllReviewers()
        {
            return Ok(_revContext.Reviewers);
        }

        [HttpGet("{id}")]
        public ActionResult<Reviewer> GetSingleReviewer(int id)
        {
            var reviewer = _revContext.Reviewers.FirstOrDefault(p => p.Id.Equals(id));

            if (reviewer == null)
            {
                return NotFound("This reviewer doesn't exist.");

            }

            return Ok(reviewer);
        }
    }
}
