using FormulaOne.DataService;
using FormulaOne.DataService.Dtos.Responses;
using MediatR;

namespace FormulaOne.Api.Commands.Circuit;

public class CreateCircuitInfoRequest : IRequest<GetCircuitResponse>
{
    public CreateCircuitRequest CircuitRequest { get; }
    public CreateCircuitInfoRequest(CreateCircuitRequest circuit)
    {
        CircuitRequest = circuit;
    }
}
