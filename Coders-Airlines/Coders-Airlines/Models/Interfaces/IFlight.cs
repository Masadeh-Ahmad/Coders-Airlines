using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coders_Airlines.Models.Interfaces
{
    public interface IFlight
    {
        public Task<Flight> CreateFlight(Flight flight);

        public Task<Flight> GetFlight(int? id);

        public Task<List<Flight>> GetFlights();

        public Task<Flight> UpdateFlight(int? id, Flight flight);

        public Task DeleteFlight(int? id);
    }
}
