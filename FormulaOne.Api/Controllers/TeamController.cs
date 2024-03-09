using AutoMapper;
using FormulaOne.Api.Commands;
using FormulaOne.Api.Queries;
using FormulaOne.DataService.Dtos.Requests;
using FormulaOne.DataService.Repositories.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FormulaOne.Api.Controllers;

public class TeamController : BaseController
{
    public TeamController(IUnitOfWork unitOfWork, IMapper mapper, IMediator mediator) : base(unitOfWork, mapper, mediator)
    {
    }

    [HttpGet]
    public async Task<IActionResult> GetTeamById(Guid teamId)
    {
        var query = new GetTeamByIdQuery(teamId);
        var result = await _mediator.Send(query);

        return result is null
            ? BadRequest()
            : Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateTeam([FromBody] CreateTeamRequest team)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        var command = new CreateTeamInfoRequest(team);
        var result = await _mediator.Send(command);

        return CreatedAtAction(nameof(GetTeamById), new { teamId = result.Id }, result);
    }
}
