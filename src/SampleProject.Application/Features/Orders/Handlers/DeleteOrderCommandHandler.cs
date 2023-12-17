using MediatR;
using Microsoft.Extensions.Logging;
using SampleProject.Application.Features.Orders.Commands;
using SampleProject.Application.Exceptions;
using SampleProject.Core.Entities;
using SampleProject.Core.Repositories;

namespace SampleProject.Application.Features.Orders.Handlers;

public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand>
{
    private readonly IOrderRepository _orderRepository;
    private readonly ILogger<DeleteOrderCommandHandler> _logger;

    public DeleteOrderCommandHandler(IOrderRepository orderRepository, ILogger<DeleteOrderCommandHandler> logger)
    {
        _orderRepository = orderRepository;
        _logger = logger;
    }
    public async Task<Unit> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
    {
        var orderToDelete = await _orderRepository.GetByIdAsync(request.OrderId);
        if (orderToDelete == null)
        {
            throw new OrderNotFoundException(nameof(Order), request.OrderId);
        }

        await _orderRepository.DeleteAsync(orderToDelete);
        _logger.LogInformation($"Order with Id {request.OrderId} is deleted successfully.");
        return Unit.Value;
    }
}