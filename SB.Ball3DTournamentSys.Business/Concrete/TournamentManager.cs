using SB.Ball3DTournamentSys.Business.Interfaces;
using SB.Ball3DTournamentSys.DataAccess.Interfaces;
using SB.Ball3DTournamentSys.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SB.Ball3DTournamentSys.Business.Concrete
{
    public class TournamentManager : GenericManager<TournamentEntity>, ITournamentService
    {
        private readonly ITournamentDAL _tournamentDAL;
        public TournamentManager(ITournamentDAL tournamentDAL): base(tournamentDAL)
        {
            _tournamentDAL = tournamentDAL;
        }

        public List<TournamentEntity> GetAllWithAllTables()
        {
            return _tournamentDAL.GetAllWithAllTables();
        }

        public List<TournamentEntity> GetFinishedTournamentsWithAllTables()
        {
            return _tournamentDAL.GetFinishedTournamentsWithAllTables();
        }

        public List<TournamentEntity> GetStartedTournamentsWithAllTables()
        {
            return _tournamentDAL.GetStartedTournamentsWithAllTables();
        }

        public TournamentEntity GetTournamentWithAllTablesById(int id)
        {
            return _tournamentDAL.GetTournamentWithAllTablesById(id);
        }

        public List<TournamentEntity> GetUpcomingTournamentsWithAllTables()
        {
            return _tournamentDAL.GetUpcomingTournamentsWithAllTables();
        }
    }
}
