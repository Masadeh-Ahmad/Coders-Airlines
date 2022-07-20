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
        private readonly IApartment apartmentService;

        public DetailsModel(IApartment service)
        {
            apartmentService = service;
        }

        public Apartment Apartment { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Apartment = await apartmentService.GetApartment(id);

            if (Apartment == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
