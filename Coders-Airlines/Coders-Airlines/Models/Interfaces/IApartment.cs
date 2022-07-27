using Coders_Airlines.Pages.Cars;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coders_Airlines.Models.Interfaces
{
    public interface IApartment
    {
        public Task<Apartment> CreateApartment(Apartment apartment);

        public Task<Apartment> GetApartment(int? id);

        public Task<List<Apartment>> GetApartments();

        public Task<Apartment> UpdateApartment(int? id, Apartment apartment);

        public Task DeleteApartment(int? id);
        public Task<List<Apartment>> RandomApartment();
        public Task<List<Apartment>> GetApartOnTime(Filter filter);
        public Task<List<ApartmentImg>> GetImgs(int? id);
        public Task AddImg(ApartmentImg apartmentImg);

    }
}
