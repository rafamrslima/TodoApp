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
         
        public async Task<Guid> CreateTodo(TodoItem todoItem)
        {
            await _dbContext.ToDos.AddAsync(todoItem);
            await _dbContext.SaveChangesAsync();
            return todoItem.Id;
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

        public async Task UpdateStatusItem(Guid itemId, bool isComplete)
        {
            var item = await GetTodoItemById(itemId);
            if (item != null)
            {
                item.IsComplete = isComplete;
                await _dbContext.SaveChangesAsync();
            }
        }

         public async Task EditItem(Guid itemId, string? title, DateTime? deadline)
        {
            var item = await GetTodoItemById(itemId);
            if (item != null)
            {
                item.Title = title;
                item.Deadline = deadline;
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteItem(Guid itemId)
        {
            var item = await GetTodoItemById(itemId);
            if (item != null)
            {
                _dbContext.Remove(item);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}

