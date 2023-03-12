using Microsoft.AspNetCore.Mvc;
using PieShop.HRM.Models.Domain;
using PieShop.HRM.Services.Interfaces;

namespace PieShop.HRM.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController : Controller
{
    private readonly IEmployeeService _employeeService;
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly IHttpContextAccessor _httpContextAccessor;
    public EmployeeController(IEmployeeService employeeService, IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor)
    {
        _employeeService = employeeService;
        _webHostEnvironment = webHostEnvironment;
        _httpContextAccessor = httpContextAccessor;
    }

    [HttpGet]
    public IActionResult GetAllEmployees() => Ok(_employeeService.GetAllEmployees());

    [HttpGet("{id}")]
    public IActionResult GetEmployeeById(int id) => Ok(_employeeService.GetEmployeeById(id));

    [HttpPost]
    public IActionResult CreateEmployee([FromBody] Employee employee)
    {
        if (employee == null)
            return BadRequest();

        if (employee.FirstName == string.Empty || employee.LastName == string.Empty)
        {
            ModelState.AddModelError("Name/FirstName", "The name or first name shouldn't be empty");
        }

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        //handle image upload
        string currentUrl = _httpContextAccessor.HttpContext.Request.Host.Value;
        var path = $"{_webHostEnvironment.WebRootPath}\\uploads\\{employee.ImageName}";
        var fileStream = System.IO.File.Create(path);
        fileStream.Write(employee.ImageContent, 0, employee.ImageContent.Length);
        fileStream.Close();

        employee.ImageName = $"https://{currentUrl}/uploads/{employee.ImageName}";

        var createdEmployee = _employeeService.AddEmployee(employee);

        return Created("employee", createdEmployee);
    }

    [HttpPut]
    public IActionResult UpdateEmployee([FromBody] Employee employee)
    {
        if (employee == null)
            return BadRequest();

        if (employee.FirstName == string.Empty || employee.LastName == string.Empty)
        {
            ModelState.AddModelError("Name/FirstName", "The name or first name shouldn't be empty");
        }

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var employeeToUpdate = _employeeService.GetEmployeeById(employee.EmployeeId);

        if (employeeToUpdate == null)
            return NotFound();

        _employeeService.UpdateEmployee(employee);

        return NoContent(); //success
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteEmployee(int id)
    {
        if (id == 0)
            return BadRequest();

        var employeeToDelete = _employeeService.GetEmployeeById(id);
        if (employeeToDelete == null)
            return NotFound();

        _employeeService.DeleteEmployee(id);

        return NoContent();//success
    }
}
