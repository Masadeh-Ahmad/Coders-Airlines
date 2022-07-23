using Coders_Airlines.Auth.Interfaces;
using Coders_Airlines.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Coders_Airlines.Pages.Flights
{
    public class BookingModel : PageModel
    {
        private readonly Coders_Airlines.Data.AirlinesDbContext _context;
        private IUser _userService;

        public BookingModel(Data.AirlinesDbContext context, IUser user)
        {
            _context = context;
            _userService = user;
        }

        public Flight Flight { get; set; }
        [BindProperty]
        public Booking Booking { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Flight = await _context.Flights.FirstOrDefaultAsync(m => m.ID == id);

            if (Flight == null)
            {
                return NotFound();
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
            await OnGetAsync(id);

            if (Flight.SeatsLeft < Booking.NumOfSeats || Booking.NumOfSeats<0)
            {
                Flight.Price = 0;
                return Page();
            }
            Booking.TotalPrice = ((int)Booking.NumOfBags * Flight.Price/4) +( Flight.Price * Booking.NumOfSeats) ;
            Booking.FlightID = Flight.ID;
            var user = await _userService.GetUser();
            Booking.UserId = user.Id;
            return Page();
        }
    }
}
