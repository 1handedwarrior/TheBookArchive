using BooksProj.Dtos.PurchaseDtos;
using BooksProj.Helpers;
using BooksProj.Models;

namespace BooksProj.Interfaces;

public interface IPurchaseRepository
{
    Task<List<Purchase>> GetAllAsync (QueryObject query);
    Task<Purchase>? GetByIdAsync (int id);
    Task<Purchase> CreateAsync (CreatePurchaseDto purchaseDto);
    Task<Purchase>? UpdateAsync (int id, UpdatePurchaseDto purchaseDto);
    Task<Purchase>? DeleteAsync (int id);
}