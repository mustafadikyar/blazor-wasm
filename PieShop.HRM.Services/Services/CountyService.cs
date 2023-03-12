using PieShop.HRM.Models.Domain;
using PieShop.HRM.Services.Contexts;
using PieShop.HRM.Services.Interfaces;

namespace PieShop.HRM.Services.Services
{
    public class CountyService : ICountryService
    {
        private readonly AppDbContext _appDbContext;
        public CountyService(AppDbContext appDbContext) => _appDbContext = appDbContext;

        public IEnumerable<Country> GetAllCountries() => _appDbContext.Countries;
        public Country GetCountryById(int countryId) => _appDbContext.Countries.FirstOrDefault(c => c.CountryId == countryId);
    }
}
