using System.Security.Claims;
using BooksProj.Dtos.BookDtos;
using BooksProj.Helpers;
using BooksProj.Interfaces;
using Microsoft.AspNetCore.Mvc;
using BooksProj.Mappers;
using BooksProj.Models;
using Microsoft.AspNetCore.Identity;

namespace BooksProj.Controllers;

[ApiController]
[Route("api/books")]
public class BooksController : ControllerBase
{
    private readonly IBookRepository _bookRepo;
    private readonly ICacheService _cache;
    private readonly string _removeCacheKey = DynamicCacheKey.GetRemoveAllCacheKey(); 

    public BooksController(IBookRepository bookRepo, ICacheService cache)
    {
        _bookRepo = bookRepo;
        _cache = cache;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetBooks([FromQuery] QueryObject query)
    {
        string cacheKey = DynamicCacheKey.GetCacheKey(query);
        
        var books = _cache.Get<List<Book>>(cacheKey);

        if (books is null)
        {
            books = await _bookRepo.GetAllAsync(query);
            
            _cache.Set(cacheKey, books, TimeSpan.FromSeconds(45), TimeSpan.FromHours(1));
        }
        
        return Ok(books.Select(b => b.ToBookDto()));
    }
    
    [HttpGet]
    [Route("{id:int}")]
    public async Task<IActionResult> GetBook([FromRoute] int id)
    {
        var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (user is null) return Unauthorized();
        
        var book = await _bookRepo.GetByIdAsync(id, user);

        if (book is null) return NotFound();
        
        return Ok(book.ToBookDto());
    }

    [HttpPost]
    public async Task<IActionResult> CreateBook([FromBody] CreateBookDto bookDto)
    {
        var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (user is null) return Unauthorized();
        
        if (!ModelState.IsValid) return BadRequest();

        var newBook = await _bookRepo.CreateAsync(bookDto, user);
        
        _cache.Remove(_removeCacheKey);
        
        return CreatedAtAction(nameof(GetBook), new { id = newBook.Id }, newBook.ToBookDto());
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<IActionResult> UpdateBook([FromRoute] int id, [FromBody] UpdateBookDto bookDto)
    {
        var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (user is null) return Unauthorized();
        
        if (!ModelState.IsValid) return BadRequest();

        var exitingBook = await _bookRepo.UpdateAsync(id, bookDto, user);
        
        _cache.Remove(_removeCacheKey);
        
        return Ok(exitingBook);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<IActionResult> DeleteBook([FromRoute] int id)
    {
        var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (user is null) return Unauthorized();
        
        var deletedBook = await _bookRepo.DeleteAsync(id, user);

        if (deletedBook is null) return NotFound();
        
        _cache.Remove(_removeCacheKey);
        
        return NoContent();
    }
}