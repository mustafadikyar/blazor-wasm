using Microsoft.AspNetCore.Components;
using PieShop.HRM.Models.Domain;

namespace PieShop.HRM.Components;

public partial class EmployeeCard
{
    [Parameter] public Employee Employee { get; set; } = default!;

    [Parameter] public EventCallback<Employee> EmployeeQuickView_Clicked { get; set; }

    [Inject] public NavigationManager NavigationManager { get; set; }

    public void NavigateToDetails(Employee selectedEmployee) 
        => NavigationManager.NavigateTo($"/employeedetail/{selectedEmployee.EmployeeId}");

    protected override void OnInitialized()
    {
        if (string.IsNullOrEmpty(Employee.LastName))
        {
            throw new Exception($"Last name can't be empty! The record id is {Employee.EmployeeId}");
        }
    }
}