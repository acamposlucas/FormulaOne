using AutoMapper;
using FormulaOne.DataService;
using FormulaOne.DataService.Dtos.Responses;
using FormulaOne.Entities.DbSet;

namespace FormulaOne.Api;

public class CircuitProfile : Profile
{
    public CircuitProfile()
    {
        #region Requests
        CreateMap<CreateCircuitRequest, Circuit>();

        #endregion

        #region Responses
        CreateMap<Circuit, GetCircuitResponse>();
        #endregion
    }
}
