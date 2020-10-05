using SB.Ball3DTournamentSys.Business.Interfaces;
using SB.Ball3DTournamentSys.DataAccess.Interfaces;
using SB.Ball3DTournamentSys.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SB.Ball3DTournamentSys.Business.Concrete
{
    public class TeamManager : GenericManager<TeamEntity>, ITeamService
    {
        private readonly ITeamDAL _teamDAL;
        public TeamManager(ITeamDAL teamDAL) : base(teamDAL)
        {
            _teamDAL = teamDAL;
        }

        public List<TeamEntity> GetOwnedTeamsByUserId(int id)
        {
            return _teamDAL.GetOwnedTeamsByUserId(id);
        }
    }
}
