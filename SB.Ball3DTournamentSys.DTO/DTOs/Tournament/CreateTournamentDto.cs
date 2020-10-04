using SB.Ball3DTournamentSys.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SB.Ball3DTournamentSys.DTO.DTOs.Tournament
{
    public class CreateTournamentDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int GameType { get; set; }
        public bool IsFinished { get; set; } = false;
        public DateTime StartDate { get; set; }
        public bool IsOvertimeEnabled { get; set; }
        public int ScoreLimit { get; set; } // 0 = none
        public bool IsStarted { get; set; } = false;
        public int StadiumId { get; set; }
        public int GameServerId { get; set; }


    }
}
