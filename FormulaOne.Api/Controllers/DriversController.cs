using AutoMapper;
using FormulaOne.Api.Commands;
using FormulaOne.Api.Queries;
using FormulaOne.DataService.Dtos.Requests;
using FormulaOne.DataService.Dtos.Responses;
using FormulaOne.DataService.Repositories.Interfaces;
using FormulaOne.Entities.DbSet;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FormulaOne.Api.Controllers;

public class DriversController : BaseController
{
    
    public DriversController(IUnitOfWork unitOfWork, IMapper mapper, IMediator mediator) : base(unitOfWork, mapper, mediator) { }

    [HttpGet]
    [Route("{driverId:guid}")]
    public async Task<IActionResult> GetDriverById(Guid driverId)
    {
        var query = new GetDriverByIdQuery(driverId);

        var result = await _mediator.Send(query);

        return result is null 
            ? NotFound() 
            : Ok(result);
    }


    [HttpGet]
    public async Task<IActionResult> GetAllDrivers()
    {
        var query = new GetAllDriversQuery();
        var result = await _mediator.Send(query);

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateDriver([FromBody] CreateDriverRequest driver)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        var command = new CreateDriverInfoRequest(driver);
        var result = await _mediator.Send(command);

        return CreatedAtAction(nameof(GetDriverById), new { driverId = result.DriverId }, result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateDriver([FromBody] UpdateDriverRequest driver)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        var command = new UpdateDriverInfoRequest(driver);
        var result = await _mediator.Send(command);

        return result
            ? NoContent()
            : BadRequest();
    }

    [HttpDelete]
    [Route("{driverId:guid}")]
    public async Task<IActionResult> DeleteDriver(Guid driverId)
    {
        var command = new DeleteDriverInfoRequest(driverId);

        var result = await _mediator.Send(command);

        return result 
            ? NoContent() 
            : BadRequest();
    }
}
