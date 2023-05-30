﻿using System;
using MyApp.API.Application.DTOs;
using MyApp.API.Core.Interfaces;
using MyApp.API.Core.Models;
using MyApp.API.Infrastructure.Repositories;

namespace MyApp.API.Application.Services
{
	public class TodoService : ITodoService
    {
        private readonly ITodoRepository _todoRepository;
        private readonly IUserRepository _userRepository;

        public TodoService(ITodoRepository toDoRepository, IUserRepository userRepository)
		{
            _todoRepository = toDoRepository;
            _userRepository = userRepository;
        }

        public async Task<Guid> CreateTodoItem(TodoCreationDTO toDoCreationDTO)
        {
            await CheckIfUserExists(toDoCreationDTO.OwnerId);

            var toDo = new TodoItem(toDoCreationDTO.Title, toDoCreationDTO.Deadline, toDoCreationDTO.OwnerId);
            return await _todoRepository.CreateTodo(toDo);
        }

        public async Task<List<TodoViewModel>> GetTodoItemsByUserId(Guid userId)
        { 
            await CheckIfUserExists(userId);

            var items = await _todoRepository.GetTodoItemsByUserId(userId);
            var toDoItemsViewModel = new List<TodoViewModel>();

            foreach (var item in items)
            {
                toDoItemsViewModel.Add(new TodoViewModel(item.Id, item.Title, item.CreationDate, item.Deadline, item.IsComplete));
            }

            return toDoItemsViewModel;
        }

        public async Task UpdateItemStatus(Guid itemId, bool isComplete)
        {
            var item = await _todoRepository.GetTodoItemById(itemId);

            if (item == null)
                throw new ArgumentException("Todo item not found.");

            await _todoRepository.UpdateStatusItem(itemId, isComplete);
        }

        private async Task CheckIfUserExists(Guid userId)
        {
            var user = await _userRepository.GetUserById(userId);
            if (user == null)
                throw new ArgumentException("User not found.");
        } 
    }
}

