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
using Microsoft.AspNetCore.Authorization;

namespace Coders_Airlines.Pages.Flights
{
    [Authorize(Roles = "administrator")]
    public class EditModel : PageModel
    {
        private readonly IFlight _flight;
        private readonly ICountry _country;
        public EditModel(IFlight flight, ICountry country)
        {
            _flight = flight;
            _country = country;
        }

        [BindProperty]
        public Flight Flight { get; set; }
        public List<City> Cities { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Cities = await _country.GetCities();
            Flight = await _flight.GetFlight(id);

            if (Flight == null)
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
            await _flight.UpdateFlight(Flight.ID, Flight);

            return RedirectToPage("./Index");
        }
    }
}
