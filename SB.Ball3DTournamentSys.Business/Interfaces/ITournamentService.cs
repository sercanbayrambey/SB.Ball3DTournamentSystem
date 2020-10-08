using SB.Ball3DTournamentSys.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SB.Ball3DTournamentSys.Business.Interfaces
{
    public interface ITournamentService : IGenericService<TournamentEntity>
    {
        List<TournamentEntity> GetAllWithAllTables();
        List<TournamentEntity> GetFinishedTournamentsWithAllTables();
        List<TournamentEntity> GetStartedTournamentsWithAllTables();
        List<TournamentEntity> GetUpcomingTournamentsWithAllTables();
        TournamentEntity GetTournamentWithAllTablesById(int id);
        void StartTournament(List<TeamEntity> teams);

    }
}
