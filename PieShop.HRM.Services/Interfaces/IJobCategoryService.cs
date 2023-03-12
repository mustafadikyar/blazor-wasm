using PieShop.HRM.Models.Domain;

namespace PieShop.HRM.Services.Interfaces;

public interface IJobCategoryService
{
    IEnumerable<JobCategory> GetAllJobCategories();
    JobCategory GetJobCategoryById(int jobCategoryId);
}
