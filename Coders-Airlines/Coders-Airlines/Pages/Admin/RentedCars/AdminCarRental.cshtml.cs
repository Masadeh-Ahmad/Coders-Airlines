using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Coders_Airlines.Data;
using Coders_Airlines.Models;
using Microsoft.AspNetCore.Authorization;

namespace Coders_Airlines.Pages.Admin
{
    [Authorize(Roles = "administrator")]
    public class AdminCarRentalModel : PageModel
    {
        private readonly Coders_Airlines.Data.AirlinesDbContext _context;

        public AdminCarRentalModel(Coders_Airlines.Data.AirlinesDbContext context)
        {
            _context = context;
        }

        public IList<CarRental> CarRental { get;set; }

        public async Task OnGetAsync()
        {
            CarRental = await _context.CarRentals
                .Include(c => c.Car)
                .Include(c => c.User).ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync(DateTime dateFrom, DateTime dateTo)
        {
            CarRental = await _context.CarRentals
                .Where(c => c.From > dateFrom && c.From < dateTo)
                .Include(c => c.Car)
                .Include(c => c.User).ToListAsync();
            return Page();
        }
    }
}
