using System;
using Microsoft.AspNetCore.Mvc;
using MyApp.API.Application.DTOs;
using MyApp.API.Core.Interfaces;

namespace MyApp.API.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateUser([FromBody] UserCreationDTO userDTO)
    {
        var result = await _userService.CreateUser(userDTO);
        return Ok(result);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UserLoginDTO userLoginDTO)
    {
        var loginResult = await _userService.Login(userLoginDTO.Email, userLoginDTO.Password);
        return Ok(loginResult);

    }
}