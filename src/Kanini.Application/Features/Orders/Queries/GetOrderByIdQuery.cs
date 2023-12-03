using MediatR;
using Kanini.Application.ViewModels;

namespace Kanini.Application.Features.Orders.Queries;

public class GetOrderByIdQuery : IRequest<OrderResponse>
{
    public int OrderId { get; set; }

    public GetOrderByIdQuery(int id)
    {
        OrderId = id;
    }
}