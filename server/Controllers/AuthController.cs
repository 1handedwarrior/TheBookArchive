using BooksProj.Dtos.AccountDtos;
using BooksProj.Interfaces;
using BooksProj.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BooksProj.Controllers;


[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }
    
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var (isSuccess, userDto, errors) = await _authService.RegisterAsync(registerDto);
        
        if (!isSuccess) return BadRequest(errors);

        return Ok(userDto);
    }


    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var (isSuccess, userDto, errorMessage) = await _authService.LoginAsync(loginDto);

        if (!isSuccess) return Unauthorized(errorMessage);

        return Ok(userDto);
    }
}