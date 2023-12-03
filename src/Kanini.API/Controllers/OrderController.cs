using Kanini.API.Controllers;
using Kanini.Application.Features.Orders.Commands;
using Kanini.Application.Features.Orders.Queries;
using Kanini.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Ordering.API.Controllers;
[Route("orders/")]
public class OrderController : BaseController
{
    [HttpGet("{userName}", Name = "GetOrdersByUserName")]
    [ProducesResponseType(typeof(IEnumerable<OrderResponse>), (int) HttpStatusCode.OK)]
    public async Task<ActionResult<IEnumerable<OrderResponse>>> GetOrdersByUserName(string userName)
    {
        var query = new GetOrdersByUserNameQuery(userName);
        IEnumerable<OrderResponse> orders = await Mediator.Send(query);
        return Ok(orders);
    }

    [HttpGet("{id:int}", Name = "GetOrderById")]
    [ProducesResponseType(typeof(IEnumerable<OrderResponse>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<OrderResponse>> GetOrderById(int id)
    {
        var query = new GetOrderByIdQuery(id);
        OrderResponse order = await Mediator.Send(query);
        return Ok(order);
    }

    [HttpPost(Name = "CheckoutOrder")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<ActionResult<int>> CheckoutOrder([FromBody] CheckoutOrderCommand command)
    {
        var result = await Mediator.Send(command);
        return Ok(result);
    }

    [HttpPut(Name = "UpdateOrder")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> UpdateOrder([FromBody] UpdateOrderCommand command)
    {
        await Mediator.Send(command);
        return NoContent();
    }
    
    [HttpDelete("{id}",Name = "DeleteOrder")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeleteOrderById(int id)
    {
        var cmd = new DeleteOrderCommand() {OrderId = id};
        await Mediator.Send(cmd);
        return NoContent();
    }    
}