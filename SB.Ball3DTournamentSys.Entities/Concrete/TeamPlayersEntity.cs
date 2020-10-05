using SB.Ball3DTournamentSys.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SB.Ball3DTournamentSys.Entities.Concrete
{
    public class TeamPlayersEntity : ITable
    {
        public int Id { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public int TeamId { get; set; }
        public TeamEntity Team{ get; set; }

        public DateTime JoinDate { get; set; } = DateTime.Now;
    }
}
