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
        private readonly ITournamentBracketRoundService _tournamentBracketRoundService;
        private readonly IPlayedGamesService _playedGamesService;
        public TournamentManager(ITournamentDAL tournamentDAL, ITournamentBracketRoundService tournamentBracketRoundService, IPlayedGamesService playedGamesService) : base(tournamentDAL)
        {
            _playedGamesService = playedGamesService;
            _tournamentBracketRoundService = tournamentBracketRoundService;
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


        /// <summary>
        /// Starts the tournament with generate the fixture
        /// </summary>
        /// <param name="id"></param>
        /// <param name="teams"></param>
        public void StartById(int id, List<TeamEntity> teams)
        {
            FixtureManager fixtureManager = new FixtureManager(teams, id, _tournamentBracketRoundService, _playedGamesService);
            fixtureManager.GenerateFixture();
            _tournamentDAL.StartById(id);
        }

    }
}
