using System;
namespace MyApp.API.Core.Models;

public class User
{
    public User(string name, string email, string password, string role)
    {
        Id = Guid.NewGuid();
        Name = name;
        Email = email;
        Password = password;
        Role = role;
        CreatedAt = DateTime.Now;
    }
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }
    public DateTime CreatedAt { get; set; }
    public ICollection<ToDo> ToDos { get; set; }
}
