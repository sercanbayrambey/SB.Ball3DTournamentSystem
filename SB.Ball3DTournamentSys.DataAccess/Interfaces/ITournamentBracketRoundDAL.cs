﻿using SB.Ball3DTournamentSys.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SB.Ball3DTournamentSys.DataAccess.Interfaces
{
    public interface ITournamentBracketRoundDAL :IGenericDAL<TournamentBracketRoundEntity>
    {
        int GetRoundIdByTournamentId(int tournamentId);
    }
}
