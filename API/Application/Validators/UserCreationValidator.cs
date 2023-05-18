using System;
using System.Text.RegularExpressions;
using FluentValidation;
using MyApp.API.Application.DTOs;

namespace MyApp.API.Application.Validators
{
	public class UserCreationValidator : AbstractValidator<UserCreationDTO>
	{
		public UserCreationValidator()
		{
			RuleFor(x => x.Email)
				.EmailAddress()
				.WithMessage("Invalid email.");

			RuleFor(x => x.Password)
				.Must(ValidPassword)
				.WithMessage("Password must have minimum eight characters, at least one letter and one number.");

			RuleFor(x => x.Name)
				.NotEmpty()
				.NotNull()
				.MinimumLength(4)
				.WithMessage("Name is required.");
		}

		public bool ValidPassword(string password)
		{
			var regex = new Regex(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$");
			return regex.IsMatch(password);
        }
	}
}

