using FluentValidation;
using FluentValidation.Results;

namespace CleanCore.Application.Dtos.Product.Request;

public class CreateProductRequest
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Units { get; set; }
    public double ValuePerUnit { get; set; }
    public double TotalValue { get; set; }
    public DateTime ExpirationDate { get; set; }
}