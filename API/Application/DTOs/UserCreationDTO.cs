using System;
namespace MyApp.API.Application.DTOs;

public class UserCreationDTO
{
	public string Name { get; set; }
	public string Email { get; set; }
	public string Password { get; set; }
}