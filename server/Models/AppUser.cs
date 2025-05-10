using Microsoft.AspNetCore.Identity;

namespace BooksProj.Models;

public class AppUser : IdentityUser
{
    public List<Book> Books { get; set; } = [];
}