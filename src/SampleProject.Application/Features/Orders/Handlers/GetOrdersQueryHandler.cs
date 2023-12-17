using AutoMapper;
using MediatR;
using SampleProject.Application.Features.Orders.Queries;
using SampleProject.Application.ViewModels;
using SampleProject.Core.Repositories;
using SampleProject.Core.Entities;

namespace Ordering.Application.Handlers;

public class GetOrdersQueryHandler : IRequestHandler<GetOrders, List<OrderResponse>>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;

    public GetOrdersQueryHandler(IOrderRepository orderRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
    }
    public async Task<List<OrderResponse>> Handle(GetOrders request, CancellationToken cancellationToken)
    {
        IEnumerable<Order> orders = await _orderRepository.GetAllAsync();
        return _mapper.Map<List<OrderResponse>>(orders);
    }
}