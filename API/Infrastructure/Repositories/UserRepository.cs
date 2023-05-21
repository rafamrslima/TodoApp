using System;
using Microsoft.EntityFrameworkCore;
using MyApp.API.Core.Interfaces;
using MyApp.API.Core.Models;

namespace MyApp.API.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly MyAppDbContext _dbContext;

    public UserRepository(MyAppDbContext dbContext)
	{
        _dbContext = dbContext;
	}

    public async Task<Guid> AddUser(User user)
    {
        await _dbContext.Users.AddAsync(user);
        await _dbContext.SaveChangesAsync(); 
        return user.Id; 
    }

    public async Task<bool> GetUserByEmail(string email)
    {
        return await _dbContext.Users.AnyAsync(x => x.Email == email);
    }

    public async Task<User?> GetUserById(Guid id)
    {
        return await _dbContext.Users.SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task<User?> GetUserByEmailAndPassword(string email, string password)
    {
        return await _dbContext.Users.SingleOrDefaultAsync(x => x.Email == email && x.Password == password);
    }
}

