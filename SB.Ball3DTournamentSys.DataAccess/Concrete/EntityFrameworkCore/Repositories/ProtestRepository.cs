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
    public class ProtestRepository : EfGenericRepository<ProtestEntity>, IProtestDAL
    {

        public List<ProtestEntity> GetAllByUserIdWithAll(int userId)
        {
            using var context = new B3DTContext();
            return context.Protests.Include(I=>I.PlayedGame).ThenInclude(I=>I.AwayTeam).Include(I=>I.PlayedGame).ThenInclude(I=>I.HomeTeam).Include(I => I.AppUser).Where(I => I.AppUserId == userId).OrderByDescending(I=>I.Date).ToList();
        }

        public ProtestEntity GetByIdWithAll(int id)
        {
            using var context = new B3DTContext();
            return context.Protests.Include(I => I.PlayedGame).ThenInclude(I => I.AwayTeam).Include(I => I.PlayedGame).ThenInclude(I => I.HomeTeam).Include(I => I.AppUser).Where(I => I.Id == id).OrderByDescending(I => I.Date).FirstOrDefault();
        }
    }
}
