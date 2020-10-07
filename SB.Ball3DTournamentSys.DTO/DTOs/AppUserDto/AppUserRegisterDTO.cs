using System;
using System.Collections.Generic;
using System.Text;

namespace SB.Ball3DTournamentSys.DTO.DTOs.AppUserDto
{
    public class AppUserRegisterDTO
    {
        public string UserName { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

    }
}
