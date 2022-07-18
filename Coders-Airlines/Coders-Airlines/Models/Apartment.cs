using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coders_Airlines.Models
{
    public class Apartment
    {
        public int ID { get; set; }
        public string City { get; set; }
        public double RentalCost { get; set; }
        public string Description { get; set; }
        public bool IsAvailable { get; set; }
        public string Thumbnail { get; set; }
        public List<ApartmentImg> ImgURL { get; set; }
        public List<ApartmentRental> Rentals { get; set; }
    }
}
