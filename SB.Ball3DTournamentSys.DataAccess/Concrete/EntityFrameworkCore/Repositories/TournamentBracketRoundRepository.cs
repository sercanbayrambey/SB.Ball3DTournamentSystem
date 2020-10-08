using SB.Ball3DTournamentSys.DataAccess.Concrete.Contexts;
using SB.Ball3DTournamentSys.DataAccess.Interfaces;
using SB.Ball3DTournamentSys.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SB.Ball3DTournamentSys.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class TournamentBracketRoundRepository : EfGenericRepository<TournamentBracketRoundEntity>, ITournamentBracketRoundDAL
    {
        public int GetRoundIdByTournamentId(int tournamentId)
        {
            using var context = new B3DTContext();
            return context.TournamentBracketRounds.Where(I => I.TournamentId == tournamentId).FirstOrDefault().Id;
        }
    }
}
