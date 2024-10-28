using CleanCore.Domain.Entities;
using CleanCore.Domain.Interfaces.Repositories;
using CleanCore.Domain.Interfaces.Services;
using Notifications.Core;

namespace CleanCore.Domain.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository _repository;
        private readonly INotificationHandler _notificationHandler;

        public ProductService(IUnitOfWork unitOfWork, IProductRepository repository,
                              INotificationHandler notificationHandler)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _notificationHandler = notificationHandler;
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<List<Product>> GetAllAsync(int pageNumber, int pageSize)
        {
            return await _repository.GetAllAsync(pageNumber, pageSize);
        }

        public async Task<Product> CreateAsync(Product product)
        {
            try
            {
                await _repository.AddAsync(product);
                await _unitOfWork.SaveChangesAsync();
                return product;
            }
            catch(Exception e)
            {
                _notificationHandler.AddNotification(ProductError.ErrorSavingEntityToTheDatabase.GetDescription());
                return null;
            }
        }
    }
}