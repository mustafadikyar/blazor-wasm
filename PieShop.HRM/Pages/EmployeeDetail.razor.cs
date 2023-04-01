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

    public List<Marker> MapMarkers { get; set; } = new List<Marker>();

    protected override async Task OnInitializedAsync()
    {
        Employee = await EmployeeService.GetEmployeeById(int.Parse(EmployeeId));

        if (Employee.Longitude.HasValue && Employee.Latitude.HasValue)
        {
            MapMarkers = new List<Marker>
            {
                new Marker
                {
                    Description = $"{Employee.FirstName} {Employee.LastName}",
                    ShowPopup = false,
                    X = Employee.Longitude.Value,
                    Y = Employee.Latitude.Value
                }
            };
        }
    }
}
