using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission6_Mosarsaa.Models;
using System.Diagnostics;

namespace Mission6_Mosarsaa.Controllers
{
    public class HomeController : Controller
    {
        private ILogger<HomeController> _logger;
        private MovieContext _context;

        public HomeController(ILogger<HomeController> logger, MovieContext context)
        {
            _logger = logger;
            _context = context; // Add this line
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Movies()
        {
            var viewModel = new MoviesViewModel
            {
                Categories = _context.Categories.ToList(),
                Movies = _context.Movies.Include(m => m.Category).ToList()
            };

            return View(viewModel);
        }





        public IActionResult AllMovies()
        {
            var movies = _context.Movies.Include(m => m.Category).ToList();
            return View(movies); // Ensure you have a corresponding view named AllMovies.cshtml
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
