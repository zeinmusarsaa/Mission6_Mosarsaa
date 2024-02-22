using Microsoft.EntityFrameworkCore;

namespace Mission6_Mosarsaa.Models
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<CategoryClass> Categories { get; set; } // Add this line to handle categories
    }
}


