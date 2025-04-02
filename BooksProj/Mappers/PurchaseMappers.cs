using BooksProj.Dtos.PurchaseDtos;
using BooksProj.Models;

namespace BooksProj.Mappers;

public static class PurchaseMappers
{
    public static Purchase ToPurchaseFromCreatePurchaseDto(this CreatePurchaseDto purchaseDto)
    {
        return new Purchase
        {
            Total = purchaseDto.Total,
            Books = [],
            PurchasedOn = purchaseDto.PurchasedOn,
        };
    }

    public static PurchaseDto ToPurchaseDtoFromPurchase(this Purchase purchase)
    {
        return new PurchaseDto
        {
            Id = purchase.Id,
            Total = purchase.Total,
            PurchasedOn = purchase.PurchasedOn,
            Books = purchase.Books.Select(b => b.ToBookDto()).ToList()
        };
    }
}