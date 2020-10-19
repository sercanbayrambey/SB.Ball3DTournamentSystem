using SB.Ball3DTournamentSys.Business.Interfaces;
using SB.Ball3DTournamentSys.DataAccess.Interfaces;
using SB.Ball3DTournamentSys.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SB.Ball3DTournamentSys.Business.Concrete
{
    public class ProtestManager : GenericManager<ProtestEntity>,IProtestService
    {
        private readonly IProtestDAL _protestDAL;
        public ProtestManager(IProtestDAL protestDAL) : base(protestDAL)
        {
            _protestDAL = protestDAL;
        }

   
        public List<ProtestEntity> GetAllByUserIdWithAll(int userId)
        {
            return _protestDAL.GetAllByUserIdWithAll(userId);
        }

        public ProtestEntity GetByIdWithAll(int id)
        {
            return _protestDAL.GetByIdWithAll(id);
        }
    }
}
