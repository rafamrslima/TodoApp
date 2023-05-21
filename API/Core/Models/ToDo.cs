using System;
namespace MyApp.API.Core.Models;

public class ToDo
{
    public ToDo(string title, DateTime deadline, Guid ownerId)
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
    public DateTime Deadline { get; set; }
    public bool Done { get; set; }
    public Guid OwnerId { get; set; }
    public User Owner { get; set; }
}