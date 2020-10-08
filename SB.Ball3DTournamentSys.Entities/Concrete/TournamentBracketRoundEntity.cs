using SB.Ball3DTournamentSys.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SB.Ball3DTournamentSys.Entities.Concrete
{
    public class TournamentBracketRoundEntity : ITable
    {
        public int Id { get; set; }
        public int RoundNumber { get; set; } = 1;  // it determines current round number of each tournament.
        public int TournamentId { get; set; }
        public TournamentEntity Tournament { get; set; }
        public List<PlayedGamesEntity> PlayedGames { get; set; }

    }
}
