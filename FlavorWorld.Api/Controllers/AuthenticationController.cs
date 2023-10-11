using System.Net;
using AutoMapper;
using FlavorWorld.Application.Features.Commands.Authentication.Register;
using FlavorWorld.Application.Features.Queries.Authentication.Login;
using FlavorWorld.Contracts.Dtos.Authentication;
using FlavorWorld.Contracts.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FlavorWorld.Api.Controllers;

[Route("api/[controller]")]
public class AuthenticationController : ControllerBase
{
    private readonly IMediator _mediatr;
    private readonly IMapper _mapper;

    public AuthenticationController(IMediator mediatr, IMapper mapper)
    {
        _mediatr = mediatr;
        _mapper = mapper;
    }

    [HttpPost]
    [Route("/User/Login")]
    [ProducesResponseType(typeof(AuthenticationResult), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(AuthenticationResult), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(AuthenticationResult), (int)HttpStatusCode.NoContent)]
    public async Task<IActionResult> Login([FromBody] LoginCommandDto loginRequestDto)
    {
        var response = await _mediatr.Send(_mapper.Map<LoginCommand>(loginRequestDto));
        if (response != null)
            return Ok(response);
        else if (response == null)
            return NoContent();
        else
            return BadRequest();
    }


    [HttpPost]
    [Route("/User/Register")]
    [ProducesResponseType(typeof(AuthenticationResult), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(AuthenticationResult), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(AuthenticationResult), (int)HttpStatusCode.NoContent)]
    public async Task<IActionResult> Register([FromBody] RegisterCommandDto registerCommandDto)
    {
        var response = await _mediatr.Send(_mapper.Map<RegisterCommand>(registerCommandDto));
        if (response != null)
            return Ok(response);
        else if (response == null)
            return NoContent();
        else
            return BadRequest();
    }
}