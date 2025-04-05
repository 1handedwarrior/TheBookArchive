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
        var products = _context.Books.AsQueryable();

        if (!string.IsNullOrWhiteSpace(query.Title))
        {
            products = products.Where(b => b.Title == query.Title);
        }
        
        if (!string.IsNullOrWhiteSpace(query.Author))
        {
            products = products.Where(b => b.Author == query.Author);
        }
        
        return await products.ToListAsync();
    }

    public async Task<Book?> GetByIdAsync(int id)
    {
        var book = await _context.Books.FindAsync(id);

        return book ?? null;
    }

    public async Task<Book> CreateAsync(CreateBookDto bookDto)
    {
        var newBook = bookDto.ToBookFromCreateDto();

        await _context.Books.AddAsync(newBook);
        await _context.SaveChangesAsync();

        return newBook;
    }

    public async Task<Book?> UpdateAsync(int id, UpdateBookDto bookDto)
    {
        var book = await _context.Books.FindAsync(id);

        if (book is null) return null;

        book.Title       = bookDto.Title;
        book.Author      = bookDto.Author;
        book.Summary     = bookDto.Summary;
        book.PublishedOn = bookDto.PublishedOn;
        book.Isbn        = bookDto.Isbn;

        await _context.SaveChangesAsync();

        return book;
    }

    public async Task<Book?> DeleteAsync(int id)
    {
        var existingBook = await _context.Books.FindAsync(id);

        if (existingBook is null) return null;

        _context.Books.Remove(existingBook);
        await _context.SaveChangesAsync();

        return existingBook;
    }
}