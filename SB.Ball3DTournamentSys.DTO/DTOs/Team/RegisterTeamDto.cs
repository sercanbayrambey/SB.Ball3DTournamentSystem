using SB.Ball3DTournamentSys.DTO.DTOs.Tournament;
using System;
using System.Collections.Generic;
using System.Text;

namespace SB.Ball3DTournamentSys.DTO.DTOs.Team
{
    public class RegisterTeamDto
    {
        public List<TeamListDto> OwnedTeams { get; set; }
        public TournamentListAllDto Tournament{ get; set; }
        public int TeamId { get; set; }
        public int TournamentId { get; set; }
        public int AppUserId { get; set; }

    }
}
