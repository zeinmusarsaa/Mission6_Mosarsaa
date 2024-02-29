using Mission6_Mosarsaa.Models;
using System.ComponentModel.DataAnnotations;

public class CategoryClass
{
    [Key]
    public int CategoryId { get; set; }

    [Required]
    public string Category { get; set; }
}



