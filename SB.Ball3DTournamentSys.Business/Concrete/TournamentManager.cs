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

        public void StartTournament(List<TeamEntity> teams)
        {
            throw new NotImplementedException();
        }

        private void GenerateFixture(List<TeamEntity> teams,int tournamentId)
        {

            List<PlayedGamesEntity> matches = new List<PlayedGamesEntity>();

            for (int i = 0; i < teams.Count / 2; i++)
            {
                PlayedGamesEntity match = new PlayedGamesEntity { RoundMatchId = i, HomeTeam = teams[i], AwayTeam = teams[teams.Count - (i + 1)] };
                matches.Add(match);
            }
            TournamentBracketRoundEntity round = new TournamentBracketRoundEntity { RoundNumber = 1, PlayedGames = matches,TournamentId = tournamentId  };
            Rounds.Add(round);
            GenerateNextRounds(teams.Count / 2, 2);
        }

        private void GenerateNextRounds(int teamCount, int round)
        {
            if (teamCount == 1)
                return;

            List<Match> matches = new List<Match>();

            for (int i = 0; i < teamCount / 2; i++)
            {
                Match match = new Match { Id = i, HomeTeam = null, AwayTeam = null };
                matches.Add(match);
            }

            Round _round = new Round { Id = round, Matches = matches };
            Rounds.Add(_round);
            GenerateNextRounds(teamCount / 2, round + 1);

        }
    }
}
