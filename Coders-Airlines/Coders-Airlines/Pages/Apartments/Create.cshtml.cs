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

namespace Coders_Airlines.Pages.Apartments
{
    public class CreateModel : PageModel
    {
        private readonly IApartment _apartment;
        private readonly ICountry _country;

        public CreateModel(IApartment apartment, ICountry country)
        {
            _apartment = apartment;
            _country = country;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            Cities = await _country.GetCities();
            return Page();
        }

        [BindProperty]
        public Apartment Apartment { get; set; }
        public List<City> Cities { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _apartment.CreateApartment(Apartment);

            return RedirectToPage("./Index");
        }
    }
}
