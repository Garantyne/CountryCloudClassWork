using Microsoft.EntityFrameworkCore;

namespace CountryCloud.model
{
    [Index(nameof(alpha2code),IsUnique=true)]
    public class Country
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string ShortName { get; set; } = string.Empty;

        public string alpha2code { get; set; } 
    }
}
