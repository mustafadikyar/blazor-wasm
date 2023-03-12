using Microsoft.AspNetCore.Mvc;
using PieShop.HRM.Services.Interfaces;

namespace PieShop.HRM.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CountryController : Controller
{
    private readonly ICountryService _countryService;
    public CountryController(ICountryService countryService) => _countryService = countryService;

    [HttpGet]
    public IActionResult GetCountries() => Ok(_countryService.GetAllCountries());

    [HttpGet("{id}")]
    public IActionResult GetCountryById(int id) => Ok(_countryService.GetCountryById(id));
}
