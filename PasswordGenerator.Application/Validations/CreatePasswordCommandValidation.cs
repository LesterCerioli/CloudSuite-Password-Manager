using FluentValidation;
using PasswordGenerator.Application.Handlers.Passwords;

namespace PasswordGenerator.Application.Validations
{
    public class CreatePasswordCommandValidation : AbstractValidator<CreatePasswordCommand>
    {
        public CreatePasswordCommandValidation()
        {
            RuleFor(p => p.Senha)
                .NotEmpty()
                .WithMessage("The password field is required.")
                .NotNull()
                .WithMessage("The password field cannot be null.")
                .MinimumLength(24)
                .WithMessage("The password must be at least 24 characters long.");

            RuleFor(p => p.CaracterNumber)
                .NotNull()
                .WithMessage("The character number field cannot be null.")
                .GreaterThan(23)
                .WithMessage("The character number must contain at least 24 characters.");

            RuleFor(p => p.CreatedOn)
                
                .LessThanOrEqualTo(DateTimeOffset.Now)
                .WithMessage("The created on date must be in the past or present.");
        }
    }


}
