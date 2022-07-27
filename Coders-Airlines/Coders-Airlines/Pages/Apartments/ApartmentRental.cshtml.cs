using Coders_Airlines.Auth.Interfaces;
using Coders_Airlines.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coders_Airlines.Pages.Apartments
{
    public class ApartmentRentalModel : PageModel
    {
        private readonly Coders_Airlines.Data.AirlinesDbContext _context;
        private IUser _userService;

        public ApartmentRentalModel(Data.AirlinesDbContext context, IUser user)
        {
            _context = context;
            _userService = user;
        }

        public Apartment Apartment { get; set; }
        [BindProperty]
        public ApartmentRental ApartmentRental { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Apartment = await _context.Apartments.FirstOrDefaultAsync(m => m.ID == id);

            if (Apartment == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            await OnPostCheck(id);
            _context.ApartmentRentals.Add(ApartmentRental);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
        public async Task<IActionResult> OnPostCheck(int? id)
        {
            await OnGetAsync(id);
            bool available = true;

            List<ApartmentRental> rentals = await _context.ApartmentRentals.Where(x => x.ApartmentID == id).ToListAsync();
            foreach (var item in rentals)
            {
                if (ApartmentRental.From < item.To && item.From < ApartmentRental.To) { available = false; }
            }

            double days = 0;

            if (!available)
            {
                ApartmentRental.Price = 0;
                return Page();
            }
            days = (ApartmentRental.To - ApartmentRental.From).TotalDays;
            ApartmentRental.Price = days * Apartment.RentalCost;
            ApartmentRental.ApartmentID = Apartment.ID;
            var user = await _userService.GetUser();
            ApartmentRental.UserId = user.Id;
            return Page();
        }
    }
}
