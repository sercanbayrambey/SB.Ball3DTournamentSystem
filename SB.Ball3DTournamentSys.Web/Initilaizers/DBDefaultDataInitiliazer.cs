using SB.Ball3DTournamentSys.Business.Interfaces;
using SB.Ball3DTournamentSys.Entities.Concrete;

namespace SB.Ball3DTournamentSys.Web.Initilaizers
{
    public static class DBDefaultDataInitiliazer
    {
        public static void SeedData(IGameServerService _gameServerService, IStadiumService _stadiumService)
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


        }
    }
}
