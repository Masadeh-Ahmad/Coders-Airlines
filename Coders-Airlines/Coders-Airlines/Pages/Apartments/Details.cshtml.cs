using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Coders_Airlines.Data;
using Coders_Airlines.Models;
using Coders_Airlines.Models.Interfaces;
using Coders_Airlines.Auth.Interfaces;

namespace Coders_Airlines.Pages.Apartments
{
    public class DetailsModel : PageModel
    {
        private readonly IApartment _apartment;
        private readonly AirlinesDbContext _context;
        private IUser _userService;
        public List<Apartment> items { get; set; }

        public DetailsModel(IApartment apartment , AirlinesDbContext context, IUser user)
        {
            _apartment = apartment;
            _context = context;
            _userService = user;
            Rent = false;
        }

        public Apartment Apartment { get; set; }
        public List<ApartmentImg> Imgs { get; set; }
        public bool Rent { get; set; }
        [BindProperty]
        public ApartmentRental ApartmentRental { get; set; }
        [BindProperty]
        public ApartmentImg ApartmentImg { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id,int? rent)
        {
            if (id == null)
            {
                return NotFound();
            }

            Apartment = await _apartment.GetApartment(id);
            try
            {
                items = await _apartment.RandomApartment();

            }
            catch
            {
                items = null;
            }
            Imgs = await _apartment.GetImgs(id);
            if (rent != null)
            {
                Rent = true;
            }

            if (Apartment == null)
            {
                return NotFound();
            }
            return Page();
        }
        public async Task<IActionResult> OnGetDelete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            await _apartment.DeleteApartment(id);

            return RedirectToPage("./Index");
        }
        public async Task<IActionResult> OnPostAddImg(int id)
        {
            ApartmentImg.ApartmentID = id;
            await _apartment.AddImg(ApartmentImg);
            return Redirect($"./Details/?id={id}");
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
            await OnGetAsync(id,1);
            bool available = true;
            if(ApartmentRental.From>= ApartmentRental.To || ApartmentRental.From <= DateTime.Now.ToLocalTime())
            {
                ApartmentRental.Price = 0;
                return Page();
            }
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
