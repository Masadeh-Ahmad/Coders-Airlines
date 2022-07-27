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

namespace Coders_Airlines.Pages.Cars
{
    public class DetailsModel : PageModel
    {
        private readonly ICar _car;
        private readonly AirlinesDbContext _context;
        private IUser _userService;
        public List<Car> items { get; set; }
        public DetailsModel(ICar car, AirlinesDbContext context, IUser user )
        {
            _car = car;
            _context = context;
            _userService = user;
            Rent = false;
        }
        public Car Car { get; set; }
        [BindProperty]
        public CarImg CarImg { get; set; }
        public List<CarImg> Imgs { get; set; }
        [BindProperty]
        public CarRental CarRental { get; set; }
        public bool Rent { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, int? rent)
        {
            if (id == null)
            {
                return NotFound();
            }

            Car = await _car.GetCar(id);
            items = await _car.RandomCar();
            Imgs = await _car.GetImgs(id);
            if(rent != null)
            {
                Rent = true;
            }

            if (Car == null)
            {
                return NotFound();
            }
            return Page();
        }
        
        public async Task<IActionResult> OnPostAddImg(int id)
        {
            CarImg.CarID = id;
            await _car.AddImg(CarImg);
            return Redirect($"./Details/?id={id}");
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
            await OnGetAsync(id,1);
            CarRental last = new CarRental();
            bool available = true;
            if (CarRental.From >= CarRental.To || CarRental.From <= DateTime.Now.ToLocalTime())
            {
                CarRental.Price = 0;
                return Page();
            }
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
