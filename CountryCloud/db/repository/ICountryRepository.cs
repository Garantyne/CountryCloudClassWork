using CountryCloud.model;

namespace CountryCloud.db.repository
{
    public interface ICountryRepository
    {
        Task<Country> AddAsync(Country country);

        void delete(int id);
        Task<Country> GetByIdAsync(int id);
        Task<List<Country>> GetAllAsync();
        Task<Country> GetByCode(string code);
        Task<bool> UpdateAsync(Country country);
        void DeleteAll();

    }
}
