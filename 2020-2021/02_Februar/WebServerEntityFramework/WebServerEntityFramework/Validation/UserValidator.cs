using FluentValidation;
using WebServer.Database.Models;
using WebServerEntityFramework.DTOs;

namespace WebServerEntityFramework.Validation
{
    public class UserValidator : AbstractValidator<UserDto>
    {
        public UserValidator()
        {
            RuleFor(x => x.Name).NotEmpty().Length(1, 30);
            RuleFor(x => x.DayOfBirth)
                .NotEmpty()
                .Must(x => x.Year > 2000).WithMessage("2000 előtt születtél, nem regisztrálhatsz.");
        }
    }
}
