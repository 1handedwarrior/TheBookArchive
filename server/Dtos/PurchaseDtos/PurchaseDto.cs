using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BooksProj.Dtos.BookDtos;

namespace BooksProj.Dtos.PurchaseDtos;

public class PurchaseDto
{
    public int Id { get; set; }
    
    [Required]
    [Column(TypeName = "decimal(10,2)")]
    public decimal Total { get; set; }
    
    [Required]
    public DateTime PurchasedOn { get; set; } = DateTime.Now;
    
    [Required]
    public ICollection<BookDto> Books { get; set; } = [];
}