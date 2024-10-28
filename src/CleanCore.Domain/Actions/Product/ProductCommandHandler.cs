using CleanCore.Domain.Actions.Product.Command;
using CleanCore.Domain.Actions.Product.CommandResult;
using CleanCore.Domain.Entities;
using CleanCore.Domain.Interfaces.Services;
using MediatR;
using Notifications.Core;

namespace CleanCore.Domain.Actions.Product
{
    public class ProductCommandHandler : IRequestHandler<CreateProductCommand, CreateProductCommandResult>
    {
        private readonly IProductService _productService;
        private readonly INotificationHandler _notificationHandler;

        public ProductCommandHandler(IProductService productService, INotificationHandler notificationHandler)
        {
            _productService = productService;
            _notificationHandler = notificationHandler;
        }

        public async Task<CreateProductCommandResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            // TODO: Implementar Validação do command
            if (!request.IsValid())
            {
                _notificationHandler.AddNotification(ProductError.ErrorSavingEntityToTheDatabase.GetDescription(),
                                                     request.Validate());

                return null;
            }

            var newProduct = new Entities.Product(request.Name,
                                                  request.Description,
                                                  request.Units, request.ValuePerUnit,
                                                  request.ExpirationDate);

            var result = await _productService.CreateAsync(newProduct);
            
            if (_notificationHandler.HasNotifications()) return null;

            return new CreateProductCommandResult(result.Id,
                                                  result.Name,
                                                  result.Description,
                                                  result.Units, request.ValuePerUnit,
                                                  result.TotalValue,
                                                  result.ExpirationDate);
        }
    }
}