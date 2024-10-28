using CleanCore.Application.Dtos.Product.Request;
using CleanCore.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Notifications.Core;

namespace CleanCore.Presentation.API.Controllers;

[ApiController]
[Route("api/product")]
public class ProductController : ControllerBase
{
    private readonly IProductApplicationService _productApplicationService;
    INotificationHandler _notificationHandler;
    private readonly ApiResponseHandler _responseHandler;

    public ProductController(IProductApplicationService productApplicationService, INotificationHandler notificationHandler, ApiResponseHandler responseHandler)
    {
        _notificationHandler = notificationHandler;
        _productApplicationService = productApplicationService;
        _responseHandler = responseHandler;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateProductRequest request)
    {
        var result = await _productApplicationService.CreateAsync(request);
        return _responseHandler.CreateResponse(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await _productApplicationService.GetAllAsync();
        return Ok(result);
    }
}

public class ApiResponseHandler
{
    private readonly NotificationHandler _notificationHandler;

    public ApiResponseHandler(NotificationHandler notificationHandler)
    {
        _notificationHandler = notificationHandler;
    }

    public IActionResult CreateResponse(object result = null)
    {
        // Verifica se há notificações
        if (_notificationHandler.HasNotifications())
        {
            var notifications = _notificationHandler.GetNotifications()
                .Select(n => new
                {
                    Message = n.Message,
                    Errors = n.ValidationResult?.Errors.Select(e => new
                    {
                        e.PropertyName,
                        e.ErrorMessage
                    })
                });

            // Retorna as notificações em um formato amigável
            return new BadRequestObjectResult(new
            {
                Success = false,
                Errors = notifications
            });
        }

        // Retorna a resposta de sucesso
        return new OkObjectResult(new
        {
            Success = true,
            Data = result
        });
    }
}