using SB.Ball3DTournamentSys.Business.Interfaces;
using SB.Ball3DTournamentSys.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SB.Ball3DTournamentSys.Business.Concrete
{
    public class FixtureManager : IFixtureService
    {
        public List<TeamEntity> Teams { get; private set; }
        public int TournamentId { get; private set; }

        private List<TournamentBracketRoundEntity> rounds;

        private List<PlayedGamesEntity> gamesToBePlayed;

        private readonly ITournamentBracketRoundService _tournamentBracketRoundService;
        private readonly IPlayedGamesService _playedGamesService;

        public FixtureManager(List<TeamEntity> teams=null, int tournamentId=0, ITournamentBracketRoundService tournamentBracketRoundService=null, IPlayedGamesService playedGamesService=null)
        {
            Teams = teams;
            TournamentId = tournamentId;
            _tournamentBracketRoundService = tournamentBracketRoundService;
            _playedGamesService = playedGamesService;
            gamesToBePlayed = new List<PlayedGamesEntity>();
            rounds = new List<TournamentBracketRoundEntity>();
        }


        public void GenerateFixture()
        {
            try
            {
                for (int i = 0; i < Teams.Count / 2; i++)
                {
                    PlayedGamesEntity game = new PlayedGamesEntity { RoundMatchId = i, HomeTeamId = Teams[i].Id, AwayTeamId = Teams[Teams.Count - (i + 1)].Id, RoundNumber = 1 };
                    gamesToBePlayed.Add(game);
                }

                TournamentBracketRoundEntity round = new TournamentBracketRoundEntity { RoundNumber = 1, TournamentId = TournamentId };

                rounds.Add(round);
                GenerateNextRounds(Teams.Count / 2, 2, TournamentId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void GenerateNextRounds(int teamCount, int round, int tournamentId)
        {
            try
            {
                if (teamCount == 1)
                {
                    SaveEntitiesToDb();
                    return;
                }


                for (int i = 0; i < teamCount / 2; i++)
                {
                    PlayedGamesEntity game = new PlayedGamesEntity { RoundMatchId = i, RoundNumber = round };
                    gamesToBePlayed.Add(game);
                }

                TournamentBracketRoundEntity _round = new TournamentBracketRoundEntity { RoundNumber = round, TournamentId = tournamentId };

                rounds.Add(_round);
                GenerateNextRounds(teamCount / 2, round + 1, tournamentId);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void SaveEntitiesToDb()
        {
            foreach (var item in rounds)
            {
                _tournamentBracketRoundService.Add(item);
            }

            var roundId = _tournamentBracketRoundService.GetRoundIdByTournamentId(TournamentId);
            foreach (var item in gamesToBePlayed)
            {
                item.RoundId = roundId;
                _playedGamesService.Add(item);
            }
        }

        public PlayedGamesEntity FindTheNextTableForGame(PlayedGamesEntity playedGame)
        {

            // RoundMatchId 0 - 1 = Next match will be 0
            // RoundMatchId 2-3 = Next Match will be 1
            // RoundMatchId 4-5 = Next match will be 2
            
            //Algoritm: 
            //            if the RoundMatchId is 0 or 1 = next match rounId be 0
            //for others: if the RoundMatchId is even next match roundMatchId will be RoundMatchId/2
            //            if the RoundMatchId is odd next match roundMatchId will be Math.Floor(RoundMatchId/2)
            playedGame.RoundNumber++;

            if (playedGame.RoundMatchId == 0 || playedGame.RoundMatchId == 1)
                playedGame.RoundMatchId = 0;
            else if (playedGame.RoundMatchId % 2 == 0)
                playedGame.RoundMatchId /= 2;
            else
                playedGame.RoundMatchId = (int)Math.Floor((decimal)playedGame.RoundMatchId / 2);

            var playedGamesEntity = _playedGamesService.GetAllByRoundId(playedGame.RoundId);
            var newTable = playedGamesEntity.Where(I => I.RoundMatchId == playedGame.RoundMatchId && I.RoundNumber == playedGame.RoundNumber).FirstOrDefault();
            return newTable;
        }
    }
}
