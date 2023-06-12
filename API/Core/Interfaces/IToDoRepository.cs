using System;
using MyApp.API.Core.Models;

namespace MyApp.API.Core.Interfaces
{
	public interface ITodoRepository
	{
		Task<Guid> CreateTodo(TodoItem todoItem);
		Task<List<TodoItem>> GetTodoItemsByUserId(Guid userId);
		Task<TodoItem?> GetTodoItemById(Guid itemId);
		Task UpdateStatusItem(Guid itemId, bool isComplete);
		Task EditItem(Guid itemId, string? title, DateTime? Deadline);
		Task DeleteItem(Guid itemId);
    }
}

