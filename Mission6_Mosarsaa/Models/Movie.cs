using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission6_Mosarsaa.Models
{
    public class Movie
    {
        public int MovieId { get; set; } 
        public int? CategoryId { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string? Director { get; set; }
        public string? Rating { get; set; }
        public bool Edited { get; set; } 
        public string? LentTo { get; set; } // Make this nullable if it can be NULL in the database
        public bool CopiedToPlex { get; set; } // Assuming INTEGER NOT NULL corresponds to a non-nullable bool
        public string? Notes { get; set; } // Make this nullable if it can be NULL in the database
        // Navigation property to Category
        public CategoryClass Category { get; set; }

    }

}


