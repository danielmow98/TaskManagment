using FluentValidation;
using FluentValidation.Validators;

namespace TaskManagment.Application.Features.Tasks;

public class CreateTaskValidator : AbstractValidator<CreateTaskCommand>
{
    public CreateTaskValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .MaximumLength(200);

        RuleFor(x => x.DueDate)
            .GreaterThan(DateTime.UtcNow);
    }
}