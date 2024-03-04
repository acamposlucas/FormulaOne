using AutoMapper;
using FormulaOne.Api.Commands.Circuit;
using FormulaOne.DataService;
using FormulaOne.DataService.Repositories.Interfaces;
using FormulaOne.Entities.DbSet;
using MediatR;

namespace FormulaOne.Api.Handlers;

public class CreateCircuitHandler : IRequestHandler<CreateCircuitInfoRequest, GetCircuitResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateCircuitHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<GetCircuitResponse> Handle(CreateCircuitInfoRequest request, CancellationToken cancellationToken)
    {
        var result = _mapper.Map<Circuit>(request.CircuitRequest);

        await _unitOfWork.Circuits.Add(result);
        await _unitOfWork.CompleteAsync();

        return _mapper.Map<GetCircuitResponse>(result);
    }
}
