using Microsoft.AspNetCore.Identity;
using SB.Ball3DTournamentSys.Business.Interfaces;
using SB.Ball3DTournamentSys.Entities.Concrete;
using SB.Ball3DTournamentSys.Web.StringConsts;
using System.Linq;

namespace SB.Ball3DTournamentSys.Web.Initilaizers
{
    public static class DBDefaultDataInitiliazer
    {
        public static void SeedData(IGameServerService _gameServerService, IStadiumService _stadiumService, UserManager<AppUser> _userManager, RoleManager<AppRole> _roleManager)
        {
            var gameServers = _gameServerService.GetAll();
            if (gameServers.Count <= 0)
            {
                _gameServerService.Add(new GameServerEntity { ServerName = "EU Dedicated" });
                _gameServerService.Add(new GameServerEntity { ServerName = "USA Dedicated" });
                _gameServerService.Add(new GameServerEntity { ServerName = "Hosted Server" });
            }

            var stadiums = _stadiumService.GetAll();
            if(stadiums.Count<=0)
            {
                _stadiumService.Add(new StadiumEntity { Name = "Real Football" });
                _stadiumService.Add(new StadiumEntity { Name = "Good" });
                _stadiumService.Add(new StadiumEntity { Name = "Classic" });
                _stadiumService.Add(new StadiumEntity { Name = "Small" });
                _stadiumService.Add(new StadiumEntity { Name = "Real Football" });
                _stadiumService.Add(new StadiumEntity { Name = "Small Pong" });
            }

           
            var roles = _roleManager.Roles.ToList();
            if(roles.Count<=0)
            {
                _roleManager.CreateAsync(new AppRole { Name = ConstRoles.Admin }).Wait();
                _roleManager.CreateAsync(new AppRole { Name = ConstRoles.Member }).Wait();
            }


            var adminUser = _userManager.FindByNameAsync("compo").Result;
            if(adminUser == null)
            {
                AppUser user = new AppUser
                {
                    Email = "sercanbayrambeyy@gmail.com",
                    Login = "compo",
                    UserName = "compo"
                };
                string pass = "123456";
                _userManager.CreateAsync(user, pass).Wait();
                _userManager.AddToRoleAsync(user, ConstRoles.Admin).Wait();
            }




        }
    }
}
