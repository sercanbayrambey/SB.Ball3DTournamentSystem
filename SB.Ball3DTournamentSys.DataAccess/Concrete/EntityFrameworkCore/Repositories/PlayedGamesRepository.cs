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
    public class PlayedGamesRepository : EfGenericRepository<PlayedGamesEntity>, IPlayedGamesDAL
    {
        public PlayedGamesEntity GetAllById(int id)
        {
            using var context = new B3DTContext();
            return context.PlayedGames.Include(I => I.AwayTeam).Include(I => I.HomeTeam).Include(I => I.PlayedGamesRound).ThenInclude(I => I.Tournament).Where(I => I.Id ==id).FirstOrDefault();
        }

        public List<PlayedGamesEntity> GetAllByRoundId(int roundId) // Todo: its not returning all
        {
            using var context = new B3DTContext();
            return context.PlayedGames.Where(I => I.RoundId == roundId).ToList();
        }

        public PlayedGamesEntity GetByIdWithTeamTable(int id)
        {
            using var context = new B3DTContext();
            return context.PlayedGames.Include(I => I.AwayTeam).Include(I => I.HomeTeam).Where(I => I.Id == id).FirstOrDefault();
        }

        public List<PlayedGamesEntity> GetPlayedGamesWithAllTablesByTournamentId(int tournamentId)
        {
            using var context = new B3DTContext();
            return context.PlayedGames.Include(I => I.AwayTeam).Include(I => I.HomeTeam).Include(I => I.PlayedGamesRound).ThenInclude(I => I.Tournament).Where(I=>I.PlayedGamesRound.TournamentId==tournamentId).ToList();
        }

        public List<PlayedGamesEntity> GetTournamentGamesByUserIdWithAll(int userId, int tournamentId)
        {
            using var context = new B3DTContext();
            var gameList = context.PlayedGames.Include(I => I.AwayTeam).ThenInclude(I=>I.Players).Include(I => I.HomeTeam).Include(I => I.PlayedGamesRound).ThenInclude(I => I.Tournament).Where(I => I.PlayedGamesRound.TournamentId == tournamentId && ((I.HomeTeam != null && I.HomeTeam.AppUserId == userId) || (I.AwayTeam != null && I.AwayTeam.AppUserId==userId))).ToList();
          

            return gameList;
        }

        public TeamEntity UpdateScore(PlayedGamesEntity playedGameToBeEdited, int homeTeamScore, int awayTeamScore)
        {
            var entity = GetByIdWithTeamTable(playedGameToBeEdited.Id);
            entity.HomeTeamScore = homeTeamScore;
            entity.AwayTeamScore = awayTeamScore;
            entity.IsFinished = true;
            Update(entity);

            return homeTeamScore > awayTeamScore ? entity.HomeTeam : entity.AwayTeam;
        }

    }
}
