using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Coders_Airlines.Data;
using Coders_Airlines.Models;

namespace Coders_Airlines.Pages.Cars
{
    public class IndexModel : PageModel
    {
        private readonly Coders_Airlines.Data.AirlinesDbContext _context;

        public IndexModel(Coders_Airlines.Data.AirlinesDbContext context)
        {
            _context = context;
        }

        public IList<Car> Car { get;set; }

        public async Task OnGetAsync()
        {
            Car = await _context.Cars.ToListAsync();
        }
    }
}
