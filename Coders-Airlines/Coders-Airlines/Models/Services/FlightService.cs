using Coders_Airlines.Data;
using Coders_Airlines.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coders_Airlines.Models.Services
{
    public class FlightService : IFlight
    {
        private readonly AirlinesDbContext _context;

        public FlightService(AirlinesDbContext context)
        {
            _context = context;
        }

        public async Task<Flight> CreateFlight(Flight flight)
        {
            _context.Entry(flight).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return flight;
        }

        public async Task<Flight> GetFlight(int? id)
        {
            return await _context.Flights.Where(x => x.ID == id).FirstOrDefaultAsync();
        }

        public async Task<List<Flight>> GetFlights()
        {
            return await _context.Flights.ToListAsync();
        }

        public async Task<Flight> UpdateFlight(int? id, Flight flight)
        {
            _context.Entry(flight).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return flight;
        }

        public async Task DeleteFlight(int? id)
        {
            Flight flight = await GetFlight(id);
            _context.Entry(flight).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}
