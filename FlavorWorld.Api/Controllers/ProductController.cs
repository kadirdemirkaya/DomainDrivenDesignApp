using System.Net;
using AutoMapper;
using FlavorWorld.Application.Features.Commands.Products.CreateProduct;
using FlavorWorld.Application.Features.Commands.Products.UpdateProduct;
using FlavorWorld.Application.Features.Query.Products.CreateProduct;
using FlavorWorld.Application.Features.Query.Products.GetProduct;
using FlavorWorld.Contracts.Models.Products;
using FlavorWorld.Domain.Aggregates.ProductAggregate;
using FlavorWorld.Domain.Aggregates.ProductAggregate.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FlavorWorld.Api.Controllers;

[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IMediator _mediatr;
    private readonly IMapper _mapper;

    public ProductController(IMediator mediatr, IMapper mapper)
    {
        _mediatr = mediatr;
        _mapper = mapper;
    }

    [Route("Create-Product")]
    [HttpPost]
    [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(bool), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommandDto createProductCommandDto)
    {
        bool result = await _mediatr.Send(_mapper.Map<CreateProductCommand>(createProductCommandDto));
        return result is true ? Ok(true) : BadRequest(false);
    }

    [Route("Delete-Product")]
    [HttpDelete]
    [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(bool), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> DeleteProduct([FromHeader] DeleteProductCommandDto deleteProductCommandDto)
    {
        bool result = await _mediatr.Send(_mapper.Map<CreateProductCommand>(deleteProductCommandDto));
        return result is true ? Ok(true) : BadRequest(false);
    }

    [Route("Update-Product")]
    [HttpPut]
    [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(bool), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductCommandDto updateProductCommandDto)
    {
        bool result = await _mediatr.Send(_mapper.Map<UpdateProductCommand>(updateProductCommandDto));
        return result is true ? Ok(true) : BadRequest(false);
    }

    [HttpGet]
    [Route("Get-Product")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(Product), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(Product), (int)HttpStatusCode.NoContent)]
    public async Task<IActionResult> GetProduct([FromHeader(Name = "Id")] Guid Id)
    {
        Product? result = await _mediatr.Send(new GetProductQuery(id: Id));
        if (result != null)
            return Ok(result);
        else if (result == null)
            return NoContent();
        else
            return BadRequest();
    }


    [Route("Get-Product-With-Reviews")]
    [HttpGet]
    [Produces("application/json")]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<ProductReview>))]
    [ProducesResponseType((int)HttpStatusCode.NoContent, Type = typeof(void))]
    [ProducesResponseType((int)HttpStatusCode.NoContent, Type = typeof(void))]
    public async Task<IActionResult> GetProductWithReviews([FromHeader(Name = "Id")] Guid Id)
    {
        List<ProductReview>? result = await _mediatr.Send(new GetProductWithReviewsQuery(id: Id));
        if (result != null && result.Any())
            return Ok(result);
        else if (result == null && !result.Any())
            return NoContent();
        else
            return BadRequest();
    }
}