using SB.Ball3DTournamentSys.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SB.Ball3DTournamentSys.Entities.Concrete
{
    public class StadiumEntity : ITable
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<TournamentEntity> Tournaments { get; set; }

    }
}
