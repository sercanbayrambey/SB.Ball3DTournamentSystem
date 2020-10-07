using SB.Ball3DTournamentSys.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SB.Ball3DTournamentSys.DataAccess.Interfaces
{
    public interface ITeamPlayersDAL : IGenericDAL<TeamPlayersEntity>
    {
        List<TeamEntity> GetUserTeamsById(int id);
        void AddPlayerToTeamByUserId(TeamEntity team, int userId);

    }
}
