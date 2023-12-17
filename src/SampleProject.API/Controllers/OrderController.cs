using SampleProject.API;
using SampleProject.API.Controllers;
using SampleProject.Application.Features.Orders.Commands;
using SampleProject.Application.Features.Orders.Queries;
using SampleProject.Application.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Ordering.API.Controllers;
[Route("orders")]
public class OrderController : BaseController
{
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<OrderResponse>), (int) HttpStatusCode.OK)]
    public async Task<ActionResult<IEnumerable<OrderResponse>>> GetOrders()
    {
        var query = new GetOrders();
        var orders = await Mediator.Send(query);
        var pageInfo =  new Page<dynamic>() { Items = orders, PageNo = 1, PageSize = 10, TotalItemCount = orders.Count };
        return Ok(APIModelFactory.MakePageResponse<dynamic>(0, "Ok", pageInfo));
    }

    [HttpGet("/{id:int}", Name = "GetOrderById")]
    [ProducesResponseType(typeof(IEnumerable<OrderResponse>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<OrderResponse>> GetOrderById(int id)
    {
        var query = new GetOrderByIdQuery(id);
        OrderResponse order = await Mediator.Send(query);
        return Ok(order);
    }

    [HttpPost(Name = "CreateOrder")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<ActionResult<int>> CreateOrder([FromBody] CreateOrderCommand createOrderCommand)
    {
        var result = await Mediator.Send(createOrderCommand);
        return Ok(result);
    }

    [HttpPut("/{id:int}", Name = "UpdateOrder")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> UpdateOrderById(int id, [FromBody] UpdateOrderCommand updateOrderCommand)
    {
        updateOrderCommand.Id = id;
        await Mediator.Send(updateOrderCommand);
        return NoContent();
    }
    
    [HttpDelete("/{id}",Name = "DeleteOrder")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeleteOrderById(int id)
    {
        var deleteOrderCommand = new DeleteOrderCommand() {OrderId = id};
        await Mediator.Send(deleteOrderCommand);
        return NoContent();
    }        
}