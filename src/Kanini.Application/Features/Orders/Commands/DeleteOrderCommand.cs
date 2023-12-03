using MediatR;

namespace Kanini.Application.Features.Orders.Commands;
public class DeleteOrderCommand : IRequest
{
    public int OrderId { get; set; }
}