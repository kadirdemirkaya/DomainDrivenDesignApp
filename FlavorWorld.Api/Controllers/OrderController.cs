using System.Net;
using AutoMapper;
using FlavorWorld.Application.Features.Commands.Orders.CreateOrder;
using FlavorWorld.Application.Features.Commands.Orders.DeleteOrder;
using FlavorWorld.Application.Features.Commands.Orders.UpdateOrder;
using FlavorWorld.Application.Features.Query.Orders.GetProduct;
using FlavorWorld.Contracts.Models.Orders;
using FlavorWorld.Contracts.Models.Products;
using FlavorWorld.Domain.Aggregates.OrderAggregate;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FlavorWorld.Api.Controllers;

[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly IMediator _mediatr;
    private readonly IMapper _mapper;

    public OrderController(IMediator mediatr, IMapper mapper)
    {
        _mediatr = mediatr;
        _mapper = mapper;
    }

    [Route("Create-Order")]
    [HttpPost]
    [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(bool), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> CreateOrder([FromBody] CreateOrderCommandDto createOrderCommandDto)
    {
        bool result = await _mediatr.Send(_mapper.Map<CreateOrderCommand>(createOrderCommandDto));
        return result is true ? Ok(true) : BadRequest(false);
    }

    [Route("Delete-Order")]
    [HttpDelete]
    [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(bool), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> DeleteOrder([FromHeader] DeleteOrderCommandDto deleteOrderCommandDto)
    {
        bool result = await _mediatr.Send(_mapper.Map<DeleteOrderCommand>(deleteOrderCommandDto));
        return result is true ? Ok(true) : BadRequest(false);
    }

    [Route("Update-Order")]
    [HttpPut]
    [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(bool), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> UpdateOrder([FromBody] UpdateOrderCommandDto updateOrderCommandDto)
    {
        bool result = await _mediatr.Send(_mapper.Map<UpdateOrderCommand>(updateOrderCommandDto));
        return result is true ? Ok(true) : BadRequest(false);
    }

    [Route("Get-Order")]
    [HttpGet]
    [Produces("application/json")]
    [ProducesResponseType(typeof(Order), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(Order), (int)HttpStatusCode.NoContent)]
    [ProducesResponseType(typeof(Order), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> GetOrder([FromHeader(Name = "Id")] Guid Id)
    {
        Order? result = await _mediatr.Send(new GetOrderQuery(id: Id));
        if (result != null)
            return Ok(result);
        else if (result == null)
            return NoContent();
        else
            return BadRequest();
    }
}