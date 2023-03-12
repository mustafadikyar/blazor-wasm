using Microsoft.AspNetCore.Components;
using PieShop.HRM.Interfaces;
using PieShop.HRM.Models;
using PieShop.HRM.Models.Domain;
using System.Net.Http.Json;

namespace PieShop.HRM.Pages;

public partial class EmployeeOverview
{
    [Inject] IEmployeeService? EmployeeService { get; set; }
    public List<Employee> Employees { get; set; } = default!;

    private Employee? _selectedEmployee;
    private string Title = "Employee overview";


    protected override async Task OnInitializedAsync()
    {
        Employees = (await EmployeeService.GetAllEmployees()).ToList();
    }

    public void ShowQuickViewPopup(Employee selectedEmployee) => _selectedEmployee = selectedEmployee;

}