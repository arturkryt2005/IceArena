using AutoMapper;
using IceArena.Data.Models;
using IceArena.Web.Models;

namespace IceArena.Web.Mapping
{
    public class MatchProfile : Profile
    {
        public MatchProfile()
        {
            CreateMap<Match, MatchDto>();  
        }
    }
}
