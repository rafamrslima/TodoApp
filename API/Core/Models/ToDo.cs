using System;
namespace MyApp.API.Core.Models;

public class TodoItem
{
    public TodoItem(string title, DateTime? deadline, Guid ownerId)
    {
        Id = Guid.NewGuid();
        Title = title;
        CreationDate = DateTime.Now;
        Deadline = deadline;
        OwnerId = ownerId;
    }

    public Guid Id { get; set; }
    public string Title { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime? Deadline { get; set; }
    public bool IsComplete { get; set; }
    public Guid OwnerId { get; set; }
    public User? Owner { get; set; }
}