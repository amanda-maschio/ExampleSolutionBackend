using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelSolutionBackend.Command.Domain.Abstractions.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        public void Add(TEntity obj);
        public TEntity GetById(int id);
        public IEnumerable<TEntity> GetAll();
        public void Remove(TEntity obj);
        public Task SaveChangesAsync();
    }
}
