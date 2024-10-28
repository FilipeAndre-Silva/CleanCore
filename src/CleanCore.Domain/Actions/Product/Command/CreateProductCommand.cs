using CleanCore.Domain.Actions.Product.CommandResult;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace CleanCore.Domain.Actions.Product.Command;

public class CreateProductCommand : IRequest<CreateProductCommandResult>
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public int Units { get; private set; }
    public double ValuePerUnit { get; private set; }
    public double TotalValue { get; private set; }
    public DateTime ExpirationDate { get; private set; }

    public bool IsValid()
    {
        var validator = new CreateProductCommandValidator();
        var validationResult = validator.Validate(this);
        return validationResult.IsValid;
    }

    public ValidationResult Validate()
    {
        var validator = new CreateProductCommandValidator();
        return validator.Validate(this);
    }
}

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(command => command.Name)
            .NotEmpty().WithMessage("Product name is required.")
            .Length(2, 100).WithMessage("Product name must be between 2 and 100 characters.");

        RuleFor(command => command.Description)
            .NotEmpty().WithMessage("Product description is required.")
            .Length(10, 500).WithMessage("Product description must be between 10 and 500 characters.");

        RuleFor(command => command.Units)
            .GreaterThan(0).WithMessage("Units must be greater than zero.");

        RuleFor(command => command.ValuePerUnit)
            .GreaterThan(0).WithMessage("Value per unit must be greater than zero.");

        RuleFor(command => command.ExpirationDate)
            .GreaterThan(DateTime.Now).WithMessage("Expiration date must be in the future.");
    }
}