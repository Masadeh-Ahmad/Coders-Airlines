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

namespace Coders_Airlines.Pages.Cars
{
    public class IndexModel : PageModel
    {
        private readonly ICar _car;

        public IndexModel(ICar car)
        {
            _car = car;
        }
        public List<Car> Cars { get; set; }
        [BindProperty]
        public Filter Filter { get; set; }
        public async Task OnGetAsync()
        {
            Cars = await _car.GetCars();
        }
        public async Task OnPostAsync()
        {
            Cars = await _car.GetCarsOnTime(Filter);
        }
    }
    public class Filter
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}
