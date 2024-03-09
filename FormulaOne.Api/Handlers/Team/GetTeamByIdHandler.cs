using AutoMapper;
using FormulaOne.Api.Queries;
using FormulaOne.DataService.Dtos.Responses;
using FormulaOne.DataService.Repositories.Interfaces;
using MediatR;

namespace FormulaOne.Api.Handlers;

public class GetTeamByIdHandler : IRequestHandler<GetTeamByIdQuery, GetTeamResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetTeamByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<GetTeamResponse> Handle(GetTeamByIdQuery request, CancellationToken cancellationToken)
    {
        var team = await _unitOfWork.Teams.GetById(request.TeamId);

        return _mapper.Map<GetTeamResponse>(team);
    }
}
