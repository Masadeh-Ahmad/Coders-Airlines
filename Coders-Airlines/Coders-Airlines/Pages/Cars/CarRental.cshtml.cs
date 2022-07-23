using Coders_Airlines.Auth.Interfaces;
using Coders_Airlines.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coders_Airlines.Pages.Cars
{
    public class CarRentalModel : PageModel
    {
        private readonly Coders_Airlines.Data.AirlinesDbContext _context;
        private IUser _userService;

        public CarRentalModel(Data.AirlinesDbContext context, IUser user)
        {
            _context = context;
            _userService = user;
        }

        public Car Car { get; set; }
        [BindProperty]
        public CarRental CarRental { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Car = await _context.Cars.FirstOrDefaultAsync(m => m.ID == id);

            if (Car == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            await OnPostCheck(id);
            _context.CarRentals.Add(CarRental);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
        public async Task<IActionResult> OnPostCheck(int? id)
        {
            await OnGetAsync(id);
            CarRental last = new CarRental();
            bool available = true;

            List<CarRental> rentals = await _context.CarRentals.Where(x => x.CarID == id).ToListAsync();
            foreach (var item in rentals)
            {
                if (CarRental.From < item.To && item.From < CarRental.To) { available = false; }
            }

            double days = 0;

            if (!available)
            {
                CarRental.Price = 0;
                return Page();
            }
            days = (CarRental.To - CarRental.From).TotalDays;
            CarRental.Price = days * Car.RentalCost;
            CarRental.CarID = Car.ID;
            var user = await _userService.GetUser();
            CarRental.UserId = user.Id;
            return Page();
        }
    }
}