using DevFreela.Application.Commands.CreateUser;
using FluentValidation;
using System.Text.RegularExpressions;

namespace DevFreela.Application.Validators
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.Email)
                .EmailAddress()
                .WithMessage("E-mail não valido !");

            RuleFor(x => x.Password)
                .Must(ValidPasswaord)
                .WithMessage("Senha deve conter pelo menos 8 caracteres um número, uma letra minúscula, uma letra maiuscúla, e um caractere especial !  ");

            RuleFor(x => x.FullName)
                .NotNull()
                .NotEmpty()
                .WithMessage("Campo nome Obrigatorio !");
        }

        public bool ValidPasswaord(string password)
        {
            var regex = new Regex(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$");

            return regex.IsMatch(password);
        }
    }
}
