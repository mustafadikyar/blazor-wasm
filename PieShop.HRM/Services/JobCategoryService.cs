using PieShop.HRM.Interfaces;
using PieShop.HRM.Models.Domain;
using System.Text.Json;

namespace PieShop.HRM.Services
{
    public class JobCategoryService : IJobCategoryService
    {
        private readonly HttpClient _httpClient;
        public JobCategoryService(HttpClient httpClient) => _httpClient = httpClient;

        public async Task<IEnumerable<JobCategory>> GetAllJobCategories()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<JobCategory>>
                (await _httpClient.GetStreamAsync($"api/jobcategory"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<JobCategory> GetJobCategoryById(int jobCategoryId)
        {
            return await JsonSerializer.DeserializeAsync<JobCategory>
                (await _httpClient.GetStreamAsync($"api/jobcategory/{jobCategoryId}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
    }
}
