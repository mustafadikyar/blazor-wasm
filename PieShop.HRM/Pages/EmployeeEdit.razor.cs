using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using PieShop.HRM.Interfaces;
using PieShop.HRM.Models.Domain;

namespace PieShop.HRM.Pages;

public partial class EmployeeEdit
{
    [Inject] public NavigationManager NavigationManager { get; set; }

    [Inject] public IEmployeeService EmployeeService { get; set; }
    [Inject] public ICountryService CountryService { get; set; }
    [Inject] public IJobCategoryService JobCategoryService { get; set; }

    [Parameter] public string? EmployeeId { get; set; }

    public Employee Employee { get; set; } = new Employee();
    public List<Country> Countries { get; set; } = new List<Country>();
    public List<JobCategory> JobCategories { get; set; } = new List<JobCategory>();

    protected string Message = string.Empty;
    protected string StatusClass = string.Empty;
    protected bool Saved;

    private IBrowserFile selectedFile;

    protected override async Task OnInitializedAsync()
    {
        Saved = false;
        Countries = (await CountryService.GetAllCountries()).ToList();
        JobCategories = (await JobCategoryService.GetAllJobCategories()).ToList();

        int.TryParse(EmployeeId, out var employeeId);

        if (employeeId == 0) //new employee is being created
        {
            //add some defaults
            Employee = new Employee { CountryId = 1, JobCategoryId = 1, BirthDate = DateTime.Now, JoinedDate = DateTime.Now };
        }
        else
        {
            Employee = await EmployeeService.GetEmployeeById(int.Parse(EmployeeId));
        }
    }

    private void OnInputFileChange(InputFileChangeEventArgs e)
    {
        selectedFile = e.File;
        StateHasChanged();
    }

    protected async Task HandleValidSubmit()
    {
        Saved = false;

        if (Employee.EmployeeId == 0) //new
        {
            //image adding
            if (selectedFile != null)//take first image
            {
                var file = selectedFile;
                Stream stream = file.OpenReadStream();
                MemoryStream ms = new();
                await stream.CopyToAsync(ms);
                stream.Close();

                Employee.ImageName = file.Name;
                Employee.ImageContent = ms.ToArray();
            }

            var addedEmployee = await EmployeeService.AddEmployee(Employee);
            if (addedEmployee != null)
            {
                StatusClass = "alert-success";
                Message = "New employee added successfully.";
                Saved = true;
            }
            else
            {
                StatusClass = "alert-danger";
                Message = "Something went wrong adding the new employee. Please try again.";
                Saved = false;
            }
        }
        else
        {
            await EmployeeService.UpdateEmployee(Employee);
            StatusClass = "alert-success";
            Message = "Employee updated successfully.";
            Saved = true;
        }
    }

    protected async Task HandleInvalidSubmit()
    {
        StatusClass = "alert-danger";
        Message = "There are some validation errors. Please try again.";
    }

    protected async Task DeleteEmployee()
    {
        await EmployeeService.DeleteEmployee(Employee.EmployeeId);

        StatusClass = "alert-success";
        Message = "Deleted successfully";

        Saved = true;
    }

    protected void NavigateToOverview() => NavigationManager.NavigateTo("/employeeoverview");
}
