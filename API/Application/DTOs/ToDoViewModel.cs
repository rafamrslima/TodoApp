using System;
using MyApp.API.Core.Models;

namespace MyApp.API.Application.DTOs
{
	public class ToDoViewModel
	{
        public ToDoViewModel(Guid id, string title, DateTime creationDate, DateTime deadline, bool done)
        {
            Id = id;
            Title = title;
            CreationDate = creationDate;
            Deadline = deadline;
            Done = done;
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime Deadline { get; set; }
        public bool Done { get; set; } 
    }
}

