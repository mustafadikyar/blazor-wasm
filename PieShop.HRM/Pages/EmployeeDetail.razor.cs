using Microsoft.AspNetCore.Components;
using PieShop.HRM.Interfaces;
using PieShop.HRM.Models;
using PieShop.HRM.Models.Domain;

namespace PieShop.HRM.Pages;

public partial class EmployeeDetail
{
    [Inject] IEmployeeService? EmployeeService { get; set; }

    [Parameter] public string EmployeeId { get; set; }

    public Employee Employee { get; set; } = new Employee();

    protected override async Task OnInitializedAsync()
    {
        Employee = await EmployeeService.GetEmployeeById(int.Parse(EmployeeId));
    }
}
