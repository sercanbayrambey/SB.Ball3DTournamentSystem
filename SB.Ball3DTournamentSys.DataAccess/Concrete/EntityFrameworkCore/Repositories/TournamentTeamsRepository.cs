using SB.Ball3DTournamentSys.DataAccess.Concrete.Contexts;
using SB.Ball3DTournamentSys.DataAccess.Interfaces;
using SB.Ball3DTournamentSys.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SB.Ball3DTournamentSys.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class TournamentTeamsRepository : EfGenericRepository<TournamentTeamsEntity>, ITournamentTeamsDAL
    {
        public int GetTotalTeamCountByTournamentId(int tournamentId)
        {
            using var context = new B3DTContext();
            return context.TournamentTeams.Where(I => I.TournamentId == tournamentId /*&& I.IsConfirmed*/).Count();
        }
    }
}
