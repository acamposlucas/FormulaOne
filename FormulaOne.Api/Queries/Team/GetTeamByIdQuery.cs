using FormulaOne.DataService.Dtos.Responses;
using MediatR;

namespace FormulaOne.Api.Queries;

public class GetTeamByIdQuery : IRequest<GetTeamResponse>
{
    public Guid TeamId { get; }

    public GetTeamByIdQuery(Guid teamId)
    {
        TeamId = teamId;
    }
}
