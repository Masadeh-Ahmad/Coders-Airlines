using Coders_Airlines.Data;
using Coders_Airlines.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coders_Airlines.Models.Services
{
    public class CountryServise : ICountry
    {
        private readonly AirlinesDbContext _context;

        public CountryServise(AirlinesDbContext context)
        {
            _context = context;
        }
        public async Task<List<City>> GetCities()
        {
            return await _context.City.ToListAsync();
        }
    }
}
