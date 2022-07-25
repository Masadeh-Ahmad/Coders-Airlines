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

namespace Coders_Airlines.Pages.Flights
{
    public class CreateModel : PageModel
    {
        private readonly IFlight _flight;
        private readonly ICountry _country;

        public CreateModel(IFlight flight, ICountry country )
        {
            _flight = flight;
            _country = country;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            Cities = await _country.GetCities();
            return Page();
        }

        [BindProperty]
        public Flight Flight { get; set; }
        public List<City> Cities { get; set; }
        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _flight.CreateFlight(Flight);

            return RedirectToPage("./Index");
        }
    }
}
