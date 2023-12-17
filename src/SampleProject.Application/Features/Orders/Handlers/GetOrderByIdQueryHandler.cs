using AutoMapper;
using MediatR;
using SampleProject.Application.Features.Orders.Queries;
using SampleProject.Application.ViewModels;
using SampleProject.Core.Repositories;
using SampleProject.Core.Entities;
using SampleProject.Application.Exceptions;

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