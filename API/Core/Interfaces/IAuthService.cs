using System;
namespace MyApp.API.Core.Interfaces;

public interface IAuthService
{
	string GenerateJwtToken(string email, string role);
	string computeSha256Hash(string password);
}

