using HotelSolutionBackend.Command.Data.Context;
using HotelSolutionBackend.Command.Domain.Abstractions.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelSolutionBackend.Command.Data.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        protected readonly HotelSolutionBackendCommandContext Db;

        public RepositoryBase(HotelSolutionBackendCommandContext db)
        {
            Db = db;
        }

        public void Add(TEntity obj)
        {
            Db.Set<TEntity>().Add(obj);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Db.Set<TEntity>().ToList();
        }

        public TEntity GetById(Guid id)
        {
            return Db.Set<TEntity>().Find(id);
        }

        public TEntity GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(TEntity obj)
        {
            Db.Set<TEntity>().Remove(obj);
        }

        public async Task SaveChangesAsync()
        {
            await Db.SaveChangesAsync();
        }

        public void UpdateRowVersionTimestamp(TEntity obj, byte[] rowVersion)
        {
            throw new NotImplementedException();
        }
    }
}
