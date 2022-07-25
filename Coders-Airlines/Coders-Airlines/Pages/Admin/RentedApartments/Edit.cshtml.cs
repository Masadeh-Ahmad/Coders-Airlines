using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Coders_Airlines.Data;
using Coders_Airlines.Models;

namespace Coders_Airlines.Pages.Admin.RentedApartments
{
    public class EditModel : PageModel
    {
        private readonly Coders_Airlines.Data.AirlinesDbContext _context;

        public EditModel(Coders_Airlines.Data.AirlinesDbContext context)
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
           ViewData["ApartmentID"] = new SelectList(_context.Apartments, "ID", "ID");
           ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ApartmentRental).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApartmentRentalExists(ApartmentRental.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./AdminApartmentRental");
        }

        private bool ApartmentRentalExists(int id)
        {
            return _context.ApartmentRentals.Any(e => e.ID == id);
        }
    }
}
