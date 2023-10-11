using System.Net;
using AutoMapper;
using FlavorWorld.Application.Features.Commands.Products.CreateCustomer;
using FlavorWorld.Application.Features.Commands.Products.DeleteCustomer;
using FlavorWorld.Application.Features.Commands.Products.UpdateCustomer;
using FlavorWorld.Contracts.Models.Customers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FlavorWorld.Api.Controllers;

[Route("api/[controller]")]
public class CustomerController : ControllerBase
{
    private readonly IMediator _mediatr;
    private readonly IMapper _mapper;
    private readonly ILogger<CustomerController> _logger;

    public CustomerController(IMediator mediatr, IMapper mapper, ILogger<CustomerController> logger)
    {
        _mediatr = mediatr;
        _mapper = mapper;
        _logger = logger;
    }

    [Route("Create-Customer")]
    [HttpPost]
    [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(bool), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerCommandDto createCustomerCommandDto)
    {
        bool result = await _mediatr.Send(_mapper.Map<CreateCustomerCommand>(createCustomerCommandDto));
        return result is true ? Ok(true) : BadRequest(false);
    }

    [Route("Delete-Customer")]
    [HttpDelete]
    [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(bool), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> DeleteCustomer([FromHeader(Name = "Id")] Guid Id)
    {
        DeleteCustomerCommand deleteCustomerCommand = new(Id);
        bool result = await _mediatr.Send(deleteCustomerCommand);
        return result is true ? Ok(true) : BadRequest(false);
    }

    [Route("Update-Customer")]
    [HttpPut]
    [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(bool), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> UpdateCustomer([FromBody] UpdateCustomerCommandDto updateCustomerCommandDto)
    {
        bool result = await _mediatr.Send(_mapper.Map<UpdateCustomerCommand>(updateCustomerCommandDto));
        return result is true ? Ok(true) : BadRequest(false);
    }
}