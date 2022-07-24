using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Coders_Airlines.Data;
using Coders_Airlines.Models;

namespace Coders_Airlines.Pages.Admin
{
    public class AdminFlightBookingListModel : PageModel
    {
        private readonly Coders_Airlines.Data.AirlinesDbContext _context;

        public AdminFlightBookingListModel(Coders_Airlines.Data.AirlinesDbContext context)
        {
            _context = context;
        }

        public IList<Booking> Booking { get;set; }

        public async Task OnGetAsync()
        {
            Booking = await _context.Bookings
                .Include(b => b.Flight)
                .Include(b => b.User).ToListAsync();
        }
        public async Task OnGetDate(DateTime from, DateTime to)
        {
            Booking = await _context.Bookings
                .Where(b => b.Flight.DepartureDate > from && b.Flight.DepartureDate < to)
                .Include(b => b.Flight)
                .Include(b => b.User).ToListAsync();
        }
        public async Task<IActionResult> OnPostAsync(DateTime dateFrom, DateTime dateTo)
        {
            return RedirectToPage("AdminFlightBookingList", "Date", new { from = dateFrom, to = dateTo });
        }
    }
}
