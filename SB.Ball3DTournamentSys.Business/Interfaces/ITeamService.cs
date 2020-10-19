using SB.Ball3DTournamentSys.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SB.Ball3DTournamentSys.Business.Interfaces
{
    public interface ITeamService: IGenericService<TeamEntity>
    {
        List<TeamEntity> GetOwnedTeamsByUserId(int id);
        string GenerateInviteLink();
        TeamEntity GetTeamByInviteCodeWithUserTable(string inviteCode);
        bool IsUserOwner(int userId, int teamId);
        
    }
}
