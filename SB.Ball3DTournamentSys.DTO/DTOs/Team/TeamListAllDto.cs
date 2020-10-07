using SB.Ball3DTournamentSys.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SB.Ball3DTournamentSys.DTO.DTOs.Team
{
    public class TeamListAllDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Tag { get; set; }
        public AppUser AppUser { get; set; }

        public List<PlayedGamesEntity> HomeTeams { get; set; }
        public List<PlayedGamesEntity> AwayTeams { get; set; }

        public List<TeamPlayersEntity> Players { get; set; }

        public List<TournamentTeamsEntity> TournamentTeams { get; set; }

        public string InviteCode { get; set; }
    }
}
