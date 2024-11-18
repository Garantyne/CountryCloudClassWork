using CountryCloud.model;
using Microsoft.EntityFrameworkCore;

namespace CountryCloud.db
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Country> Countrys { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();
            string useConnection = configuration.GetSection("UseConnection").Value ?? "DefaultConnection";
            string? connectionString = configuration.GetConnectionString(useConnection);
            optionsBuilder.UseNpgsql(connectionString);
        }
    }
}
