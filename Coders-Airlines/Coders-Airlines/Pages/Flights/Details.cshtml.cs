using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Coders_Airlines.Data;
using Coders_Airlines.Models;
using Coders_Airlines.Models.Interfaces;
using Coders_Airlines.Auth.Interfaces;

namespace Coders_Airlines.Pages.Flights
{
    public class DetailsModel : PageModel
    {
        private readonly IFlight _flight;
        private readonly ICar _car;
        private readonly AirlinesDbContext _context;
        private IUser _userService;

        public List<Car> items { get; set; }

        public DetailsModel(IFlight flight, ICar car , AirlinesDbContext context, IUser user)
        {
            _flight = flight;
            _car = car;
            _context = context;
            _userService = user;
            Rent = false;
        }

        public Flight Flight { get; set; }
        [BindProperty]
        public Booking Booking { get; set; }
        public bool Rent { get; set; }


        public async Task<IActionResult> OnGetAsync(int? id, int? rent)
        {
            if (id == null)
            {
                return NotFound();
            }

            Flight = await _flight.GetFlight(id);
            items = await _car.RandomCar();
            if (Flight == null)
            {
                return NotFound();
            }
            if (rent != null)
            {
                Rent = true;
            }

            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            await OnPostCheck(id);

            _context.Bookings.Add(Booking);
            await _context.SaveChangesAsync();

            Flight flight = await _context.Flights.FirstOrDefaultAsync(m => m.ID == id);
            flight.SeatsLeft -= Booking.NumOfSeats;
            _context.Entry(flight).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
        public async Task<IActionResult> OnPostCheck(int? id)
        {
            await OnGetAsync(id,1);

            if (Flight.SeatsLeft < Booking.NumOfSeats || Booking.NumOfSeats < 0)
            {
                Flight.Price = 0;
                return Page();
            }
            Booking.TotalPrice = ((int)Booking.NumOfBags * Flight.Price / 4) + (Flight.Price * Booking.NumOfSeats);
            Booking.FlightID = Flight.ID;
            var user = await _userService.GetUser();
            Booking.UserId = user.Id;
            return Page();
        }
    }
}
