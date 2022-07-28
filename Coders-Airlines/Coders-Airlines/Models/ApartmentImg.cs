using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coders_Airlines.Models
{
    public class ApartmentImg
    {
        public int ID { get; set; }
        public int ApartmentID {get;set;}
        public string URL { get; set; }
        
        public Apartment Apartment { get; set; }
    }
}
