using Microsoft.AspNetCore.Mvc;
using Mission6_Mosarsaa.Models;
using System.Threading.Tasks;

public class MoviesController : Controller
{
    private readonly MovieContext _context;

    public MoviesController(MovieContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> AddMovie(Movie movie)
    {
        if (ModelState.IsValid)
        {
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home"); // Or wherever you'd like to redirect
        }

        return View(movie);
    }
}

