using SB.Ball3DTournamentSys.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SB.Ball3DTournamentSys.DataAccess.Interfaces
{
    public interface IPlayedGamesDAL : IGenericDAL<PlayedGamesEntity>
    {
        public List<PlayedGamesEntity> GetPlayedGamesWithAllTablesByTournamentId(int tournamentId);

        /// <summary>
        /// Edits the scores, change match state to played and returns the winner team.
        /// </summary>
        /// <param name="playedGameToBeEdited"></param>
        /// <param name="homeTeamScore"></param>
        /// <param name="awayTeamScore"></param>
        /// <returns>Returns the winner team.</returns>
        TeamEntity UpdateScore(PlayedGamesEntity playedGameToBeEdited, int homeTeamScore, int awayTeamScore);

        PlayedGamesEntity GetByIdWithTeamTable(int id);
        List<PlayedGamesEntity> GetAllByRoundId(int roundId);

        List<PlayedGamesEntity> GetTournamentGamesByUserIdWithAll(int userId, int tournamentId);

        PlayedGamesEntity GetAllById(int id);

    }
}
