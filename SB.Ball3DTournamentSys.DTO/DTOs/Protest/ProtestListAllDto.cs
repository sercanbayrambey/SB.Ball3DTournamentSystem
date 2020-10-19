using SB.Ball3DTournamentSys.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SB.Ball3DTournamentSys.DTO.DTOs.Protest
{
    public class ProtestListAllDto
    {
        public int Id { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public string Text { get; set; }
        public string Title { get; set; }

        public int PlayedGameId { get; set; }
        public PlayedGamesEntity PlayedGame { get; set; }

        public List<ProtestResponseEntity> ProtestResponses { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
