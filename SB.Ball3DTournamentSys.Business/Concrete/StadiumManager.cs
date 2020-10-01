using SB.Ball3DTournamentSys.Business.Interfaces;
using SB.Ball3DTournamentSys.DataAccess.Interfaces;
using SB.Ball3DTournamentSys.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SB.Ball3DTournamentSys.Business.Concrete
{
    public class StadiumManager:GenericManager<StadiumEntity>,IStadiumService
    {
        private readonly IStadiumDAL _stadiumDAL;
        public StadiumManager(IStadiumDAL stadiumDAL) : base(stadiumDAL)
        {
            _stadiumDAL = stadiumDAL;
        }
    }
}
