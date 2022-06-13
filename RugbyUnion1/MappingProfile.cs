using AutoMapper;
using RugbyClub1.Models;
using RugbyUnion1.DataTransferObjects;

namespace RugbyUnion1
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {//bi-direction map
            CreateMap<Player, PlayerDto>().ReverseMap();
            CreateMap<Team, TeamDto>().ReverseMap();
        }
    }
}
