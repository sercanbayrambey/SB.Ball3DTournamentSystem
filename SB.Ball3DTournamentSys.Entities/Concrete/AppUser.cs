using Microsoft.AspNetCore.Identity;
using SB.Ball3DTournamentSys.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SB.Ball3DTournamentSys.Entities.Concrete
{
    public class AppUser :IdentityUser<int>, ITable
    {
        public List<TeamEntity> OwnedTeams { get; set; }
        public List<TeamPlayersEntity> Teams{ get; set; }
        public string Login { get; set; }
    }
}
