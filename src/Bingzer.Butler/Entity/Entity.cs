using System.ComponentModel.DataAnnotations;

namespace Bingzer.Butler.Entity
{
    /// <summary>
    /// An entity with Id as Long-type
    /// </summary>
    public class Entity : IEntity
    {
        [Key]
        public long Id { get; set; }
    }

    /// <summary>
    /// Entity with Identity generic
    /// </summary>
    /// <typeparam name="TIdentity"></typeparam>
    public class Entity<TIdentity> : IEntity<TIdentity>
    {
        [Key]
        public TIdentity Id { get; set; }
    }
}
