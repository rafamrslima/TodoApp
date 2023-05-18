using System;
using MyApp.API.Application.DTOs;
using MyApp.API.Core.Models;

namespace MyApp.API.Core.Interfaces;

public interface IUserService
{
    Task<Guid> CreateUser(UserCreationDTO userDTO);
    Task<LoginResultDTO> Login(string email, string password);
}

