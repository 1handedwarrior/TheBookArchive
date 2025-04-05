using BooksProj.Dtos.AccountDtos;
using BooksProj.Interfaces;
using BooksProj.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BooksProj.Services;

public class AuthService : IAuthService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly ITokenService _tokenService;

    public AuthService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenService tokenService)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _tokenService = tokenService;
    }

    public async Task<(bool isSuccess, NewUserDto? userDto, IEnumerable<IdentityError>? errors)> RegisterAsync(RegisterDto registerDto)
    {
        var appUser = new AppUser
        {
            UserName = registerDto.Username,
            Email = registerDto.Email
        };

        var createdUser = await _userManager.CreateAsync(appUser, registerDto.Password!);

        if (!createdUser.Succeeded) return (false, null, createdUser.Errors);

        var roleResult = await _userManager.AddToRoleAsync(appUser, "User");
        
        if (!roleResult.Succeeded) return (false, null, roleResult.Errors);
        
        var newUser = new NewUserDto
        {
            Username = appUser.UserName!,
            Email = appUser.Email!,
            Token = _tokenService.CreateToken(appUser)
        };

        return (true, newUser, null);
    }

    public async Task<(bool isSuccess, NewUserDto? userDto, string? ErrorMessage)> LoginAsync(LoginDto loginDto)
    {
        var user = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == loginDto.Username);

        if (user is null) return (false, null, "Username invalid");

        var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password!, false);

        if (!result.Succeeded) return (false, null, "Username or password invalid");
        
        var newUser = new NewUserDto
        {
            Username = user.UserName!,
            Email = user.Email!,
            Token = _tokenService.CreateToken(user)
        };

        return (true, newUser, null);
    }
}