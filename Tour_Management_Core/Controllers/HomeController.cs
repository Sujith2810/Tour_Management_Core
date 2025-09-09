using Microsoft.AspNetCore.Mvc;
using Tour_Management_Core.Models;
using System.Linq;

namespace Tour_Management_Core.Controllers
{
    public class HomeController : Controller
    {
        private readonly TourDbContext _context;

        public HomeController(TourDbContext context)
        {
            _context = context;

            // Seed data if no tours exist
            if (!_context.Tours.Any())
            {
                _context.Tours.Add(new Tour
                {
                    Name = "Sample Tour",
                    Description = "Test tour",
                    Location = "Unknown",
                    Price = 100
                });
                _context.SaveChanges();
            }
        }

        public IActionResult Index()
        {
            var tours = _context.Tours.ToList();
            return View(tours);
        }
    }
}
