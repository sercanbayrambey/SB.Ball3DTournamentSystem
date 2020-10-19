using Microsoft.AspNetCore.Identity;
using SB.Ball3DTournamentSys.Business.Interfaces;
using SB.Ball3DTournamentSys.DataAccess.Interfaces;
using SB.Ball3DTournamentSys.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SB.Ball3DTournamentSys.Business.Concrete
{
    public class ProtestResponseManager : GenericManager<ProtestResponseEntity>,IProtestResponseService
    {
        private readonly IProtestResponseDAL _protestResponseDAL;
        private readonly UserManager<AppUser> _userManager;
        private readonly IProtestService _protestService;
        public ProtestResponseManager(IProtestResponseDAL protestResponseDAL, UserManager<AppUser> userManager, IProtestService protestService) : base(protestResponseDAL)
        {
            _protestResponseDAL = protestResponseDAL;
            _userManager = userManager;
            _protestService = protestService;
        }

        public List<ProtestResponseEntity> GetProtestResponsesByProtestIdWithAll(int protestId)
        {
            return _protestResponseDAL.GetProtestResponsesByProtestIdWithAll(protestId);
        }

        public override void Add(ProtestResponseEntity table)
        {

            var user = _userManager.FindByIdAsync(table.AppUserId.ToString()).Result;
            if ((table.AppUserId != _protestService.GetById(table.ProtestId).AppUserId) && !_userManager.IsInRoleAsync(user, "admin").Result)
                throw new Exception("Authorize ERROR!");
            
            base.Add(table);
        }
    }
}
