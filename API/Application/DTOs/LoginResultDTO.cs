using System;
namespace MyApp.API.Application.DTOs;

public class LoginResultDTO
{
    public LoginResultDTO(string email, string token)
    {
        Email = email;
        Token = token;
    }

    public string Email { get; set; }
    public string Token { get; set; }
}

