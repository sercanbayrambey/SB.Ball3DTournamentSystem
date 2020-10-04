using SB.Ball3DTournamentSys.DTO.DTOs.Tournament;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SB.Ball3DTournamentSys.Web.Models
{
    public class HomePageTournamentViewModel
    {
        public List<TournamentListAllDto> StartedTournaments { get; set; }
        public List<TournamentListAllDto> FinishedTournaments { get; set; }
        public List<TournamentListAllDto> UpcomingTournaments { get; set; }
    }
}
