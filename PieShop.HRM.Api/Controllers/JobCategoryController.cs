using Microsoft.AspNetCore.Mvc;
using PieShop.HRM.Services.Interfaces;

namespace PieShop.HRM.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class JobCategoryController : Controller
{
    private readonly IJobCategoryService _jobCategoryService;
    public JobCategoryController(IJobCategoryService jobCategoryService) => _jobCategoryService = jobCategoryService;

    [HttpGet]
    public IActionResult GetJobCategories() => Ok(_jobCategoryService.GetAllJobCategories());

    [HttpGet("{id}")]
    public IActionResult GetJobCategoryById(int id) => Ok(_jobCategoryService.GetJobCategoryById(id));
}
