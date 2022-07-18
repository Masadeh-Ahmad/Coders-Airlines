using Coders_Airlines.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coders_Airlines.Auth.Model
{
    public class ApplicationUser : IdentityUser
    {
        public List<Booking> Bookings { get; set; }

        public List<CarRental> CarRentals { get; set; }
        public List<ApartmentRental> ApartmentRentals { get; set; }

    }
}
