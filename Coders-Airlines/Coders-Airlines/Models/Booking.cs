using Coders_Airlines.Auth.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coders_Airlines.Models
{
    public enum Luggage
    {
        One=1,
        Two=2,
        Three=3
    }
    public class Booking
    {
        public int ID { get; set; }
        public int FlightID { get; set; }
        public string UserId { get; set; }
        public int NumOfSeats { get; set; }
        public Luggage NumOfBags { get; set; }
        public double TotalPrice { get; set; }
        public Flight Flight { get; set; }
        public ApplicationUser User { get; set; }
    }
}