using System.ComponentModel.DataAnnotations;

namespace BooksProj.Models;

public class Book
{
    public int Id { get; set; }
    [MaxLength(255)]
    public string Title { get; set; } = string.Empty;
    [MaxLength(255)]
    public string Author { get; set; } = string.Empty;
    [MaxLength(500)]
    public string Summary { get; set; } = string.Empty;
    public DateOnly PublishedOn { get; set; }
    [MaxLength(15)]
    public string Isbn { get; set; } = string.Empty;

    // navigation properties
    public int? PurchaseId { get; set; }
}