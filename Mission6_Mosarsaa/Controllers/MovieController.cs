using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission6_Mosarsaa.Models;
using System.Linq;
using System.Threading.Tasks;

public class MoviesController : Controller
{
    private MovieContext _context;

    public MoviesController(MovieContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<JsonResult> AddMovie(Movie movie)
    {
        if (ModelState.IsValid)
        {
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();
            return Json(new { success = true, message = "Movie added successfully." });
        }
        return Json(new { success = false, message = "Invalid movie data." });
    }

    [HttpGet]
    public async Task<JsonResult> GetMovie(int id)
    {
        var movie = await _context.Movies.FindAsync(id);
        if (movie == null)
        {
            return Json(new { success = false, message = "Movie not found." });
        }
        return Json(new { success = true, data = movie });
    }

    [HttpPost]
    public async Task<JsonResult> Edit(int id, Movie movie)
    {
        if (id != movie.MovieId)
        {
            return Json(new { success = false, message = "Bad Request." });
        }

        if (ModelState.IsValid)
        {
            _context.Entry(movie).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Json(new { success = true, message = "Movie updated successfully." });
        }

        return Json(new { success = false, message = "Invalid movie data." });
    }

    [HttpPost]
    public async Task<JsonResult> Delete(int id)
    {
        var movie = await _context.Movies.FindAsync(id);
        if (movie == null)
        {
            return Json(new { success = false, message = "Movie not found." });
        }

        _context.Movies.Remove(movie);
        await _context.SaveChangesAsync();
        return Json(new { success = true, message = "Movie deleted successfully." });
    }
}





