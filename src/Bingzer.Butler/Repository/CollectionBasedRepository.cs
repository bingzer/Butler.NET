using System.Collections.Generic;
using System.Linq;
using Bingzer.Butler.Entity;

namespace Bingzer.Butler.Repository
{

    /// <summary>
    /// Collection-based repository
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TIdentity"></typeparam>
    public abstract class CollectionBasedRepository<TEntity, TIdentity> : IRepository<TEntity, TIdentity> where TEntity : IEntity<TIdentity>
    {
        public abstract ICollection<TEntity> DataSource { get; }

        public virtual IQueryable<TEntity> Find()
        {
            return DataSource.AsQueryable();
        }

        public virtual TEntity Find(TIdentity id)
        {
            return Find().FirstOrDefault(c => c.Id.Equals(id));
        }

        public virtual TEntity Add(TEntity item)
        {
            DataSource.Add(item);
            return item;
        }

        public virtual bool Remove(TEntity item)
        {
            return DataSource.Remove(item);
        }

        public virtual TEntity Update(TEntity item)
        {
            var oldItem = Find().FirstOrDefault(i => i.Id.Equals(item.Id));
            if (oldItem == null)
                return default(TEntity);

            DataSource.Remove(oldItem);
            DataSource.Add(item);
            return item;
        }

        public virtual void Save()
        {
            // DO nothing
        }
    }

    public abstract class CollectionBasedRepository<TEntity> : CollectionBasedRepository<TEntity, long> where TEntity : IEntity
    {
    }
}
