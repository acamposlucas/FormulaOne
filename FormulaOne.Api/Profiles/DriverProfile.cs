using AutoMapper;
using FormulaOne.DataService.Dtos.Requests;
using FormulaOne.DataService.Dtos.Responses;
using FormulaOne.Entities.DbSet;

namespace FormulaOne.Api.Profiles;

public class DriverProfile : Profile
{
    public DriverProfile()
    {
        #region Requests
        CreateMap<CreateDriverRequest, Driver>()
            .ForMember(
                dest => dest.Status,
                opt => opt.MapFrom(src => 1)
            )
            .ForMember(
                dest => dest.CreatedAt,
                opt => opt.MapFrom(src => DateTime.UtcNow)
            )
            .ForMember(
                dest => dest.UpdatedAt,
                opt => opt.MapFrom(src => DateTime.UtcNow)
            );

        CreateMap<UpdateDriverRequest, Driver>()
            .ForMember(
                dest => dest.UpdatedAt,
                opt => opt.MapFrom(src => DateTime.UtcNow)
            );
        #endregion

        #region Responses
        CreateMap<Driver, GetDriverResponse>()
            .ForMember(
                dest => dest.DriverId,
                opt => opt.MapFrom(src => src.Id)
            )
            .ForMember(
                dest => dest.FullName,
                opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}")
            );

        #endregion
    }
}
