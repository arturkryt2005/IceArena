using AutoMapper;
using IceArena.Data.Models;
using IceArena.Web.Models;

namespace IceArena.Web.Mapping
{
    public class MatchProfile : Profile
    {
        public MatchProfile()
        {
            CreateMap<Match, MatchDto>()
                           .ForMember(dest => dest.Team1Name, opt => opt.MapFrom(src => src.Team1!.Name))
                           .ForMember(dest => dest.Team2Name, opt => opt.MapFrom(src => src.Team2!.Name));
        }
    }
}
