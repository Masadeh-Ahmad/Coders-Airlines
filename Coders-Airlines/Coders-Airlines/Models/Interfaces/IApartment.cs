using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coders_Airlines.Models.Interfaces
{
    public interface IApartment
    {
        public Task<Apartment> CreateApartment(Apartment apartment);

        public Task<Apartment> GetApartment(int id);

        public Task<List<Apartment>> GetApartments();

        public Task<Apartment> UpdateApartment(int id, Apartment apartment);

        public Task DeleteApartment(int id);
    }
}
