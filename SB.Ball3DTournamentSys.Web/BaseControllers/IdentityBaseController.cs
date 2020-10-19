using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SB.Ball3DTournamentSys.Entities.Concrete;
using SB.Ball3DTournamentSys.Web.StringConsts;

namespace SB.Ball3DTournamentSys.Web.BaseControllers
{
    public class IdentityBaseController : Controller
    {
        protected readonly UserManager<AppUser> _userManager;

        public IdentityBaseController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }


        protected AppUser GetLoggedUser()
        {
            return _userManager.FindByNameAsync(User.Identity.Name).Result;
        }


        //Needs refactor.
        protected bool IsLoggedUserTeamOwner(TeamEntity team)
        {
            if (team.AppUserId == GetLoggedUser().Id)
                return true;

            return false;
        }

        protected bool IsLogged()
        {
            return User.Identity.IsAuthenticated;
        }

        protected bool IsAuthorized(int userId)
        {
            if (GetLoggedUser().Id != userId)
                return false;
            return true;
        }
        protected bool IsAdmin()
        {
            return _userManager.IsInRoleAsync(GetLoggedUser(), ConstRoles.Admin).Result;

        }

    }
}
