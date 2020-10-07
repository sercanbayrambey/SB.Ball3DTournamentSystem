using SB.Ball3DTournamentSys.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SB.Ball3DTournamentSys.DTO.DTOs.Team
{
    public class JoinTeamDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Tag { get; set; }
        public AppUser AppUser { get; set; }
        public string InviteCode { get; set; }
        public int UserIdToBeJoined { get; set; }
    }
}
