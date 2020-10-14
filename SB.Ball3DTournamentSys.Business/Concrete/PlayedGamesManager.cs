using SB.Ball3DTournamentSys.Business.Interfaces;
using SB.Ball3DTournamentSys.DataAccess.Interfaces;
using SB.Ball3DTournamentSys.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SB.Ball3DTournamentSys.Business.Concrete
{
    public class PlayedGamesManager : GenericManager<PlayedGamesEntity>,IPlayedGamesService

    {
        private readonly IPlayedGamesDAL _playedGamesDAL;
        public PlayedGamesManager(IPlayedGamesDAL playedGamesDAL) : base(playedGamesDAL)
        {
            _playedGamesDAL = playedGamesDAL;
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
            return _playedGamesDAL.UpdateScore(playedGameToBeEdited, homeTeamScore, awayTeamScore);
        }
    }
}
