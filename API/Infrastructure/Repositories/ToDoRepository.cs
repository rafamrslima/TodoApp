using System;
using Microsoft.EntityFrameworkCore;
using MyApp.API.Core.Interfaces;
using MyApp.API.Core.Models;

namespace MyApp.API.Infrastructure.Repositories
{
	public class ToDoRepository : IToDoRepository
    {
        private readonly MyAppDbContext _dbContext;

        public ToDoRepository(MyAppDbContext myAppDbContext)
		{
            _dbContext = myAppDbContext;
        }
         
        public async Task<Guid> CreateToDo(ToDo toDo)
        {
            await _dbContext.ToDos.AddAsync(toDo);
            await _dbContext.SaveChangesAsync();
            return toDo.Id;
        }

        public async Task<List<ToDo>> GetTodoItemsByUserId(Guid userId)
        {
            return await _dbContext.ToDos
                .Where(u => u.OwnerId == userId)
                .OrderByDescending(x=> x.CreationDate)
                .ToListAsync();
        }
    }
}

