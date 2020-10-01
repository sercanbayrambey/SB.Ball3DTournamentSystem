using SB.Ball3DTournamentSys.DataAccess.Concrete.Contexts;
using SB.Ball3DTournamentSys.DataAccess.Interfaces;
using SB.Ball3DTournamentSys.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SB.Ball3DTournamentSys.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfGenericRepository<EntityTable> : IGenericDAL<EntityTable> where EntityTable : class, ITable, new()
    {
        public void Add(EntityTable table)
        {
            using var context = new B3DTContext();
            context.Set<EntityTable>().Add(table);
            context.SaveChanges();
        }

        public void Delete(EntityTable table)
        {
            using var context = new B3DTContext();
            context.Set<EntityTable>().Remove(table);
            context.SaveChanges();
        }

        public List<EntityTable> GetAll()
        {
            using var context = new B3DTContext();
            return context.Set<EntityTable>().ToList();
        }

        public EntityTable GetById(int id)
        {
            using var context = new B3DTContext();
            return context.Set<EntityTable>().Find(id);
        }

        public void Update(EntityTable table)
        {
            using var context = new B3DTContext();
            context.Set<EntityTable>().Update(table);
            context.SaveChanges();
        }
    }

}
