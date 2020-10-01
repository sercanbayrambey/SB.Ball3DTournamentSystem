using SB.Ball3DTournamentSys.Business.Interfaces;
using SB.Ball3DTournamentSys.DataAccess.Interfaces;
using SB.Ball3DTournamentSys.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SB.Ball3DTournamentSys.Business.Concrete
{
    public class GenericManager<EntityTable> : IGenericService<EntityTable> where EntityTable : class, ITable, new()
    {
        private readonly IGenericDAL<EntityTable> _entityDAL;
        public GenericManager(IGenericDAL<EntityTable> entityDAL)
        {
            _entityDAL = entityDAL;
        }
        public void Add(EntityTable table)
        {
            _entityDAL.Add(table);
        }

        public void Delete(EntityTable table)
        {
            _entityDAL.Delete(table);
        }

        public List<EntityTable> GetAll()
        {
            return _entityDAL.GetAll();
        }

        public EntityTable GetById(int id)
        {
            return _entityDAL.GetById(id);
        }

        public void Update(EntityTable table)
        {
            _entityDAL.Update(table);
        }
    }
}
