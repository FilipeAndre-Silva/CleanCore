using CleanCore.Application.Dtos.Product.Request;
using CleanCore.Application.Dtos.Product.Response;
using CleanCore.Domain.Entities;

namespace CleanCore.Application.Interfaces;

public interface IProductApplicationService
{
    Task<CreateProductResponse> CreateAsync(CreateProductRequest request);
    Task<List<GetProductResponse>> GetAllAsync();
}