using SB.Ball3DTournamentSys.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SB.Ball3DTournamentSys.Entities.Concrete
{
    public class TournamentEntity : ITable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int GameType { get; set; }
        public bool IsFinished { get; set; }
        public DateTime StartDate { get; set; }

        public int ServerTypeId { get; set; }

        public bool IsOvertimeEnabled { get; set; }
        public int ScoreLimit { get; set; }
        public bool IsStarted { get; set; }

        public int StadiumId { get; set; }

        public StadiumEntity Stadium { get; set; }

        public int GameServerId { get; set; }
        public GameServerEntity GameServer { get; set; }

        public List<PlayedGamesEntity> PlayedGames { get; set; }

        public List<TournamentTeamsEntity> TournamentTeams { get; set; }




    }
}
