using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coders_Airlines.Models
{
    public class Car
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int ModelYear { get; set; }
        public double RentalCost { get; set; }
        public string City { get; set; }
        public int NumOfSeats { get; set; }
        public bool IsAvailable { get; set; }
    }
}
