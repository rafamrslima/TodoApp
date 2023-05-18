using System;
namespace MyApp.API.Core.Models
{
	public class ToDo
	{
        public ToDo(Guid id, string title, DateTime deadline, User user)
        {
            Id = id;
            Title = title;
            CreationDate = DateTime.Now;
            Deadline = deadline;
            User = user;
        }

        public Guid Id { get; set; }
		public string Title { get; set; }
		public DateTime CreationDate { get; set; }
		public DateTime Deadline { get; set; }
        public bool Done { get; set; }
        public User User { get; set; }
	}
}