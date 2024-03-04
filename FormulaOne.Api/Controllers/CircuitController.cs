using AutoMapper;
using FormulaOne.Api.Commands.Circuit;
using FormulaOne.Api.Controllers;
using FormulaOne.Api.Queries;
using FormulaOne.DataService;
using FormulaOne.DataService.Repositories.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FormulaOne.Api;

public class CircuitController : BaseController
{
    public CircuitController(IUnitOfWork unitOfWork, IMapper mapper, IMediator mediator) : base(unitOfWork, mapper, mediator)
    {
    }

    [HttpGet]
    [Route("{circuitId:guid}")]
    public async Task<IActionResult> GetCircuitById(Guid circuitId)
    {
        var query = new GetCircuitByIdQuery(circuitId);
        var result = await _mediator.Send(query);

        return result is null
            ? NotFound()
            : Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCircuit([FromBody] CreateCircuitRequest circuit)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        var command = new CreateCircuitInfoRequest(circuit);
        var result = await _mediator.Send(command);

        return CreatedAtAction(nameof(GetCircuitById), new { circuitId = result.Id }, result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCircuit([FromBody] UpdateCircuitRequest circuit)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        var command = new UpdateCircuitInfoRequest(circuit);
        var result = await _mediator.Send(command);

        return result
            ? NoContent()
            : BadRequest();
    }
}
