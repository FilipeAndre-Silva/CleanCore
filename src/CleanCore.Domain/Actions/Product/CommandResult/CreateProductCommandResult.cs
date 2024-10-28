using FluentValidation.Results;
using Microsoft.Extensions.Options;

namespace CleanCore.Domain.Actions.Product.CommandResult;

public class CreateProductCommandResult
{

    public CreateProductCommandResult(ValidationResult validationResult)
    {
        validationResult.Errors = validationResult.Errors;
    }

    public CreateProductCommandResult(int id, string name, string description, int units, double valuePerUnit, double totalValue, DateTime expirationDate)
    {
        Id = id;
        Name = name;
        Description = description;
        Units = units;
        ValuePerUnit = valuePerUnit;
        TotalValue = totalValue;
        ExpirationDate = expirationDate;
    }

    public int Id { get; set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public int Units { get; private set; }
    public double ValuePerUnit { get; private set; }
    public double TotalValue { get; private set; }
    public DateTime ExpirationDate { get; private set; }
    public ValidationResult ValidationResult { get; set; }
}
