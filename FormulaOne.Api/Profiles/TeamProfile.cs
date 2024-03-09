using AutoMapper;
using FormulaOne.DataService.Dtos.Requests;
using FormulaOne.DataService.Dtos.Responses;
using FormulaOne.Entities.DbSet;

namespace FormulaOne.Api.Profiles;

public class TeamProfile : Profile
{
    public TeamProfile()
    {
        #region Requests
        CreateMap<CreateTeamRequest, Team>();
        #endregion

        #region Responses
        CreateMap<Team, GetTeamResponse>();
        #endregion
    }
}
