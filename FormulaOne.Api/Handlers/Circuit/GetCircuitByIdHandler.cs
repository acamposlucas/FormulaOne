using AutoMapper;
using FormulaOne.Api.Queries;
using FormulaOne.DataService.Dtos.Responses;
using FormulaOne.DataService.Repositories.Interfaces;
using MediatR;
namespace FormulaOne.Api.Handlers;

public class GetCircuitByIdHandler : IRequestHandler<GetCircuitByIdQuery, GetCircuitResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetCircuitByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<GetCircuitResponse> Handle(GetCircuitByIdQuery request, CancellationToken cancellationToken)
    {
        var circuit = await _unitOfWork.Circuits.GetById(request.CircuitId);

        return _mapper.Map<GetCircuitResponse>(circuit);
    }
}
