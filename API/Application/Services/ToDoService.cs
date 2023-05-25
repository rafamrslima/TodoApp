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
            await CheckIfUserExists(toDoCreationDTO.OwnerId);

            var toDo = new ToDo(toDoCreationDTO.Title, toDoCreationDTO.Deadline, toDoCreationDTO.OwnerId);
            return await _toDoRepository.CreateToDo(toDo);
        }

        public async Task<List<ToDoViewModel>> GetTodoItemsByUserId(Guid userId)
        { 
            await CheckIfUserExists(userId);

            var items = await _toDoRepository.GetTodoItemsByUserId(userId);
            var toDoItemsViewModel = new List<ToDoViewModel>();

            foreach (var item in items)
            {
                toDoItemsViewModel.Add(new ToDoViewModel(item.Id, item.Title, item.CreationDate, item.Deadline, item.Done));
            }

            return toDoItemsViewModel;
        }

        private async Task CheckIfUserExists(Guid userId)
        {
            var user = await _userRepository.GetUserById(userId);
            if (user == null)
                throw new ArgumentException("User not found.");
        } 
    }
}

