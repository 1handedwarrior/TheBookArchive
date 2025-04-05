using BooksProj.Data;
using BooksProj.Dtos.PurchaseDtos;
using BooksProj.Helpers;
using BooksProj.Interfaces;
using BooksProj.Mappers;
using BooksProj.Models;
using Microsoft.EntityFrameworkCore;

namespace BooksProj.Repositories;

public class PurchaseRepository : IPurchaseRepository
{
    private readonly ApplicationDbContext _context;

    public PurchaseRepository(ApplicationDbContext context)
    {
        _context = context;
    }


    public async Task<List<Purchase>> GetAllAsync(QueryObject query)
    {
        var purchases = _context.Purchases.Include(p => p.Books).AsQueryable();

        if (query.Total is not null)
        {
            purchases = purchases.Where(p => p.Total == query.Total);
        }

        return await purchases.ToListAsync();
    }

    public async Task<Purchase>? GetByIdAsync(int id)
    {
        var purchase = await _context.Purchases.Include(p => p.Books).FirstOrDefaultAsync(p => p.Id == id);

        return purchase ?? null!;
    }

    public async Task<Purchase> CreateAsync(CreatePurchaseDto purchaseDto)
    {
        var newPurchase = purchaseDto.ToPurchaseFromCreatePurchaseDto();

        foreach (var title in purchaseDto.BookTitles)
        {
            var existingBook = await _context.Books.FirstOrDefaultAsync(b => b.Title == title);

            if (existingBook is not null)
            {
                newPurchase.Books.Add(existingBook);
            }
            else
            {
                var newBook = new Book
                {
                    Title = title,
                    Author = "Unknown",
                    Summary = "Unknown summary...",
                    Isbn = "Unknown Isbn",
                };
                
                newPurchase.Books.Add(newBook);
                await _context.Books.AddAsync(newBook);
            }
        }
        
        await _context.Purchases.AddAsync(newPurchase);
        await _context.SaveChangesAsync();

        return newPurchase;
    }

    public async Task<Purchase>? UpdateAsync(int id, UpdatePurchaseDto purchaseDto)
    {
        var existingPurchase = await _context.Purchases.FindAsync(id);
        
        if (existingPurchase is null) return null!;

        foreach (var title in purchaseDto.BookTitles)
        {
            var existingBook = await _context.Books.FirstOrDefaultAsync(b => b.Title == title);

            if (existingBook is not null)
            {
                existingPurchase.Books.Add(existingBook);
            }
            else
            {
                var newBook = new Book
                {
                    Title = title,
                    Author = "Unknown",
                    Summary = "",
                    Isbn = ""
                };
                
                existingPurchase.Books.Add(newBook);
                await _context.Books.AddAsync(newBook);
            }
        }
        
        existingPurchase.Total = purchaseDto.Total;
        existingPurchase.PurchasedOn = purchaseDto.PurchasedOn;

        await _context.SaveChangesAsync();

        return existingPurchase;
    }

    public async Task<Purchase>? DeleteAsync(int id)
    {
        var deletedPurchase = await _context.Purchases.FindAsync(id);

        if (deletedPurchase is null) return null!;

        _context.Purchases.Remove(deletedPurchase);
        await _context.SaveChangesAsync();

        return deletedPurchase;
    }
}