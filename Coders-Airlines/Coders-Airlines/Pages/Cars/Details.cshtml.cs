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
    public class DetailsModel : PageModel
    {
        private readonly ICar _car;
        [BindProperty]
        public List<Car> items { get; set; }
        public DetailsModel(ICar car)
        {
            _car = car;
            
        }

        public Car Car { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Car = await _car.GetCar(id);
            items = await _car.RandomCar();

            if (Car == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
