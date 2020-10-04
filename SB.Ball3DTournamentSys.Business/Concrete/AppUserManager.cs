using SB.Ball3DTournamentSys.Business.Interfaces;
using SB.Ball3DTournamentSys.DataAccess.Interfaces;
using SB.Ball3DTournamentSys.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SB.Ball3DTournamentSys.Business.Concrete
{
    public class AppUserManager: GenericManager<AppUser>,IAppUserService
    {
        private readonly IAppUserDAL _appUserDAL;
        public AppUserManager(IAppUserDAL appUserDAL) : base(appUserDAL)
        {
            _appUserDAL = appUserDAL;
        }
    }
}
