using Bingzer.Butler.Repository;
using Bingzer.StickDraw.AuthService.Entities;

namespace Bingzer.StickDraw.AuthService.Repository
{
    public interface IRoleRepository : IRepository<Role>
    {
        Role GetRole(string name);
    }
}
