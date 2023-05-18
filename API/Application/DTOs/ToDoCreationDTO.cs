using System;
namespace MyApp.API.Application.DTOs
{
	public class ToDoCreationDTO
	{
		public Guid UserId { get; set; }
		public string Title { get; set; }
		public DateTime Deadline { get; set; }
	}
}