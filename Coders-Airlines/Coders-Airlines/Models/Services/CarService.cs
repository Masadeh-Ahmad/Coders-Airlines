using Coders_Airlines.Data;
using Coders_Airlines.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coders_Airlines.Models.Services
{
    public class CarService : ICar
    {
        private readonly AirlinesDbContext _context;

        public CarService(AirlinesDbContext context)
        {
            _context = context;
        }

        public async Task<Car> CreateCar(Car car)
        {
            _context.Entry(car).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return car;
        }

        public async Task<Car> GetCar(int? id)
        {
            return await _context.Cars.Where(x => x.ID == id).FirstOrDefaultAsync();
        }

        public async Task<List<Car>> GetCars()
        {
            return await _context.Cars.ToListAsync();
        }

        public async Task<Car> UpdateCar(int? id, Car car)
        {
            _context.Entry(car).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return car;
        }

        public async Task DeleteCar(int? id)
        {
            Car car = await GetCar(id);
            _context.Entry(car).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<List<Car>> RandomCar()
        {
            List<Car> Randoms = new List<Car>();
            List<Car> Cars = await GetCars();
            Random Rnd = new Random();

            for (int i = 0; i < 4; i++)
            {
                Randoms.Add(Cars[Rnd.Next(0, Cars.Count - 1)]);
            }
            return Randoms;
        }
        public async Task AddImg(CarImg carImg)
        {
            _context.CarImgs.Add(carImg);
            await _context.SaveChangesAsync();
        }

        public async Task<List<CarImg>> GetImgs(int ?id)
        {
            return await _context.CarImgs.Where(x => x.CarID == id).ToListAsync();
        }
    }
}
