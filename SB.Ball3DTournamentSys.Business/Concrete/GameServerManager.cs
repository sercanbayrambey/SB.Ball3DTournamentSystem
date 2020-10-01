using SB.Ball3DTournamentSys.Business.Interfaces;
using SB.Ball3DTournamentSys.DataAccess.Interfaces;
using SB.Ball3DTournamentSys.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SB.Ball3DTournamentSys.Business.Concrete
{
    public class GameServerManager: GenericManager<GameServerEntity>, IGameServerService
    {
        private readonly IGameServerDAL _gameServerDAL;
        public GameServerManager(IGameServerDAL gameServerDAL) : base(gameServerDAL)
        {
            _gameServerDAL = gameServerDAL;
        }
    }
}
