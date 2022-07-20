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
        private readonly IApartment apartmentService;

        public CreateModel(IApartment service)
        {
            apartmentService = service;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Apartment Apartment { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await apartmentService.CreateApartment(Apartment);

            return RedirectToPage("./Index");
        }
    }
}
