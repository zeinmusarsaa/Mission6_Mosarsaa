using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission6_Mosarsaa.Models
{
    public class Movie
    {
        public int MovieId { get; set; } 
        public int? CategoryId { get; set; }

        public CategoryClass? Category { get; set; }
        public string Title { get; set; }

        [Range(1888, int.MaxValue, ErrorMessage = "Year must be 1888 or later")]
        public int Year { get; set; }
        public string? Director { get; set; }
        public string? Rating { get; set; }
        public bool Edited { get; set; } 
        public string? LentTo { get; set; }
        public bool CopiedToPlex { get; set; } 
        public string? Notes { get; set; }


    }

}


