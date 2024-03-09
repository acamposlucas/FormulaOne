using FormulaOne.DataService.Dtos.Requests;
using FormulaOne.DataService.Dtos.Responses;
using MediatR;

namespace FormulaOne.Api.Commands;

public class CreateTeamInfoRequest : IRequest<GetTeamResponse>
{
    public CreateTeamRequest TeamRequest { get; }

    public CreateTeamInfoRequest(CreateTeamRequest team)
    {
        TeamRequest = team;
    }
}
