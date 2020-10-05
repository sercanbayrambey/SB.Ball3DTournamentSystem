using SB.Ball3DTournamentSys.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SB.Ball3DTournamentSys.Entities.Concrete
{
    public class TournamentTeamsEntity  : ITable
    {
        public int Id { get; set; }

        public int TournamentId { get; set; }
        public TournamentEntity Tournament { get; set; }

        public int TeamId { get; set; }
        public TeamEntity Team { get; set; }

        public bool IsWinner { get; set; } = false;

        public bool IsConfirmed { get; set; } = false;

    }
}
