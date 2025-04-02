using System.ComponentModel.DataAnnotations;

namespace BooksProj.Dtos.BookDtos;

public class BookTitleDto
{
    [Required]
    [MaxLength(255)]
    [MinLength(1)]
    public string Title { get; set; } = string.Empty;
}