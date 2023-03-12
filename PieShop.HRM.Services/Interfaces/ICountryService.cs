using PieShop.HRM.Models.Domain;

namespace PieShop.HRM.Services.Interfaces;

public interface ICountryService
{
    IEnumerable<Country> GetAllCountries();
    Country GetCountryById(int countryId);
}
