using System;
using System.Collections.Generic;
using System.Text;

namespace SB.Ball3DTournamentSys.DTO.DTOs.Protest
{
    public class CreateProtestDto
    {
        public string Text { get; set; }
        public string Title { get; set; }
        public int PlayedGameId { get; set; }
        public int AppUserId { get; set; }


    }
}
