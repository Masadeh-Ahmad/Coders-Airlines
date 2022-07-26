using Coders_Airlines.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coders_Airlines.Pages.Profile
{
    public class ApartmentHistoryModel : PageModel
    {
        private readonly Coders_Airlines.Data.AirlinesDbContext _context;

        public ApartmentHistoryModel(Coders_Airlines.Data.AirlinesDbContext context)
        {
            _context = context;
        }

        public IList<ApartmentRental> ApartmentRental { get; set; }

        public async Task OnGetAsync(string username)
        {
            ApartmentRental = await _context.ApartmentRentals
                .Where(a => a.User.UserName == username)
                .Include(a => a.Apartment)
                .Include(a => a.User).ToListAsync();
        }
    }
}
