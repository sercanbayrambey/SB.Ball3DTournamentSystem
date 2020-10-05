﻿using SB.Ball3DTournamentSys.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SB.Ball3DTournamentSys.Business.Interfaces
{
    public interface ITeamPlayersService :IGenericService<TeamPlayersEntity>
    {
        List<TeamEntity> GetUserTeamsById(int id);
    }
}
