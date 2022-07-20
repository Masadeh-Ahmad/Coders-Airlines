using Coders_Airlines.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coders_Airlines.Pages.Cars
{
    public class CarRentalModel : PageModel
    {
        private readonly Coders_Airlines.Data.AirlinesDbContext _context;
        public CarRentalModel(Coders_Airlines.Data.AirlinesDbContext context)
        {
            _context = context;
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
            double days = 0;
            try
            {
                last = await _context.CarRentals.OrderByDescending(p => p.Id).FirstOrDefaultAsync();
                
            }
            catch
            {
                days = (CarRental.To - CarRental.From).TotalDays;
                CarRental.Price = days * Car.RentalCost;
                CarRental.CarID = Car.ID;
                CarRental.UserId = "d73fc9f5-166b-42bf-8aff-dd1a882b318c";
                return Page();
            }

            if (last.To >= CarRental.From)
            {
                CarRental.Price = 0;
                return Page();
            }
            days = (CarRental.To - CarRental.From).TotalDays;
            CarRental.Price = days * Car.RentalCost;
            CarRental.CarID = Car.ID;
            CarRental.UserId = "d73fc9f5-166b-42bf-8aff-dd1a882b318c";
            return Page();

           

        }
    }
}
