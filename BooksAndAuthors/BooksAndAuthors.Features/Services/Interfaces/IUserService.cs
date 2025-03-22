using Contracts.UserDto;
using Microsoft.AspNetCore.Http;

namespace BooksAndAuthors.Controllers.Services.Interfaces;

public interface IUserService
{
    Task<IResult> RegisterUserAsync(UserDto userDto);
    Task<IResult> AuthenticateUserAsync(UserDto userDto);
}