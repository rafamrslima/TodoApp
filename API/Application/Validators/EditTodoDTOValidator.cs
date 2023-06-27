using System;
using FluentValidation;
using MyApp.API.Application.DTOs;

namespace MyApp.API.Application.Validators
{
	public class EditTodoDTOValidator : AbstractValidator<EditTodoDTO>
    {
		public EditTodoDTOValidator()
		{
            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage("Title cannot be empty.");

            RuleFor(x => x.Title)
                .MinimumLength(3)
                .WithMessage("Title must have at least 3 characters.");
        }
	}
}

