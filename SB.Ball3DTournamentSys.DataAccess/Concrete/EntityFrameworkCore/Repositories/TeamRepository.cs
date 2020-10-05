using Microsoft.EntityFrameworkCore;
using SB.Ball3DTournamentSys.DataAccess.Concrete.Contexts;
using SB.Ball3DTournamentSys.DataAccess.Interfaces;
using SB.Ball3DTournamentSys.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SB.Ball3DTournamentSys.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class TeamRepository : EfGenericRepository<TeamEntity>, ITeamDAL
    {
        public List<TeamEntity> GetOwnedTeamsByUserId(int id)
        {
            using var context = new B3DTContext();
            return context.Teams.Where(I => I.AppUserId == id).ToList();
        }
    }
}
