using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coders_Airlines.Models.Interfaces
{
    public interface ICountry
    {
        public Task<List<City>> GetCities();
    }
}
