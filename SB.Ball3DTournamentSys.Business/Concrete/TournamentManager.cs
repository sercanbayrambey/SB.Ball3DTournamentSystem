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

        public void StartTournament(List<TeamEntity> teams, int tournamentId)
        {
            FixtureManager fixtureManager = new FixtureManager(teams, tournamentId, _tournamentBracketRoundService, _playedGamesService);
            fixtureManager.GenerateFixture();
            //Todo: Start Tournament
        }

        //TODO: Refactor here
/*        private void GenerateFixture(List<TeamEntity> teams,int tournamentId)
        {

            List<PlayedGamesEntity> gamesToBePlayed = new List<PlayedGamesEntity>();


            for (int i = 0; i < teams.Count / 2; i++)
            {
                PlayedGamesEntity game = new PlayedGamesEntity { RoundMatchId = i,HomeTeamId=teams[i].Id, AwayTeamId= teams[teams.Count - (i + 1)].Id, RoundNumber=1 };
                gamesToBePlayed.Add(game);
            }
            TournamentBracketRoundEntity round = new TournamentBracketRoundEntity { RoundNumber = 1,TournamentId = tournamentId  };

            List<TournamentBracketRoundEntity> Rounds = new List<TournamentBracketRoundEntity>();
            Rounds.Add(round);
            GenerateNextRounds(teams.Count / 2, 2,Rounds, tournamentId,gamesToBePlayed);
        }

        private void GenerateNextRounds(int teamCount, int round, List<TournamentBracketRoundEntity> Rounds, int tournamentId, List<PlayedGamesEntity> gamesToBePlayed)
        {
            if (teamCount == 1)
            {
                SaveEntitiesToDb(Rounds, gamesToBePlayed, tournamentId);
                return;
            }


            for (int i = 0; i < teamCount / 2; i++)
            {
                PlayedGamesEntity game = new PlayedGamesEntity { RoundMatchId = i,RoundNumber=round};
                gamesToBePlayed.Add(game);
            }

            TournamentBracketRoundEntity _round = new TournamentBracketRoundEntity { RoundNumber = round,TournamentId = tournamentId };

            Rounds.Add(_round);
            GenerateNextRounds(teamCount / 2, round + 1,Rounds,tournamentId,gamesToBePlayed);

        }

        private void SaveEntitiesToDb(List<TournamentBracketRoundEntity> rounds, List<PlayedGamesEntity> gamesToBePlayed, int tournamentId)
        {
            foreach (var item in rounds)
            {
                _tournamentBracketRoundService.Add(item);
            }

            var roundId = _tournamentBracketRoundService.GetRoundIdByTournamentId(tournamentId);
            foreach (var item in gamesToBePlayed)
            {
                item.RoundId = roundId;
                _playedGamesService.Add(item);
            }
        }*/

    }
}
