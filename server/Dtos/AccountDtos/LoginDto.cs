using System.ComponentModel.DataAnnotations;

namespace BooksProj.Dtos.AccountDtos;

public class LoginDto
{
    [Required]
    [MinLength(8)]
    public string? Username { get; set; } 
    
    [Required]
    [MinLength(8)]
    public string? Password { get; set; }
}