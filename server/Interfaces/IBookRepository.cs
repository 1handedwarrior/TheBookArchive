using BooksProj.Dtos.BookDtos;
using BooksProj.Helpers;
using BooksProj.Models;

namespace BooksProj.Interfaces;

public interface IBookRepository
{
    Task<List<Book>> GetAllAsync(QueryObject query);
    Task<Book?> GetByIdAsync(int id, string userId);
    Task<Book> CreateAsync(CreateBookDto bookDto, string userId);
    Task<Book?> UpdateAsync(int id, UpdateBookDto bookDto, string userId);
    Task<Book?> DeleteAsync(int id, string userId);
}