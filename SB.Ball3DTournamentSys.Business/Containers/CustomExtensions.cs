using Microsoft.Extensions.DependencyInjection;
using SB.Ball3DTournamentSys.Business.Concrete;
using SB.Ball3DTournamentSys.Business.Interfaces;
using SB.Ball3DTournamentSys.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using SB.Ball3DTournamentSys.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SB.Ball3DTournamentSys.Business.Containers
{
    public static class CustomExtensions
    {
        public static void AddScopes(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericDAL<>), typeof(EfGenericRepository<>));
            services.AddScoped(typeof(IGenericService<>), typeof(GenericManager<>));
            
            services.AddScoped<IGameServerService, GameServerManager>();
            services.AddScoped<IPlayedGamesService, PlayedGamesManager>();
            services.AddScoped<IStadiumService, StadiumManager>();
            services.AddScoped<ITeamService, TeamManager>();
            services.AddScoped<ITeamPlayersService, TeamPlayersManager>();
            services.AddScoped<ITournamentService, TournamentManager>();
            services.AddScoped<ITournamentTeamsService, TournamentTeamsManager>();
            services.AddScoped<IAppUserService, AppUserManager>();

            services.AddScoped<IGameServerDAL, GameServerRepository>();
            services.AddScoped<IPlayedGamesDAL, PlayedGamesRepository>();
            services.AddScoped<IStadiumDAL, StadiumRepository>();
            services.AddScoped<ITeamDAL, TeamRepository>();
            services.AddScoped<ITeamPlayersDAL, TeamPlayersRepository>();
            services.AddScoped<ITournamentDAL, TournamentRepository>();
            services.AddScoped<ITournamentTeamsDAL, TournamentTeamsRepository>();
            services.AddScoped<IGameServerDAL, GameServerRepository>();
            services.AddScoped<IAppUserDAL, AppUserRepository>();
        }
    }
}
