using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Coders_Airlines.Data;
using Coders_Airlines.Models;
using Coders_Airlines.Models.Interfaces;

namespace Coders_Airlines.Pages.Cars
{
    public class CreateModel : PageModel
    {
        private readonly ICar _car;
        private readonly ICountry _country;

        public CreateModel(ICar car, ICountry country)
        {
            _car = car;
            _country = country;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            Cities = await _country.GetCities();
            return Page();
        }

        [BindProperty]
        public Car Car { get; set; }
        public List<City> Cities { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _car.CreateCar(Car);

            return RedirectToPage("./Index");
        }
    }
}
