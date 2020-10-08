using AutoMapper;
using SB.Ball3DTournamentSys.DTO.DTOs.AppUserDto;
using SB.Ball3DTournamentSys.DTO.DTOs.GameServers;
using SB.Ball3DTournamentSys.DTO.DTOs.PlayedGames;
using SB.Ball3DTournamentSys.DTO.DTOs.Team;
using SB.Ball3DTournamentSys.DTO.DTOs.Tournament;
using SB.Ball3DTournamentSys.Entities.Concrete;

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

            CreateMap<AppUser, AppUserRegisterDTO>();
            CreateMap<AppUserRegisterDTO, AppUser>();

            CreateMap<TeamEntity, TeamListDto>();
            CreateMap<TeamListDto, TeamEntity>();

            CreateMap<TeamEntity, CreateTeamDto>();
            CreateMap<CreateTeamDto, TeamEntity>();

            CreateMap<TournamentListDto, TournamentEntity>();
            CreateMap<TournamentEntity, TournamentListDto>();

            CreateMap<TeamListAllDto, TeamEntity>();
            CreateMap<TeamEntity, TeamListAllDto>();

            CreateMap<JoinTeamDto, TeamEntity>();
            CreateMap<TeamEntity, JoinTeamDto>();

            CreateMap<PlayedGamesListAllDto, PlayedGamesEntity>();
            CreateMap<PlayedGamesEntity, PlayedGamesListAllDto>();



        }
    }
}
