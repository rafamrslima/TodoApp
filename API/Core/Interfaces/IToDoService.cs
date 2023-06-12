using System;
using MyApp.API.Application.DTOs;
using MyApp.API.Core.Models;

namespace MyApp.API.Core.Interfaces
{
	public interface ITodoService
	{
		Task<Guid> CreateTodoItem(TodoCreationDTO toDoCreationDTO);
        Task<List<TodoViewModel>> GetTodoItemsByUserId(Guid userId);
		Task UpdateItemStatus(Guid itemId, bool isComplete);
		Task EditItem(Guid itemId, EditTodoDTO editTodoDTO);
		Task DeleteItem(Guid itemId);
    }
}