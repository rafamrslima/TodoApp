using System;
using MyApp.API.Core.Models;

namespace MyApp.API.Application.DTOs
{
	public class TodoViewModel
	{
        public TodoViewModel(Guid id, string title, DateTime creationDate, DateTime deadline, bool isComplete)
        {
            Id = id;
            Title = title;
            CreationDate = creationDate;
            Deadline = deadline;
            IsComplete = isComplete;
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime Deadline { get; set; }
        public bool IsComplete { get; set; } 
    }
}

