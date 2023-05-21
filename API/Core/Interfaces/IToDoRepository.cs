using System;
using MyApp.API.Core.Models;

namespace MyApp.API.Core.Interfaces
{
	public interface IToDoRepository
	{
		Task<Guid> CreateToDo(ToDo toDo);
		Task<List<ToDo>> GetTodoItemsByUserId(Guid userId);
	}
}

