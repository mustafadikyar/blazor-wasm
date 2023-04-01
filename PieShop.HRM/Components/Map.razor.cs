﻿using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using PieShop.HRM.Models;

namespace PieShop.HRM.Components;

public partial class Map
{
    string elementId = $"map-{Guid.NewGuid():D}";

    [Inject] public IJSRuntime JSRuntime { get; set; }
    [Parameter] public double Zoom { get; set; }
    [Parameter] public List<Marker> Markers { get; set; }

    protected async override Task OnAfterRenderAsync(bool firstRender) => await JSRuntime.InvokeVoidAsync("deliveryMap.showOrUpdate", elementId, Markers);
}