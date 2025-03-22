using BooksAndAuthors.Auth;
using BooksAndAuthors.Auth.Services;
using BooksAndAuthors.Common.Mappings;
using BooksAndAuthors.Controllers.Services.Interfaces;
using BooksAndAuthors.Database;
using BooksAndAuthors.Database.Models;
using Contracts.UserDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BooksAndAuthors.Controllers.Services;

public class UserService: IUserService
{
    private readonly IBookContext _bookContext;
    private readonly JwtTokenHandler _jwtTokenHandler;

    public UserService(IBookContext bookContext, JwtTokenHandler jwtTokenHandler)
    {
        _bookContext = bookContext;
        _jwtTokenHandler = jwtTokenHandler;
    }
    
    public async Task<IResult> RegisterUserAsync(UserDto userDto)
    {
        var newUser = Mapper.FromUserDto(userDto);
        await _bookContext.Users.AddAsync(newUser);
        await _bookContext.SaveChangesAsync();

        return Results.Ok(_jwtTokenHandler.GenerateToken(newUser));
    }

    public async Task<IResult> AuthenticateUserAsync(UserDto userDto)
    {
        var user = await _bookContext.Users.FirstOrDefaultAsync(x => x.Login == userDto.Login);
        var userPasswordHash = PasswordHasher.HashPassword(userDto.Password);
        if (user == null || !PasswordHasher.VerifyPassword(user.Password, userPasswordHash))
        {
            return Results.Unauthorized();
        }

        var token = _jwtTokenHandler.GenerateToken(user);

        return Results.Ok(token);      
    }
}