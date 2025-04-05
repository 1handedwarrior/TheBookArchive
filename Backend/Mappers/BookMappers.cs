using BooksProj.Dtos.BookDtos;
using BooksProj.Models;

namespace BooksProj.Mappers;

public static class BookMappers
{
    public static BookDto ToBookDto(this Book book)
    {
        return new BookDto
        {
            Id          = book.Id,
            Title       = book.Title,
            Author      = book.Author,
            Summary     = book.Summary,
            PublishedOn = book.PublishedOn,
            Isbn        = book.Isbn,
        };
    }

    public static Book ToBookFromCreateDto(this CreateBookDto bookDto)
    {
        return new Book
        {
            Title       = bookDto.Title,
            Author      = bookDto.Author,
            Summary     = bookDto.Summary,
            PublishedOn = bookDto.PublishedOn,
            Isbn        = bookDto.Isbn,
        };
    }
}