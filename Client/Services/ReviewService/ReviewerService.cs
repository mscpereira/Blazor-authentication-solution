using Shared.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorWASMAuthentication.Client.Services
{
    public class ReviewerService : IReviewerService
    {
        private readonly HttpClient _http;
        public ReviewerService(HttpClient http)
        {
            _http = http;
        }
        public async Task<Reviewer> GetReviewerById(int id)
        {

            //Update this methodto react to a 404
            var result = await _http.GetAsync($"api/data/reviewer/{id}");
            if (result.StatusCode != System.Net.HttpStatusCode.OK)
            {
                var message = await result.Content.ReadAsStringAsync();
                Console.WriteLine(message);
                return new Reviewer { FirstName = message };
            }
            else
            {
                return await result.Content.ReadFromJsonAsync<Reviewer>();
            }
        }

        public async Task<List<Reviewer>> GetReviewers()
        {
            return await _http.GetFromJsonAsync<List<Reviewer>>("api/data/reviewer");
        }
    }
}
