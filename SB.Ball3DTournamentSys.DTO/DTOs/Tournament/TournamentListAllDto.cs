using SB.Ball3DTournamentSys.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SB.Ball3DTournamentSys.DTO.DTOs.Tournament
{
    public class TournamentListAllDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int GameType { get; set; }
        public DateTime StartDate { get; set; }
        public bool IsStarted { get; set; }
        public bool IsFinished { get; set; }

        public bool IsOvertimeEnabled { get; set; }
        public int ScoreLimit { get; set; }

        public StadiumEntity Stadium { get; set; }

        public GameServerEntity GameServer { get; set; }

        public List<PlayedGamesEntity> PlayedGames { get; set; }

        public List<TournamentTeamsEntity> TournamentTeams { get; set; }
    }
}
