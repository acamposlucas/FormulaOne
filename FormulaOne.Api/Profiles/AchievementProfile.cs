using AutoMapper;
using FormulaOne.DataService.Dtos.Requests;
using FormulaOne.DataService.Dtos.Responses;
using FormulaOne.Entities.DbSet;

namespace FormulaOne.Api.Profiles;

public class AchievementProfile : Profile
{
    public AchievementProfile()
    {
        #region Requests
        CreateMap<CreateDriverAchievementRequest, Achievement>()
            .ForMember(
                dest => dest.RaceWins,
                opt => opt.MapFrom(src => src.Wins)
            )
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

        CreateMap<UpdateDriverAchievementRequest, Achievement>()
            .ForMember(
                dest => dest.RaceWins,
                opt => opt.MapFrom(src => src.Wins)
            )
            .ForMember(
                dest => dest.UpdatedAt,
                opt => opt.MapFrom(src => DateTime.UtcNow)
            );
        #endregion

        #region Responses
        CreateMap<Achievement, DriverAchievementResponse>()
            .ForMember(
                dest => dest.Wins,
                opt => opt.MapFrom(src => src.RaceWins)
            );
        #endregion
    }
}
