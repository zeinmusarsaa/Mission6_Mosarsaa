using System.ComponentModel.DataAnnotations;

namespace Mission6_Mosarsaa.Models
{
    public class Movie
    {
        public int Id { get; set; } // Primary key

        [Required]

        public string Category { get; set; }
        [Required]
        public string Title { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public string Director { get; set; }

        [Required]
        [StringLength(5)]
        public string Rating { get; set; } // Assuming 'G', 'PG', 'PG-13', 'R' are the only valid values

        public bool Edited { get; set; } // This will be 'false' for 'No' and 'true' for 'Yes'

        public string LentTo { get; set; } // Not required

        [StringLength(25)]
        public string Notes { get; set; } // Not required and max length of 25 characters
    }
}

