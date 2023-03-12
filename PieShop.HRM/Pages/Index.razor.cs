using PieShop.HRM.Components.Widgets;

namespace PieShop.HRM.Pages;

public partial class Index
{
    public List<Type> Widgets { get; set; } = new List<Type>() {
        typeof(EmployeeCountWidget),
        typeof(InboxWidget)
    };
}
