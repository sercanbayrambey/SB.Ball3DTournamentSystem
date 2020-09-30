using SB.Ball3DTournamentSys.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SB.Ball3DTournamentSys.Entities.Concrete
{
    public class TeamEntity : ITable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Tag { get; set; }

        /*public int OwnerId { get; set; }
        public AppUser User { get; set; }*/

        public List<PlayedGamesEntity> HomeTeams { get; set; }
        public List<PlayedGamesEntity> AwayTeams { get; set; }

        public List<TeamPlayersEntity> Players { get; set; }

        public List<TournamentTeamsEntity> TournamentTeams { get; set; }

    }
}
 