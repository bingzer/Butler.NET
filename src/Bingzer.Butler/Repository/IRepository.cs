using System.Linq;
using Bingzer.Butler.Entity;

namespace Bingzer.Butler.Repository
{
    public interface IRepository<TEntity> : IRepository<TEntity, long> where TEntity : IEntity
    {
    }

    public interface IRepository<TEntity, in TIdentity> where TEntity : IEntity<TIdentity>
    {
        IQueryable<TEntity> Find();

        TEntity Find(TIdentity id);

        TEntity Add(TEntity item);
        bool Remove(TEntity item);
        TEntity Update(TEntity item);

        void Save();
    }
}
