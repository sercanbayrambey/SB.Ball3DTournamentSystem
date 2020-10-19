using SB.Ball3DTournamentSys.Business.Interfaces;
using SB.Ball3DTournamentSys.DataAccess.Interfaces;
using SB.Ball3DTournamentSys.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SB.Ball3DTournamentSys.Business.Concrete
{
    public class PlayedGamesManager : GenericManager<PlayedGamesEntity>, IPlayedGamesService

    {
        private readonly IPlayedGamesDAL _playedGamesDAL;
        public PlayedGamesManager(IPlayedGamesDAL playedGamesDAL) : base(playedGamesDAL)
        {
            _playedGamesDAL = playedGamesDAL;
        }

        public void AddWinnerToNextGame(PlayedGamesEntity playedGame, TeamEntity winnerTeam)
        {
            FixtureManager fm = new FixtureManager(this);
            var roundMatchId = playedGame.RoundMatchId;
            var nextTable = fm.FindTheNextTableForGame(playedGame);
            if (nextTable != null)
            {
                if(roundMatchId % 2 == 0)
                    nextTable.HomeTeamId = winnerTeam.Id;
                else
                    nextTable.AwayTeamId = winnerTeam.Id;

                this.Update(nextTable);
            }

        }

        public PlayedGamesEntity GetAllById(int id)
        {
            return _playedGamesDAL.GetAllById(id);
        }

        public List<PlayedGamesEntity> GetAllByRoundId(int roundId)
        {
            return _playedGamesDAL.GetAllByRoundId(roundId);
        }

        public PlayedGamesEntity GetByIdWithTeamTable(int id)
        {
            return _playedGamesDAL.GetByIdWithTeamTable(id);
        }

        public List<PlayedGamesEntity> GetPlayedGamesWithAllTablesByTournamentId(int tournamentId)
        {
            return _playedGamesDAL.GetPlayedGamesWithAllTablesByTournamentId(tournamentId);
        }

        public List<PlayedGamesEntity> GetTournamentGamesByUserIdWithAll(int userId, int tournamentId)
        {
            return _playedGamesDAL.GetTournamentGamesByUserIdWithAll(userId, tournamentId);
        }

        public TeamEntity UpdateScore(PlayedGamesEntity playedGameToBeEdited, int homeTeamScore, int awayTeamScore)
        {
            playedGameToBeEdited.IsHomeTeamConfirmedResult = true; // Because sender is admin
            playedGameToBeEdited.IsAwayTeamConfirmedResult = true;
            playedGameToBeEdited.IsFinished = true;
            return _playedGamesDAL.UpdateScore(playedGameToBeEdited, homeTeamScore, awayTeamScore);
        }

        public TeamEntity UpdateScore(PlayedGamesEntity playedGameToBeEdited, int homeTeamScore, int awayTeamScore, int senderUserId)
        {
            var playedGame = GetAllById(playedGameToBeEdited.Id);
            playedGame.IsFinished = false;
            if (senderUserId == playedGame.HomeTeam.AppUserId)
                playedGameToBeEdited.IsHomeTeamConfirmedResult = true;
            else if (senderUserId == playedGame.AwayTeam.AppUserId)
                playedGameToBeEdited.IsAwayTeamConfirmedResult = true;
            else
                throw new Exception("You are not owner of these teams.");

            if (playedGameToBeEdited.IsAwayTeamConfirmedResult && playedGameToBeEdited.IsHomeTeamConfirmedResult)
                playedGameToBeEdited.IsFinished = true;

            return _playedGamesDAL.UpdateScore(playedGameToBeEdited, homeTeamScore, awayTeamScore);
        }

    }
}
