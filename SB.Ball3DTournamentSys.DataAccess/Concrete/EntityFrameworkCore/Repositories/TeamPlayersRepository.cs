using Microsoft.EntityFrameworkCore;
using SB.Ball3DTournamentSys.DataAccess.Concrete.Contexts;
using SB.Ball3DTournamentSys.DataAccess.Interfaces;
using SB.Ball3DTournamentSys.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SB.Ball3DTournamentSys.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class TeamPlayersRepository : EfGenericRepository<TeamPlayersEntity>, ITeamPlayersDAL
    {
        public List<TeamEntity> GetUserTeamsById(int id)
        {
            using var context = new B3DTContext();
            var result = context.TeamPlayers.Include(I => I.Team).Where(I => I.AppUserId == id).Select(I=>I.Team).ToList();
            return result;
        }
    }
}
