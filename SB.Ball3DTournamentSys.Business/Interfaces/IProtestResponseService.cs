using SB.Ball3DTournamentSys.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SB.Ball3DTournamentSys.Business.Interfaces
{
    public interface IProtestResponseService : IGenericService<ProtestResponseEntity>
    {
        List<ProtestResponseEntity> GetProtestResponsesByProtestIdWithAll(int protestId);
    }
}
