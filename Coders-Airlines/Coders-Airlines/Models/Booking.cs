using Coders_Airlines.Auth.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coders_Airlines.Models
{
    public class Booking
    {
        public int FlightID { get; set; }
        public string UserId { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public double TotalPrice { get; set; }

        public Flight Flight { get; set; }
        public ApplicationUser User { get; set; }
    }
}
