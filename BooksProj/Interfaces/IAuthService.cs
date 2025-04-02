using BooksProj.Dtos.AccountDtos;
using Microsoft.AspNetCore.Identity;

namespace BooksProj.Interfaces;

public interface IAuthService
{
    Task<(bool isSuccess, NewUserDto? userDto, IEnumerable<IdentityError>? errors)> RegisterAsync(RegisterDto registerDto);
    Task<(bool isSuccess, NewUserDto? userDto, string? ErrorMessage)> LoginAsync(LoginDto loginDto);
}