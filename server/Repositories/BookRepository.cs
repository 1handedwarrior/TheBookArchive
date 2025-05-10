using System.Text;
using BooksProj.Data;
using BooksProj.Dtos.BookDtos;
using BooksProj.Helpers;
using BooksProj.Interfaces;
using BooksProj.Mappers;
using BooksProj.Models;
using Microsoft.EntityFrameworkCore;

namespace BooksProj.Repositories;

public class BookRepository : IBookRepository
{
    private readonly ApplicationDbContext _context;

    public BookRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<Book>> GetAllAsync(QueryObject query)
    {
        var books = _context.Books.Where(b => b.UserId == query.UserId).AsQueryable();

        if (!string.IsNullOrWhiteSpace(query.Title))
        {
            books = books.Where(b => b.Title == query.Title);
        }
        
        if (!string.IsNullOrWhiteSpace(query.Author))
        {
            books = books.Where(b => b.Author == query.Author);
        }
        
        return await books.ToListAsync();
    }

    public async Task<Book?> GetByIdAsync(int id, string userId)
    {
        var book = await _context.Books.FirstOrDefaultAsync(b => b.Id == id && b.UserId == userId); 
        
        return book ?? null;
    }

    public async Task<Book> CreateAsync(CreateBookDto bookDto, string userId)
    {
        var newBook = bookDto.ToBookFromCreateDto(userId);

        await _context.Books.AddAsync(newBook);
        await _context.SaveChangesAsync();

        return newBook;
    }

    public async Task<Book?> UpdateAsync(int id, UpdateBookDto bookDto, string userId)
    {
        var book = await _context.Books.FirstOrDefaultAsync(b => b.UserId == userId && b.Id == id);

        if (book is null) return null;
        
        book.Title       = bookDto.Title;
        book.Author      = bookDto.Author;
        book.Summary     = bookDto.Summary;
        book.PublishedOn = bookDto.PublishedOn;
        book.Isbn        = bookDto.Isbn;

        await _context.SaveChangesAsync();

        return book;
    }

    public async Task<Book?> DeleteAsync(int id, string userId)
    {
        var existingBook = await _context.Books.FirstOrDefaultAsync(b => b.Id == id && b.UserId == userId);

        if (existingBook is null) return null;

        _context.Books.Remove(existingBook);
        await _context.SaveChangesAsync();

        return existingBook;
    }
}