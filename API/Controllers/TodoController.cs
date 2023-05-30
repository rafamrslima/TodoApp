using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyApp.API.Application.DTOs;
using MyApp.API.Core.Interfaces;

namespace MyApp.API.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class ToDoController : ControllerBase
{
    private readonly ITodoService _toDoService;

    public ToDoController(ITodoService toDoService)
    {
        _toDoService = toDoService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateToDoItem([FromBody] TodoCreationDTO toDoDTO)
    {
        await _toDoService.CreateTodoItem(toDoDTO);
        return StatusCode(201);
    }

    [HttpGet]
    public async Task<ActionResult<List<TodoViewModel>>> GetToDoItemsByUser([FromQuery] Guid userId)
    {
        return await _toDoService.GetTodoItemsByUserId(userId); 
    }

    [HttpPut("{itemId}")]
    public async Task<IActionResult> UpdateItemStatus(Guid itemId, [FromBody] UpdateTodoStatusDTO updateTodoStatusDTO)
    {
        await _toDoService.UpdateItemStatus(itemId, updateTodoStatusDTO.IsComplete);
        return NoContent();
    }
}

