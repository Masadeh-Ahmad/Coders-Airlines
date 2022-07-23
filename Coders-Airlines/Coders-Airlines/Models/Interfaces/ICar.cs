using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coders_Airlines.Models.Interfaces
{
    public interface ICar
    {
        public Task<Car> CreateCar(Car car);

        public Task<Car> GetCar(int? id);

        public Task<List<Car>> GetCars();

        public Task<Car> UpdateCar(int? id, Car car);

        public Task DeleteCar(int? id);
    }
}
