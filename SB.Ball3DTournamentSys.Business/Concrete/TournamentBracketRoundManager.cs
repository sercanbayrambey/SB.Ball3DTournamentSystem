using SB.Ball3DTournamentSys.Business.Interfaces;
using SB.Ball3DTournamentSys.DataAccess.Interfaces;
using SB.Ball3DTournamentSys.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SB.Ball3DTournamentSys.Business.Concrete
{
    public class TournamentBracketRoundManager : GenericManager<TournamentBracketRoundEntity>, ITournamentBracketRoundService
    {
        private readonly ITournamentBracketRoundDAL _tournamentBracketRoundDAL;
        public TournamentBracketRoundManager(ITournamentBracketRoundDAL tournamentBracketRoundDAL) : base(tournamentBracketRoundDAL)
        {
            _tournamentBracketRoundDAL = tournamentBracketRoundDAL;
        }
    }
}
