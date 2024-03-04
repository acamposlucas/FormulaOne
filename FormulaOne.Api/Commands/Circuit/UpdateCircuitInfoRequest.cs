using FormulaOne.DataService;
using MediatR;

namespace FormulaOne.Api.Commands.Circuit;

public class UpdateCircuitInfoRequest : IRequest<bool>
{
    public UpdateCircuitRequest CircuitRequest { get; }

    public UpdateCircuitInfoRequest(UpdateCircuitRequest circuitRequest)
    {
        CircuitRequest = circuitRequest;
    }
}
