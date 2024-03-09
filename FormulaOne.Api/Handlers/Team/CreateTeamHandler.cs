using AutoMapper;
using FormulaOne.Api.Commands;
using FormulaOne.DataService.Dtos.Responses;
using FormulaOne.DataService.Repositories.Interfaces;
using FormulaOne.Entities.DbSet;
using MediatR;

namespace FormulaOne.Api.Handlers;

public class CreateTeamHandler : IRequestHandler<CreateTeamInfoRequest, GetTeamResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateTeamHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<GetTeamResponse> Handle(CreateTeamInfoRequest request, CancellationToken cancellationToken)
    {
        var result = _mapper.Map<Team>(request.TeamRequest);

        await _unitOfWork.Teams.Add(result);
        await _unitOfWork.CompleteAsync();

        return _mapper.Map<GetTeamResponse>(result);
    }
}
