using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coders_Airlines.Models
{

    public enum Type
    {
        CompactSedan,
        Sedan,
        Hatchback,
        SUV
    }
    public enum Fuel
    {
        Gasoline,
        Hybrid,
        Electric
    }

    public class Car
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int ModelYear { get; set; }
        public Type Type { get; set; }
        public Fuel FuelType { get; set; }
        public double RentalCost { get; set; }
        public string City { get; set; }
        public string Description { get; set; }
        public bool IsAvailable { get; set; }
        public string Thumbnail { get; set; }
        public List<CarImg> ImgURL { get; set; }
        public List<CarRental> Rentals { get; set; }
    }
}
