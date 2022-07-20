using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Coders_Airlines.Data;
using Coders_Airlines.Models;

namespace Coders_Airlines.Pages.Flights
{
    public class DetailsModel : PageModel
    {
        private readonly Coders_Airlines.Data.AirlinesDbContext _context;

        public DetailsModel(Coders_Airlines.Data.AirlinesDbContext context)
        {
            _context = context;
        }

        public Flight Flight { get; set; }

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
    }
}
