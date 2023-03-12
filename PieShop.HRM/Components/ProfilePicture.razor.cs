using Microsoft.AspNetCore.Components;

namespace PieShop.HRM.Components;

public partial class ProfilePicture
{
    [Parameter] public RenderFragment? ChildContent { get; set; }
}
