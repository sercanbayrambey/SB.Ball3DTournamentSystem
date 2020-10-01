using Microsoft.EntityFrameworkCore.Query.Internal;
using SB.Ball3DTournamentSys.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SB.Ball3DTournamentSys.DataAccess.Interfaces
{
    public interface IGenericDAL<EntityTable> where EntityTable : class, ITable, new()

    {
        void Add(EntityTable table);
        void Delete(EntityTable table);
        void Update(EntityTable table);
        List<EntityTable> GetAll();
        EntityTable GetById(int id);


    }
}
