using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Coders_Airlines.Data;
using Coders_Airlines.Models;

namespace Coders_Airlines.Pages.Admin.RentedApartments
{
    public class DeleteModel : PageModel
    {
        private readonly Coders_Airlines.Data.AirlinesDbContext _context;

        public DeleteModel(Coders_Airlines.Data.AirlinesDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ApartmentRental ApartmentRental { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ApartmentRental = await _context.ApartmentRentals
                .Include(a => a.Apartment)
                .Include(a => a.User).FirstOrDefaultAsync(m => m.ID == id);

            if (ApartmentRental == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ApartmentRental = await _context.ApartmentRentals.FindAsync(id);

            if (ApartmentRental != null)
            {
                _context.ApartmentRentals.Remove(ApartmentRental);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./AdminApartmentRental");
        }
    }
}
