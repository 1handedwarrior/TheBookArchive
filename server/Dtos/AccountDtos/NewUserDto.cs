using System.ComponentModel.DataAnnotations;

namespace BooksProj.Dtos.AccountDtos;

public class NewUserDto
{
    [Required]
    [MinLength(8)]
    public string Username { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    public string Token { get; set; }
}