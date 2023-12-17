using MediatR;
using SampleProject.Application.ViewModels;

namespace SampleProject.Application.Features.Orders.Queries;

public class GetOrders : IRequest<List<OrderResponse>>
{ 
}