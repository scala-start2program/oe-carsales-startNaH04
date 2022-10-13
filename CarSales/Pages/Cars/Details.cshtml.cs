using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarSales.Data;
using CarSales.Models;

namespace CarSales.Pages.Cars
{
    public class DetailsModel : PageModel
    {
        private readonly CarSales.Data.CarContext _context;

        public DetailsModel(CarSales.Data.CarContext context)
        {
            _context = context;
        }

        public Car Car { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id == null || _context.Car == null)
            {
                return NotFound();
            }

            var car = _context.Car                
                .Include(b => b.Brand)
                .Include(f => f.Fuel)
                .FirstOrDefault(m => m.Id == id);
            if (car == null)
            {
                return NotFound();
            }
            else 
            {
                Car = car;
            }
            return Page();
        }
    }
}
