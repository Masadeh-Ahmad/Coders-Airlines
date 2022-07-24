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

namespace Coders_Airlines.Pages.Apartments
{
    public class EditModel : PageModel
    {
        private readonly IApartment _apartment;
        private readonly ICountry _country;

        public EditModel(IApartment apartment, ICountry country)
        {
            _apartment = apartment;
            _country = country;
        }

        [BindProperty]
        public Apartment Apartment { get; set; }
        public List<City> Cities { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Cities = await _country.GetCities();
            Apartment = await _apartment.GetApartment(id);

            if (Apartment == null)
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
            await _apartment.UpdateApartment(Apartment.ID, Apartment);
            
            return RedirectToPage("./Index");
        }
    }
}
