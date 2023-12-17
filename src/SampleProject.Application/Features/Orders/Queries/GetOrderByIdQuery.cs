using MediatR;
using SampleProject.Application.ViewModels;

namespace SampleProject.Application.Features.Orders.Queries;

public class GetOrderByIdQuery : IRequest<OrderResponse>
{
    public int OrderId { get; set; }

    public GetOrderByIdQuery(int id)
    {
        OrderId = id;
    }
}