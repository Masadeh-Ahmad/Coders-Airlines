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
    public class IndexModel : PageModel
    {
        private readonly IApartment apartmentService;

        public IndexModel(IApartment service)
        {
            apartmentService = service;
        }

        public List<Apartment> Apartments { get;set; }

        public async Task OnGetAsync()
        {
            Apartments = await apartmentService.GetApartments();
        }
    }
}
