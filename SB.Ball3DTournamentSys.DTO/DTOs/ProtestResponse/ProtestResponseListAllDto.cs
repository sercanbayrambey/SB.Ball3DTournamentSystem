using SB.Ball3DTournamentSys.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SB.Ball3DTournamentSys.DTO.DTOs.ProtestResponse
{
    public class ProtestResponseListAllDto
    {
        public int Id { get; set; }
        public int ProtestId { get; set; }
        public ProtestEntity Protest { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
