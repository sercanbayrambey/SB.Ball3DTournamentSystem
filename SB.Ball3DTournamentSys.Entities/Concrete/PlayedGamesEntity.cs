using SB.Ball3DTournamentSys.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SB.Ball3DTournamentSys.Entities.Concrete
{
    public class PlayedGamesEntity : ITable
    {
        public int Id { get; set; }
        public int RoundMatchId { get; set; }
        public int RoundNumber { get; set; }

        public int RoundId { get; set; }
        public TournamentBracketRoundEntity PlayedGamesRound { get; set; }

        public int? HomeTeamScore { get; set; }
        public int? AwayTeamScore { get; set; }

        public int? HomeTeamId { get; set; }
        public TeamEntity HomeTeam { get; set; }

        public int? AwayTeamId { get; set; }
        public TeamEntity AwayTeam { get; set; }

        public bool IsFinished { get; set; } = false;

        /*       public int TournamentId { get; set; }
               public TournamentEntity Tournament { get; set; }
       */

    }
}
