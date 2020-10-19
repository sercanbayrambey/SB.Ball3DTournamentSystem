using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SB.Ball3DTournamentSys.DTO.DTOs.ProtestResponse
{
    public class CreateProtestResponseDto
    {
        [Required]
        public int ProtestId { get; set; }
        [Required]
        public int AppUserId { get; set; }
        [Required]
        [MaxLength(512)]
        public string Text { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
