using System.ComponentModel.DataAnnotations;

namespace BooksProj.Models;

public class Book
{
    public int Id { get; set; }
    [MaxLength(255)]
    public required string Title { get; set; } = string.Empty;
    [MaxLength(255)]
    public required string Author { get; set; } = string.Empty;
    [MaxLength(500)]
    public required string Summary { get; set; } = string.Empty;
    public DateOnly PublishedOn { get; set; }
    [MaxLength(15)]
    public required string Isbn { get; set; } = string.Empty;
    
    // foreign key
    [MaxLength(255)]
    public required string UserId { get; set; }
    
    // navigation property
    public AppUser? User { get; set; }
}