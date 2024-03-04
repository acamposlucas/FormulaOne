using AutoMapper;
using FormulaOne.DataService;
using FormulaOne.Entities.DbSet;

namespace FormulaOne.Api;

public class CircuitProfile : Profile
{
    public CircuitProfile()
    {
        #region Requests
        CreateMap<CreateCircuitRequest, Circuit>();
        CreateMap<UpdateCircuitRequest, Circuit>()
            .ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src => src.CircuitId)
            );

        #endregion

        #region Responses
        CreateMap<Circuit, GetCircuitResponse>();
        #endregion
    }
}
