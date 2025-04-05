using BooksProj.Data;
using BooksProj.Dtos.PurchaseDtos;
using BooksProj.Helpers;
using BooksProj.Interfaces;
using BooksProj.Mappers;
using BooksProj.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BooksProj.Controllers;


[ApiController]
[Route("api/purchases")]
public class PurchaseController : ControllerBase
{
    private readonly IPurchaseRepository _purchaseRepo;

    public PurchaseController(IPurchaseRepository purchaseRepo)
    {
        _purchaseRepo = purchaseRepo;
    }

    [HttpGet]
    public async Task<IActionResult> GetPurchases([FromQuery] QueryObject query)
    {
        var purchases = await _purchaseRepo.GetAllAsync(query);

        if (purchases is null) return NotFound();

        return Ok(purchases);
    }
    
    [HttpGet]
    [Route("{id:int}")]
    public async Task<IActionResult> GetPurchase([FromRoute] int id)
    {
        var purchase = await _purchaseRepo.GetByIdAsync(id)!;

        if (purchase is null) return NotFound();

        return Ok(purchase.ToPurchaseDtoFromPurchase());
    }

    [HttpPost]
    public async Task<IActionResult> CreatePurchase([FromBody] CreatePurchaseDto purchaseDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        
        var newPurchase = await _purchaseRepo.CreateAsync(purchaseDto);

        return CreatedAtAction(nameof(GetPurchase), new { id = newPurchase.Id }, newPurchase);
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<IActionResult> UpdatePurchase([FromRoute] int id, [FromBody] UpdatePurchaseDto purchaseDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        
        var existingPurchase = await _purchaseRepo.UpdateAsync(id, purchaseDto)!;

        return Ok(existingPurchase);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<IActionResult> DeletePurchase([FromRoute] int id)
    {
        var existingPurchase = await _purchaseRepo.DeleteAsync(id)!; 
        
        if (existingPurchase is null) return NotFound();

        return NoContent();
    }
}