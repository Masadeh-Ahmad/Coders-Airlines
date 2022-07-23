using Coders_Airlines.Auth.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coders_Airlines.Models
{
    public class CarRental
    {
        public int ID { get; set; }
        public int CarID { get; set; }
        public string UserId { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public double Price { get; set; }
        public Car Car { get; set; }
        public ApplicationUser User { get; set; }
    }
}
