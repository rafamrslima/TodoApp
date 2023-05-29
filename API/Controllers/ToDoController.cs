using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyApp.API.Application.DTOs;
using MyApp.API.Application.Services;
using MyApp.API.Core.Interfaces;

namespace MyApp.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class ToDoController : ControllerBase
    {
        private readonly IToDoService _toDoService;

		public ToDoController(IToDoService toDoService)
		{
            _toDoService = toDoService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateToDoItem([FromBody] ToDoCreationDTO toDoDTO)
        {
            var result = await _toDoService.CreateToDoItem(toDoDTO);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetToDoItemsByUser([FromQuery] Guid userId)
        {
            var result = await _toDoService.GetTodoItemsByUserId(userId);
            return Ok(result);
        }
    }
}

