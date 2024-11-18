using CountryCloud.db.repository;
using CountryCloud.model;
using Microsoft.AspNetCore.Mvc;

namespace CountryCloud.controllers
{
    [Route("/country")]
    [ApiController]
    public class CountryController
    {
        public ICountryRepository countryRepository { get; set; }
        public CountryController(ICountryRepository countryRepository)
        {
            this.countryRepository = countryRepository;
        }

        [HttpGet]
        public async Task<List<Country>> ListAll()
        {
            return await countryRepository.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<Country> GetById(int id)
        {
            return await countryRepository.GetByIdAsync(id);
        }
        [HttpGet("/country/code/{code}")]
        public async Task<Country> GetByCode(string code)
        {
            return await countryRepository.GetByCode(code);
        }
        [HttpPatch]
        public async Task<bool> Update(Country country)
        {
            return await countryRepository.UpdateAsync(country);
        }
        [HttpDelete]
        public void DeleteAll()
        {
            countryRepository.DeleteAll();
        }
        [HttpPost]
        public async Task<Country> Add(Country country)
        {
            return await countryRepository.AddAsync(country);
        }
    }
}
