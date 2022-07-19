using Coders_Airlines.Models;
using Coders_Airlines.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coders_Airlines.Pages.Apartments
{
    public class ApartmentsModel : PageModel
    {
        private readonly IApartment apartmentService;

        [BindProperty]
        public List<Apartment> Apartments { get; set; }

        public ApartmentsModel(IApartment service)
        {
            apartmentService = service;
        }

        public async Task OnGet()
        {
            Apartments = await apartmentService.GetApartments();
        }
    }
}
