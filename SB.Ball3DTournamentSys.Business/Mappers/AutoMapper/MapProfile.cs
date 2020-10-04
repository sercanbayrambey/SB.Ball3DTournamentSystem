using AutoMapper;
using SB.Ball3DTournamentSys.DTO.DTOs.GameServers;
using SB.Ball3DTournamentSys.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SB.Ball3DTournamentSys.Business.Mappers.AutoMapper
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<GameServerListDTO, GameServerEntity>();
            CreateMap<GameServerEntity, GameServerListDTO>();
        }
    }
}
