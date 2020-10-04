using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SB.Ball3DTournamentSys.DTO.DTOs.AppUser;
using SB.Ball3DTournamentSys.Web.StringConsts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SB.Ball3DTournamentSys.Web.ViewComponents
{
    public class TopNavbar : ViewComponent
    {
    
        public IViewComponentResult Invoke()
        {
            if (User.Identity.IsAuthenticated) 
            {
                var model = new AppUserNavbarDTO { UserName = User.Identity.Name };
                if (User.IsInRole(ConstRoles.Admin))
                    return View("LoggedAdminNavbar",model);

                return View("LoggedUserNavbar",model);
            }
            return View(); // default.cshtml, is a guest view
        }
    }
}
