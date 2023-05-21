using System;
using System.Text.RegularExpressions;
using FluentValidation;
using MyApp.API.Application.DTOs;

namespace MyApp.API.Application.Validators
{
	public class ToDoCreationValidator : AbstractValidator<ToDoCreationDTO>
	{
		public ToDoCreationValidator()
		{
            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage("Title cannot be empty.");

            RuleFor(x => x.OwnerId)
				.NotNull()
                .NotEmpty()
                .WithMessage("Owner should be specified.");

            RuleFor(x => x.Deadline)
				.GreaterThan(DateTime.Now)
				.WithMessage("Deadline has to be greater than current date."); 
		}
	} 
}

