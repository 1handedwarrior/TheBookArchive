using BooksProj.Models;

namespace BooksProj.Interfaces;

public interface ITokenService
{
    string CreateToken(AppUser user);
}