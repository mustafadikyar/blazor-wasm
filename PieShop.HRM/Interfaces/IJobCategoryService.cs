using PieShop.HRM.Models.Domain;

namespace PieShop.HRM.Interfaces;

public interface IJobCategoryService
{
    Task<IEnumerable<JobCategory>> GetAllJobCategories();
    Task<JobCategory> GetJobCategoryById(int jobCategoryId);
}
