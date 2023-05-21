using System;
using MyApp.API.Core.Models;

namespace MyApp.API.Core.Interfaces;

public interface IUserRepository
{
	Task<Guid> AddUser(User user);
    Task<bool> GetUserByEmail(string email);
    Task<User?> GetUserById(Guid id);
    Task<User?> GetUserByEmailAndPassword(string email, string password);
}

