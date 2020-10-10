using SB.Ball3DTournamentSys.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SB.Ball3DTournamentSys.Business.Interfaces
{
    public interface IFixtureService
    {
        void GenerateFixture();
        void GenerateNextRounds(int teamCount, int round, int tournamentId, int? passedTeamCount);
        void SaveEntitiesToDb();
        PlayedGamesEntity FindTheNextTableForGame(PlayedGamesEntity playedGame);

    }
}
