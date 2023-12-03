using AutoMapper;
using MediatR;
using Kanini.Application.Features.Orders.Queries;
using Kanini.Application.ViewModels;
using Kanini.Core.Repositories;
using Kanini.Core.Entities;
using Kanini.Application.Exceptions;

namespace Ordering.Application.Handlers;

public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, OrderResponse>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;

    public GetOrderByIdQueryHandler(IOrderRepository orderRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
    }
    public async Task<OrderResponse> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        Order order = await _orderRepository.GetByIdAsync(request.OrderId);
        
        if (order == null)
        {
            throw new OrderNotFoundException(nameof(Order), request.OrderId);
        }

        return _mapper.Map<OrderResponse>(order);
    }
}