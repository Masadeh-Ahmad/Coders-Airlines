using Coders_Airlines.Data;
using Coders_Airlines.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coders_Airlines.Models.Services
{
    public class ApartmentService : IApartment
    {
        private readonly AirlinesDbContext _context;

        public ApartmentService(AirlinesDbContext context)
        {
            _context = context;
        }

        public async Task<Apartment> CreateApartment(Apartment apartment)
        {
            _context.Entry(apartment).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return apartment;
        }

        public async Task<Apartment> GetApartment(int? id)
        {
            return await _context.Apartments.Where(x => x.ID == id).FirstOrDefaultAsync();
        }

        public async Task<List<Apartment>> GetApartments()
        {
            return await _context.Apartments.ToListAsync();
        }

        public async Task<Apartment> UpdateApartment(int? id, Apartment apartment)
        {
            _context.Entry(apartment).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return apartment;
        }

        public async Task DeleteApartment(int? id)
        {
            Apartment apartment = await GetApartment(id);
            _context.Entry(apartment).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<List<Apartment>> RandomApartment()
        {
            List<Apartment> Randoms = new List<Apartment>();
            List<Apartment> Cars = await GetApartments();
            Random Rnd = new Random();

            for (int i = 0; i < 4; i++)
            {
                Randoms.Add(Cars[Rnd.Next(0, Cars.Count - 1)]);
            }
            return Randoms;
        }
    }
}
