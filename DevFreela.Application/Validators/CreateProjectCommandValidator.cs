using DevFreela.Application.Commands.CreateProject;
using FluentValidation;

namespace DevFreela.Application.Validators
{
    public class CreateProjectCommandValidator : AbstractValidator<CreateProjectCommands>
    {
        public CreateProjectCommandValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .NotNull()
                .MaximumLength(30)
                .WithMessage("Tamanho maximo do titulo deve ser 30 caracteres !");

            RuleFor(x => x.Description)
                .NotEmpty()
                .NotNull()
                .MaximumLength(255)
                .WithMessage("Tamanho maximo da descrição deve ser 255 caracteres !");

            RuleFor(x => x.IdFreelancer)
                .NotNull()
                .NotEmpty()
                .WithMessage("Campo idFreelancer é obrigatorio !");
                
        }
    }
}
