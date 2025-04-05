using System.ComponentModel.DataAnnotations;

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
    
    public int PurchaseId { get; set; }
}