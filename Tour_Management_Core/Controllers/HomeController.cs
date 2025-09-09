using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    private readonly TourDbContext _context;

    public HomeController(TourDbContext context)
    {
        _context = context;
        if (!_context.Tours.Any())
        {
            _context.Tours.Add(new Tour { Name = "Sample Tour", Description = "Test tour" });
            _context.SaveChanges();
        }
    }

    public IActionResult Index()
    {
        var tours = _context.Tours.ToList();
        return View(tours);
    }
}
