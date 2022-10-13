using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CarSales.Data;
using CarSales.Models;

namespace CarSales.Pages.Cars
{
    public class CreateModel : PageModel
    {
        private readonly CarSales.Data.CarContext _context;

        public CreateModel(CarSales.Data.CarContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["BrandId"] = new SelectList(_context.Brand.OrderBy(b=>b.BrandName), "Id", "BrandName");
            ViewData["FuelId"] = new SelectList(_context.Fuel.OrderBy(f=>f.FuelName), "Id", "FuelName");
            return Page();
        }

        [BindProperty]
        public Car Car { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPost()
        {
            ViewData["BrandId"] = new SelectList(_context.Brand.OrderBy(b => b.BrandName), "Id", "BrandName");
            ViewData["FuelId"] = new SelectList(_context.Fuel.OrderBy(f => f.FuelName), "Id", "FuelName");

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Car.Add(Car);
            _context.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}
