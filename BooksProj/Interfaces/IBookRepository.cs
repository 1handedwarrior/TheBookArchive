using BooksProj.Dtos.BookDtos;
using BooksProj.Helpers;
using BooksProj.Models;

namespace BooksProj.Interfaces;

public interface IBookRepository
{
    Task<List<Book>> GetAllAsync(QueryObject query);
    Task<Book?> GetByIdAsync(int id);
    Task<Book> CreateAsync(CreateBookDto bookDto);
    Task<Book?> UpdateAsync(int id, UpdateBookDto bookDto);
    Task<Book?> DeleteAsync(int id);
}