using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Coders_Airlines.Data;
using Coders_Airlines.Models;

namespace Coders_Airlines.Pages.Admin.RentedCars
{
    public class DeleteModel : PageModel
    {
        private readonly Coders_Airlines.Data.AirlinesDbContext _context;

        public DeleteModel(Coders_Airlines.Data.AirlinesDbContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CarRental = await _context.CarRentals.FindAsync(id);

            if (CarRental != null)
            {
                _context.CarRentals.Remove(CarRental);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./AdminCarRental");
        }
    }
}
