using CountryCloud.model;
using Microsoft.EntityFrameworkCore;

namespace CountryCloud.db.repository
{
    public class PostgresCountryDb : ICountryRepository
    {
        public ApplicationContext Context { get; set; }

        public PostgresCountryDb(ApplicationContext context) { 
            Context = context; 
        }

        public async Task<Country> AddAsync(Country country)
        {
            Country countryDb = new Country()
            {
                FullName = country.FullName,
                ShortName = country.ShortName,
                alpha2code = country.alpha2code
            };
            await Context.Countrys.AddAsync(countryDb);
            await Context.SaveChangesAsync();
            return countryDb;
        }

        public void delete(int id)
        {
            Country c = Context.Countrys.FirstOrDefault(t=>t.Id == id);
            if (c != null)
            {
                Context.Countrys.Remove(c);
                Context.SaveChanges();
            }
            else
            {
                throw new ArgumentNullException($"Объект с id - {id} не найден");
            }
        }

        public async Task<List<Country>> GetAllAsync()
        {
            List<Country> ctry = await Context.Countrys.ToListAsync();
            return ctry;
        }

        public async Task<Country> GetByIdAsync(int id)
        {
            Country couontr = await Context.Countrys.FirstOrDefaultAsync(c=>c.Id == id);
            if (couontr != null)
            {
                return couontr;
            }
            else
            {
                throw new ArgumentNullException($"Объект с id - {id} не найден");
            }
        }

        public async Task<Country> GetByCode(string code)
        {
            Country country = await Context.Countrys.FirstOrDefaultAsync(c=>c.alpha2code == code);
            if (country != null)
            {
                return country;
            }
            else
            {
                throw new ArgumentNullException($"Объект с кодом - {code} не найден");
            }
        }

        public async Task<bool> UpdateAsync(Country country)
        {
            Country country1 = await Context.Countrys.FirstOrDefaultAsync(c=>c.Id==country.Id);
            if (country1 != null) 
            {
                country1.FullName = country.FullName;
                country1.ShortName = country.ShortName;
                country1.alpha2code = country.alpha2code;
                Context.SaveChanges();
                return true;
            }
            else
            {
                throw new ArgumentNullException($"Объект с id - {country.Id} не найден");
            }
        }

        public void DeleteAll()
        {
            Context.Database.ExecuteSqlRaw("Delete from \"Countrys\"");
            Context.SaveChanges();
        }
    }
}
