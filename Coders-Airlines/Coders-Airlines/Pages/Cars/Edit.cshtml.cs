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
using Coders_Airlines.Models.Interfaces;

namespace Coders_Airlines.Pages.Cars
{
    public class EditModel : PageModel
    {
        private readonly ICar _car;
        private readonly ICountry _country;

        public EditModel(ICar car, ICountry country)
        {
            _car = car;
            _country = country;
        }

        [BindProperty]
        public Car Car { get; set; }
        public List<City> Cities { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Cities = await _country.GetCities();
            Car = await _car.GetCar(id);

            if (Car == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            await _car.UpdateCar(Car.ID, Car);

            return RedirectToPage("./Index");
        }
    }
}
