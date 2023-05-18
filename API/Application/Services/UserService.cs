using System;
using Microsoft.EntityFrameworkCore;
using MyApp.API.Application.Constants;
using MyApp.API.Application.DTOs;
using MyApp.API.Infrastructure;
using MyApp.API.Core.Interfaces;
using MyApp.API.Core.Models;

namespace MyApp.API.Application.Services;

public class UserService : IUserService
{
    private readonly IAuthService _authService;
    private readonly IUserRepository _userRepository;

    public UserService(IAuthService authService, IUserRepository userRepository)
    {
        _authService = authService;
        _userRepository = userRepository;
    }

    public async Task<Guid> CreateUser(UserCreationDTO userDTO)
    {
        var userAlreadyExists = await _userRepository.GetUserByEmail(userDTO.Email);
        if (userAlreadyExists)
            throw new ArgumentException("This email is already being used.");

        var passwordHash = _authService.computeSha256Hash(userDTO.Password);
        var user = new User(userDTO.Name, userDTO.Email, passwordHash, Roles.User);
        return await _userRepository.AddUser(user); 
    }

    public async Task<LoginResultDTO> Login(string email, string password)
    {
        var passwordHash = _authService.computeSha256Hash(password);
        var user = await _userRepository.GetUserByEmailAndPassword(email, passwordHash);

        if (user == null)
            throw new KeyNotFoundException("User or password invalid.");

        var token = _authService.GenerateJwtToken(email, Roles.User);
        return new LoginResultDTO(user.Email, token);
    }
}

