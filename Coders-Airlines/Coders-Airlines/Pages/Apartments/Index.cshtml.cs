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
using Coders_Airlines.Pages.Cars;

namespace Coders_Airlines.Pages.Apartments
{
    public class IndexModel : PageModel
    {
        private readonly IApartment _apartment;

        public IndexModel(IApartment apartment)
        {
            _apartment = apartment;
        }

        public List<Apartment> Apartments { get;set; }
        [BindProperty]
        public Filter Filter { get; set; }

        public async Task OnGetAsync()
        {
            Apartments = await _apartment.GetApartments();
        }
        public async Task OnPostAsync()
        {
            Apartments = await _apartment.GetApartOnTime(Filter);
        }
    }
}
