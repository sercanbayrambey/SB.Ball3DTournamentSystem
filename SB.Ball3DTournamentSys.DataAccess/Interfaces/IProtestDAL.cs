using SB.Ball3DTournamentSys.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SB.Ball3DTournamentSys.DataAccess.Interfaces
{
    public interface IProtestDAL : IGenericDAL<ProtestEntity>
    {
        public List<ProtestEntity> GetAllByUserIdWithAll(int userId);
        ProtestEntity GetByIdWithAll(int id);
    }
}
