using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BooksProj.Models;

namespace BooksProj.Dtos.PurchaseDtos;

public class UpdatePurchaseDto
{
    [Required]
    [Column(TypeName = "decimal(10, 2)")]
    public decimal Total { get; set; }

    [Required] 
    [MinLength(1)] 
    public List<string> BookTitles { get; set; } = null!;
    
    [Required]
    public DateTime PurchasedOn { get; set; } = DateTime.Now;
}