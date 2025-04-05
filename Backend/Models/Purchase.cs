namespace BooksProj.Models;

public class Purchase
{
    
    public int Id { get; set; }
    public decimal Total { get; set; }
    public DateTime PurchasedOn { get; set; } = DateTime.Now;
    public List<Book> Books { get; set; } = [];
}