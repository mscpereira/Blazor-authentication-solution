
using Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorWASMAuthentication.Client.Services
{
    public interface IReviewerService
    {
        Task<List<Reviewer>> GetReviewers();
        Task<Reviewer> GetReviewerById(int id);
    }
}
