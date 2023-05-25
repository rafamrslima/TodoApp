using System;
using MyApp.API.Application.DTOs;
using MyApp.API.Core.Models;

namespace MyApp.API.Core.Interfaces
{
	public interface IToDoService
	{
		Task<Guid> CreateToDoItem(ToDoCreationDTO toDoCreationDTO);
        Task<List<ToDoViewModel>> GetTodoItemsByUserId(Guid userId);
    }
}