using System;
using Microsoft.AspNetCore.Mvc;
using MyApp.API.Application.DTOs;
using MyApp.API.Application.Services;
using MyApp.API.Core.Interfaces;

namespace MyApp.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToDoController : ControllerBase
    {
        private readonly IToDoService _toDoInterface;

		public ToDoController(IToDoService toDoInterface)
		{
            _toDoInterface = toDoInterface;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateToDoItem([FromBody] ToDoCreationDTO toDoDTO)
        {
            var result = await _toDoInterface.CreateToDoItem(toDoDTO);
            return Ok(result);
        }
    }
}

