using Application.DTOs;
using FluentValidation;

namespace Application.Validators;

public class CreateProductValidator : AbstractValidator<CreateProductDto>
{
    public CreateProductValidator()
    {
        RuleFor(x => x.ProductName)
            .NotEmpty().WithMessage("Product Name is required.")
            .MaximumLength(255).WithMessage("Product Name cannot exceed 255 characters.");

        RuleFor(x => x.CreatedBy)
            .NotEmpty().WithMessage("Created By is required.")
            .MaximumLength(100).WithMessage("Created By cannot exceed 100 characters.");
    }
}