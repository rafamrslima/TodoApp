using System;
using MyApp.API.Application.DTOs;
using MyApp.API.Core.Interfaces;
using MyApp.API.Core.Models;

namespace MyApp.API.Application.Services
{
	public class ToDoService : IToDoService
    {
		public ToDoService()
		{
		}

        public async Task<Guid> CreateToDoItem(ToDoCreationDTO toDoCreationDTO)
        {
            throw new NotImplementedException();
        }
    }
}

