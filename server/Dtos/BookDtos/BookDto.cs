using System.ComponentModel.DataAnnotations;
using BooksProj.Models;

namespace BooksProj.Dtos.BookDtos;

public class BookDto
{
    public int? Id { get; set; } = null;
    
    [MaxLength(255)]
    [Required]
    public string Title { get; set; } = string.Empty;
    [MaxLength(255)]
    [Required]
    public string Author { get; set; } = string.Empty;
    [MaxLength(255)]
    [Required]
    public string Summary { get; set; } = string.Empty;
    [Required]
    public DateOnly PublishedOn { get; set; }
    [MinLength(8)]
    [MaxLength(15)]
    public string Isbn { get; set; } = string.Empty;

    // navigation property
    public AppUser User { get; set; }
    
    // foreign key
    public string UserId { get; set; }
}