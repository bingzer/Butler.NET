namespace Bingzer.Butler.Entity
{
    public interface IEntity : IEntity<long>
    {
    }

    public interface IEntity<TIdentity>
    {
        TIdentity Id { get; set; }
    }
}
