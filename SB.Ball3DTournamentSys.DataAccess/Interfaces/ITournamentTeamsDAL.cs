﻿using SB.Ball3DTournamentSys.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SB.Ball3DTournamentSys.DataAccess.Interfaces
{
    public interface ITournamentTeamsDAL : IGenericDAL<TournamentTeamsEntity>
    {

        int GetTotalTeamCountByTournamentId(int tournamentId);
        List<TeamEntity> GetTournamentConfirmedTeamsByTournamentId(int tournamentId);
        void ConfirmRegisterStatus(TeamEntity team, int tournamentId);
    }
}
