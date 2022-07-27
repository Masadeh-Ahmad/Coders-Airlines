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
using Microsoft.AspNetCore.Authorization;

namespace Coders_Airlines.Pages.Admin.RentedCars
{
    [Authorize(Roles = "administrator")]
    public class EditModel : PageModel
    {
        private readonly Coders_Airlines.Data.AirlinesDbContext _context;

        public EditModel(Coders_Airlines.Data.AirlinesDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CarRental CarRental { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CarRental = await _context.CarRentals
                .Include(c => c.Car)
                .Include(c => c.User).FirstOrDefaultAsync(m => m.ID == id);

            if (CarRental == null)
            {
                return NotFound();
            }
           ViewData["CarID"] = new SelectList(_context.Cars, "ID", "ID");
           ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(CarRental).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarRentalExists(CarRental.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./AdminCarRental");
        }

        private bool CarRentalExists(int id)
        {
            return _context.CarRentals.Any(e => e.ID == id);
        }
    }
}
