using SB.Ball3DTournamentSys.Business.Interfaces;
using SB.Ball3DTournamentSys.DataAccess.Interfaces;
using SB.Ball3DTournamentSys.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SB.Ball3DTournamentSys.Business.Concrete
{
    public class PlayedGamesManager : GenericManager<PlayedGamesEntity>,IPlayedGamesService

    {
        private readonly IPlayedGamesDAL _playedGamesDAL;
        public PlayedGamesManager(IPlayedGamesDAL playedGamesDAL) : base(playedGamesDAL)
        {
            _playedGamesDAL = playedGamesDAL;
        }
    }
}
