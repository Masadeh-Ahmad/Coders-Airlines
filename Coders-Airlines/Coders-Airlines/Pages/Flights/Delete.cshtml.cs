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

namespace Coders_Airlines.Pages.Flights
{
    public class DeleteModel : PageModel
    {
        private readonly IFlight _flight;

        public DeleteModel(IFlight flight)
        {
            _flight = flight;
        }

        [BindProperty]
        public Flight Flight { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Flight = await _flight.GetFlight(id);

            if (Flight == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            await _flight.DeleteFlight(id);

            return RedirectToPage("./Index");
        }
    }
}
