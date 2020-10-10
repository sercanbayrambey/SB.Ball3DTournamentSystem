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
    public class TournamentRepository : EfGenericRepository<TournamentEntity>, ITournamentDAL
    {
        public List<TournamentEntity> GetAllWithAllTables()
        {
            using var DBContext = new B3DTContext();
            return DBContext.Tournaments.Include(I => I.Stadium).Include(I => I.GameServer).ToList();
        }

        public List<TournamentEntity> GetFinishedTournamentsWithAllTables()
        {
            using var DBContext = new B3DTContext();
            return DBContext.Tournaments.Where(I=>I.IsFinished).Include(I => I.Stadium).Include(I => I.GameServer).Include(I=>I.TournamentTeams).ThenInclude(I=>I.Team).ToList();
        }

        public List<TournamentEntity> GetStartedTournamentsWithAllTables()
        {
            using var DBContext = new B3DTContext();
            return DBContext.Tournaments.Where(I => I.IsStarted && !I.IsFinished).Include(I => I.Stadium).Include(I => I.GameServer).Include(I => I.TournamentTeams).ToList();
        }


        public TournamentEntity GetTournamentWithAllTablesById(int id)
        {
            using var DBContext = new B3DTContext();
            return DBContext.Tournaments.Where(I => I.Id == id).Include(I => I.Stadium).Include(I => I.GameServer).Include(I => I.TournamentTeams).ThenInclude(I => I.Team).FirstOrDefault();
        }

        public List<TournamentEntity> GetUpcomingTournamentsWithAllTables()
        {
            using var DBContext = new B3DTContext();
            return DBContext.Tournaments.Where(I => !I.IsFinished && !I.IsStarted).Include(I => I.Stadium).Include(I => I.GameServer).Include(I => I.TournamentTeams).ToList();
        }
    }
}
