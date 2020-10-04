using AutoMapper;
using SB.Ball3DTournamentSys.DTO.DTOs.AppUser;
using SB.Ball3DTournamentSys.DTO.DTOs.GameServers;
using SB.Ball3DTournamentSys.DTO.DTOs.Tournament;
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

            CreateMap<AppUserLoginDTO, AppUser>();
            CreateMap<AppUser, AppUserLoginDTO>();

            CreateMap<TournamentEntity, CreateTournamentDto>();
            CreateMap<CreateTournamentDto, TournamentEntity>();

            CreateMap<TournamentListAllDto, TournamentEntity>();
            CreateMap<TournamentEntity, TournamentListAllDto>();


          
        }
    }
}
