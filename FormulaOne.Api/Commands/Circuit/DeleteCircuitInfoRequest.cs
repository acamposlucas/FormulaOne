using MediatR;

namespace FormulaOne.Api.Commands.Circuit;

public class DeleteCircuitInfoRequest : IRequest<bool>
{
    public Guid CircuitId { get; }

    public DeleteCircuitInfoRequest(Guid circuitId)
    {
        CircuitId = circuitId;
    }
}
