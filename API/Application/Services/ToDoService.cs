using System;
using MyApp.API.Application.DTOs;
using MyApp.API.Core.Interfaces;
using MyApp.API.Core.Models;
using MyApp.API.Infrastructure.Repositories;

namespace MyApp.API.Application.Services
{
	public class ToDoService : IToDoService
    {
        private readonly IToDoRepository _toDoRepository;
        private readonly IUserRepository _userRepository;

        public ToDoService(IToDoRepository toDoRepository, IUserRepository userRepository)
		{
            _toDoRepository = toDoRepository;
            _userRepository = userRepository;
        }

        public async Task<Guid> CreateToDoItem(ToDoCreationDTO toDoCreationDTO)
        {
            var user = await _userRepository.GetUserById(toDoCreationDTO.OwnerId);
            if (user == null)
                throw new ArgumentException("User not found.");

            var toDo = new ToDo(toDoCreationDTO.Title, toDoCreationDTO.Deadline, toDoCreationDTO.OwnerId);
            return await _toDoRepository.CreateToDo(toDo);
        }
    }
}

