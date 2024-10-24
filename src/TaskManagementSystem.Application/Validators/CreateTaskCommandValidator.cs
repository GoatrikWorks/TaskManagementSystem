using FluentValidation;
using TaskManagementSystem.Application.Commands.CreateTask;

namespace TaskManagementSystem.Application.Validators
{
    public class CreateTaskCommandValidator : AbstractValidator<CreateTaskCommand>
    {
        public CreateTaskCommandValidator()
        {
            RuleFor(v => v.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(200).WithMessage("Title must not exceed 200 characters.");

            RuleFor(v => v.Description)
                .NotEmpty().WithMessage("Description is required.")
                .MaximumLength(2000).WithMessage("Description must not exceed 2000 characters.");

            RuleFor(v => v.CreatedById)
                .NotEmpty().WithMessage("Creator ID is required.");

            RuleFor(v => v.DueDate)
                .Must(date => !date.HasValue || date.Value > DateTime.UtcNow)
                .WithMessage("Due date must be in the future.");
        }
    }
}
