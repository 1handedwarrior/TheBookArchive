using System.ComponentModel.DataAnnotations;

namespace BooksProj.Dtos.AccountDtos;

public class RegisterDto
{
    [Required]
    [MinLength(8)]
    public string? Username { get; set; } 
    
    [Required]
    [EmailAddress]
    public string? Email { get; set; }
    
    [Required]
    [MinLength(8)]
    public string? Password { get; set; }
}