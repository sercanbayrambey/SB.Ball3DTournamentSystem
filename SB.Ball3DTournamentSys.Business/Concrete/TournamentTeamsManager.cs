using SB.Ball3DTournamentSys.Business.Interfaces;
using SB.Ball3DTournamentSys.DataAccess.Interfaces;
using SB.Ball3DTournamentSys.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SB.Ball3DTournamentSys.Business.Concrete
{
    public class TournamentTeamsManager: GenericManager<TournamentTeamsEntity>, ITournamentTeamsService
    {
        private readonly ITournamentTeamsDAL _tournamentTeamsDAL;
        public TournamentTeamsManager(ITournamentTeamsDAL tournamentTeamsDAL) : base(tournamentTeamsDAL)
        {
            _tournamentTeamsDAL = tournamentTeamsDAL;
        }

        public void ConfirmRegisterStatus(TeamEntity team, int tournamentId)
        {
            _tournamentTeamsDAL.ConfirmRegisterStatus(team, tournamentId);
        }

        public int GetTotalTeamCountByTournamentId(int tournamentId)
        {
            return _tournamentTeamsDAL.GetTotalTeamCountByTournamentId(tournamentId);
        }

        public List<TeamEntity> GetTournamentConfirmedTeamsByTournamentId(int tournamentId)
        {
            return _tournamentTeamsDAL.GetTournamentConfirmedTeamsByTournamentId(tournamentId);
        }
    }
}
