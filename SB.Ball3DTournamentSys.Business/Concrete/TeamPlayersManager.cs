using SB.Ball3DTournamentSys.Business.Interfaces;
using SB.Ball3DTournamentSys.DataAccess.Interfaces;
using SB.Ball3DTournamentSys.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SB.Ball3DTournamentSys.Business.Concrete
{
    public class TeamPlayersManager : GenericManager<TeamPlayersEntity>,ITeamPlayersService
    {
        private readonly ITeamPlayersDAL _teamPlayersService;
        public TeamPlayersManager(ITeamPlayersDAL teamPlayersService):base(teamPlayersService)
        {
            _teamPlayersService = teamPlayersService;
        }
    }
}
