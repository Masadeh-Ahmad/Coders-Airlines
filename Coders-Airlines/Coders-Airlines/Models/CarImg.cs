using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coders_Airlines.Models
{
    public class CarImg
    {
        public int ID { get; set; }
        public int CarID { get; set; }
        public string URL { get; set; }

        public Car Car { get; set; }
    }
}
