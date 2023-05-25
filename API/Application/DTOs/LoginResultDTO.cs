using System;
namespace MyApp.API.Application.DTOs;

public class LoginResultDTO
{
    public LoginResultDTO(Guid userId, string email, string token)
    {
        UserId = userId;
        Email = email;
        Token = token;
    }

    public Guid UserId { get; set; }
    public string Email { get; set; }
    public string Token { get; set; }
}

