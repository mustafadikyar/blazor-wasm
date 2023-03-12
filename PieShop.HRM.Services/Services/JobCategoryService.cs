using PieShop.HRM.Models.Domain;
using PieShop.HRM.Services.Contexts;
using PieShop.HRM.Services.Interfaces;

namespace PieShop.HRM.Services.Services;

public class JobCategoryService : IJobCategoryService
{
    private readonly AppDbContext _appDbContext;
    public JobCategoryService(AppDbContext appDbContext) => _appDbContext = appDbContext;

    public IEnumerable<JobCategory> GetAllJobCategories() => _appDbContext.JobCategories;

    public JobCategory GetJobCategoryById(int jobCategoryId) 
        => _appDbContext.JobCategories.FirstOrDefault(c => c.JobCategoryId == jobCategoryId);
}
