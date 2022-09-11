using AutoMapper;
using RugbyUnion1.Models;
using RugbyUnion1.DataTransferObjects;

namespace RugbyUnion1
{//it's a service added at program
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {//bi-direction map
            CreateMap<Player, PlayerDto>().ReverseMap();
            CreateMap<Team, TeamDto>().ReverseMap();
        }
    }
}
