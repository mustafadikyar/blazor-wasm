using Microsoft.AspNetCore.Components;
using PieShop.HRM.Models.Domain;

namespace PieShop.HRM.Components;

public partial class QuickViewPopup
{
    private Employee? _employee;

    [Parameter] public Employee? Employee { get; set; }
    
    protected override void OnParametersSet() => _employee = Employee;
    
    public void Close() => _employee = null;

}
