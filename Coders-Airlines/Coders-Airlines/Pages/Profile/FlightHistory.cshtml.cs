using Coders_Airlines.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coders_Airlines.Pages.Profile
{
    public class FlightHistoryModel : PageModel
    {
        private readonly Coders_Airlines.Data.AirlinesDbContext _context;

        public FlightHistoryModel(Coders_Airlines.Data.AirlinesDbContext context)
        {
            _context = context;
        }

        public IList<Booking> Booking { get; set; }

        public async Task OnGetAsync(string username)
        {
            Booking = await _context.Bookings
                .Where(b => b.User.UserName == username)
                .Include(b => b.Flight)
                .ToListAsync();
        }
        
    }
}
