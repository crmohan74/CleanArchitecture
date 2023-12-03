using AutoMapper;
using MediatR;
using Kanini.Application.Features.Orders.Queries;
using Kanini.Application.ViewModels;
using Kanini.Core.Repositories;
using Kanini.Core.Entities;

namespace Ordering.Application.Handlers;

public class GetOrdersQueryHandler : IRequestHandler<GetOrdersByUserNameQuery, List<OrderResponse>>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;

    public GetOrdersQueryHandler(IOrderRepository orderRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
    }
    public async Task<List<OrderResponse>> Handle(GetOrdersByUserNameQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<Order> orders = await _orderRepository.GetOrdersByUserName(request.UserName);
        return _mapper.Map<List<OrderResponse>>(orders);
    }
}