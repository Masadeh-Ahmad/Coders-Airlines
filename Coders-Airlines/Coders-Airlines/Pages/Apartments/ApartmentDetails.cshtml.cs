using Coders_Airlines.Models;
using Coders_Airlines.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Coders_Airlines.Pages.Apartments
{
    public class ApartmentDetailsModel : PageModel
    {
        private IApartment apartmentService;
        public Apartment apartment { get; set; }
        public ApartmentDetailsModel(IApartment service)
        {
            apartmentService = service;
        }
        public async Task OnGetAsync(int id)
        {
            apartment = await apartmentService.GetApartment(id);
        }
    }
}
