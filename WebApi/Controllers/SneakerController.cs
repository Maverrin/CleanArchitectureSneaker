using Application.DTOs;
using Application.Sneakers.Commands.CreateSneaker;
using Application.Sneakers.Commands.DeleteSneaker;
using Application.Sneakers.Commands.UpdateSneaker;
using Application.Sneakers.Queries;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Endpoints;

[Route("[controller]")]
[ApiController]
public class SneakerController : ControllerBase
{
    private readonly IMediator _mediator;

    public SneakerController(IMediator mediator)
    {
        _mediator = mediator;
    }

    
    [HttpGet]
    public async Task<List<SneakerDTO>> SneakerCollection()
    {
        return await _mediator.Send(new GetSneakerCollectionQuery());
    }

    [HttpGet("{id:guid}")]
    public async Task<SneakerDTO> Get(Guid id)
    {
        return await _mediator.Send(new GetSneakerByIdQuery(id));
    }

    [HttpGet("GetAllFilter")]
    public async Task<List<SneakerDTO>> GetAllPredicate([FromQuery(Name = "whereBody")] string whereBody = "", [FromQuery(Name = "orderBody")] string orderBody = "")
    {
        Func<Sneaker, bool> where = 
            s => { if (whereBody == string.Empty) { return true; }
                return s.Brand.ToLower().Contains(whereBody) ||
        s.Name.ToLower().Contains(whereBody) ||
        s.Price.ToString().Equals(whereBody);
            };

        Func<Sneaker, object> order = s => s.Year;

        return await _mediator.Send(new GetSneakerByPredicateQuery(where, order));
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> CreateSneaker(CreateSneakerCommand command)
    {
        if(!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await _mediator.Send(command);
        return Ok();
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteSneaker(Guid id)
    {
        await _mediator.Send(new DeleteSneakerCommand(id));
        return NoContent();
    }

    [Authorize(Roles = "Admin")]
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateSneaker(Guid id, UpdateSneakerCommand command)
    {
        if (id != command.Id) return BadRequest();

        await _mediator.Send(command);
        return NoContent();
    }
}

