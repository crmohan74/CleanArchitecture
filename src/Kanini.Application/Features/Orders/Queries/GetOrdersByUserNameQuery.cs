using MediatR;
using Kanini.Application.ViewModels;

namespace Kanini.Application.Features.Orders.Queries;

public class GetOrdersByUserNameQuery : IRequest<List<OrderResponse>>
{
    public string UserName { get; set; }

    public GetOrdersByUserNameQuery(string userName)
    {
        UserName = userName;
    }
}