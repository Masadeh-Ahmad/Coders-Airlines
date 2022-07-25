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
    public class AdminApartmentRentalModel : PageModel
    {
        private readonly Coders_Airlines.Data.AirlinesDbContext _context;

        public AdminApartmentRentalModel(Coders_Airlines.Data.AirlinesDbContext context)
        {
            _context = context;
        }

        public IList<ApartmentRental> ApartmentRental { get;set; }

        public async Task OnGetAsync()
        {
            ApartmentRental = await _context.ApartmentRentals
                .Include(a => a.Apartment)
                .Include(a => a.User).ToListAsync();
        }
        public async Task OnGetDate(DateTime from, DateTime to)
        {
            ApartmentRental = await _context.ApartmentRentals
                .Where(a => a.From > from && a.From < to)
                .Include(a => a.Apartment)
                .Include(a => a.User).ToListAsync();
        }
        public async Task<IActionResult> OnPostAsync(DateTime dateFrom, DateTime dateTo)
        {
            return RedirectToPage("AdminApartmentRental", "Date", new { from = dateFrom, to = dateTo });
        }
    }
}
