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
    public class IndexModel : PageModel
    {
        private readonly IFlight _flight;

        public IndexModel(IFlight Flight)
        {
            _flight = Flight;
        }

        public List<Flight> Flights { get; set; }

        public async Task OnGetAsync()
        {
            Flights = await _flight.GetFlights();
        }
    }
}
