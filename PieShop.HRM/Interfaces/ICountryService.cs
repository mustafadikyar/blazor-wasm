using PieShop.HRM.Models.Domain;

namespace PieShop.HRM.Interfaces;

public interface ICountryService
{
    Task<IEnumerable<Country>> GetAllCountries();
    Task<Country> GetCountryById(int countryId);
}
