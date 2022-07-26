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

namespace Coders_Airlines.Pages.Apartments
{
    public class DetailsModel : PageModel
    {
        private readonly IApartment _apartment;
        public List<Apartment> items { get; set; }

        public DetailsModel(IApartment apartment)
        {
            _apartment = apartment;
        }

        public Apartment Apartment { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Apartment = await _apartment.GetApartment(id);
            items = await _apartment.RandomApartment();

            if (Apartment == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
