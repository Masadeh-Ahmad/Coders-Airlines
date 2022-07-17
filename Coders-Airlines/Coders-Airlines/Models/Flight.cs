using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coders_Airlines.Models
{
    public class Flight
    {
        public int ID { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ArrivalDate { get; set; }
        public int NumOfBags { get; set; }
        public string ClassType { get; set; }
        public double Price { get; set; }
    }
}