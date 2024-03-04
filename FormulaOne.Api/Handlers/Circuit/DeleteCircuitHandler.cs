using FormulaOne.Api.Commands.Circuit;
using FormulaOne.DataService.Repositories.Interfaces;
using MediatR;

namespace FormulaOne.Api.Handlers;

public class DeleteCircuitHandler : IRequestHandler<DeleteCircuitInfoRequest, bool>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCircuitHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(DeleteCircuitInfoRequest request, CancellationToken cancellationToken)
    {
        var circuit = await _unitOfWork.Circuits.GetById(request.CircuitId);

        if (circuit is null)
        {
            return false;
        }

        await _unitOfWork.Circuits.Delete(request.CircuitId);
        return await _unitOfWork.CompleteAsync();
    }
}
