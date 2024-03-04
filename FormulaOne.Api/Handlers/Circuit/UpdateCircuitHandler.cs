using AutoMapper;
using FormulaOne.Api.Commands.Circuit;
using FormulaOne.DataService.Repositories.Interfaces;
using FormulaOne.Entities.DbSet;
using MediatR;

namespace FormulaOne.Api.Handlers;

public class UpdateCircuitHandler : IRequestHandler<UpdateCircuitInfoRequest, bool>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateCircuitHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<bool> Handle(UpdateCircuitInfoRequest request, CancellationToken cancellationToken)
    {
        var result = _mapper.Map<Circuit>(request.CircuitRequest);

        await _unitOfWork.Circuits.Update(result);

        return await _unitOfWork.CompleteAsync();
    }
}
