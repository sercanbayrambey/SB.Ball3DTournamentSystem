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
    public class ProtestResponseRepository : EfGenericRepository<ProtestResponseEntity>, IProtestResponseDAL
    {
        public List<ProtestResponseEntity> GetProtestResponsesByProtestIdWithAll(int protestId)
        {
            using var context = new B3DTContext();
            return context.ProtestsResponses.Include(I => I.AppUser).Include(I => I.Protest).Where(I => I.ProtestId == protestId).OrderBy(I=>I.Date).ToList();
        }
    }
}
