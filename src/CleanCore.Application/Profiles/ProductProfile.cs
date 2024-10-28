using AutoMapper;
using CleanCore.Application.Dtos.Product.Request;
using CleanCore.Application.Dtos.Product.Response;
using CleanCore.Domain.Actions.Product.Command;
using CleanCore.Domain.Actions.Product.CommandResult;
using CleanCore.Domain.Entities;

namespace CleanCore.Application.Profiles;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<CreateProductRequest, CreateProductCommand>();

        CreateMap<CreateProductCommandResult, CreateProductResponse>();

        CreateMap<Product, GetProductResponse>();
    }
}