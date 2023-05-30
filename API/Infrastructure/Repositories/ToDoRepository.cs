using System;
using Microsoft.EntityFrameworkCore;
using MyApp.API.Core.Interfaces;
using MyApp.API.Core.Models;

namespace MyApp.API.Infrastructure.Repositories
{
	public class TodoRepository : ITodoRepository
    {
        private readonly MyAppDbContext _dbContext;

        public TodoRepository(MyAppDbContext myAppDbContext)
		{
            _dbContext = myAppDbContext;
        }
         
        public async Task<Guid> CreateTodo(TodoItem toDo)
        {
            await _dbContext.ToDos.AddAsync(toDo);
            await _dbContext.SaveChangesAsync();
            return toDo.Id;
        }

        public async Task<TodoItem?> GetTodoItemById(Guid todoId)
        {
            return await _dbContext.ToDos.SingleOrDefaultAsync(x => x.Id == todoId);
        }

        public async Task<List<TodoItem>> GetTodoItemsByUserId(Guid userId)
        {
            return await _dbContext.ToDos
                .Where(u => u.OwnerId == userId)
                .OrderByDescending(x=> x.CreationDate)
                .ToListAsync();
        }

        public async Task UpdateStatusItem(Guid todoId, bool isComplete)
        {
            var item = await _dbContext.ToDos.SingleOrDefaultAsync(x => x.Id == todoId);
            if (item != null)
            {
                item.IsComplete = isComplete;
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}

