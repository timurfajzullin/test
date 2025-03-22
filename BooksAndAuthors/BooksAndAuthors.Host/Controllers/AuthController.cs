using BooksAndAuthors.Controllers.Services.Interfaces;
using Contracts.UserDto;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BooksAndAuthors.Controllers;

[Route("/Auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IUserService _userService;

    public AuthController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("/register")]
    public async Task<IActionResult> RegisterUserAsync(UserDto userDto)
    {
        var token = await _userService.RegisterUserAsync(userDto);
        return Ok(token);
    }

    [HttpPost("/login")]
    public async Task<IActionResult> LoginUserAadAsync(UserDto userDto)
    {
        var token = await _userService.AuthenticateUserAsync(userDto);
        return Ok(token);
    }
}