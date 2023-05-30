using System;
using MyApp.API.Core.Models;

namespace MyApp.API.Core.Interfaces
{
	public interface ITodoRepository
	{
		Task<Guid> CreateTodo(TodoItem toDo);
		Task<List<TodoItem>> GetTodoItemsByUserId(Guid userId);
		Task<TodoItem?> GetTodoItemById(Guid itemId);
		Task UpdateStatusItem(Guid todoId, bool isComplete);
    }
}

