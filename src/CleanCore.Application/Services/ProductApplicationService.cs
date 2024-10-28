using AutoMapper;
using CleanCore.Application.Dtos.Product.Request;
using CleanCore.Application.Dtos.Product.Response;
using CleanCore.Application.Interfaces;
using CleanCore.Domain.Actions.Product.Command;
using CleanCore.Domain.Interfaces.ReadRepositories;
using MediatR;

namespace CleanCore.Application.Services
{
    public class ProductApplicationService : IProductApplicationService
    {
        private readonly IMapper _mapper;
        private readonly IProductReadRepository _productReadRepository;
        private readonly IMediator _mediator;

        public ProductApplicationService(IMapper mapper, IProductReadRepository productReadRepository, IMediator mediator)
        {
            _mapper = mapper;
            _productReadRepository = productReadRepository;
            _mediator = mediator;
        }

        public async Task<CreateProductResponse> CreateAsync(CreateProductRequest request)
        {
            var result = await _mediator.Send(_mapper.Map<CreateProductCommand>(request));
            return _mapper.Map<CreateProductResponse>(result);
        }

        public async Task<List<GetProductResponse>> GetAllAsync()
        {
            var result = (await _productReadRepository.GetAllAsync()).ToList();
            return _mapper.Map<List<GetProductResponse>>(result);
        }
    }
}