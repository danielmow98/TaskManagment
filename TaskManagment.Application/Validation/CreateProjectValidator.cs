using FluentValidation;
using TaskManagment.Application.Features.Projects.CreateProject;

namespace TaskManagment.Application.Validation;

public class CreateProjectValidator : AbstractValidator<CreateProjectCommand>
{
    public CreateProjectValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(200);
        RuleFor(x => x.Description).MaximumLength(1000);
    }
}