using Coders_Airlines.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coders_Airlines.Pages.Profile
{
    public class CarHistoryModel : PageModel
    {
        private readonly Coders_Airlines.Data.AirlinesDbContext _context;

        public CarHistoryModel(Coders_Airlines.Data.AirlinesDbContext context)
        {
            _context = context;
        }

        public IList<CarRental> CarRental { get; set; }

        public async Task OnGetAsync(string username)
        {
            CarRental = await _context.CarRentals
                .Where(c => c.User.UserName == username)
                .Include(c => c.Car)
                .ToListAsync();
        }

       
    }
}
