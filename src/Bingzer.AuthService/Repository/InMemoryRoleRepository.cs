using System.Collections.Generic;
using System.Linq;
using Bingzer.Butler.Repository;
using Bingzer.StickDraw.AuthService.Entities;

namespace Bingzer.StickDraw.AuthService.Repository
{
    public class InMemoryRoleRepository : CollectionBasedRepository<Role>, IRoleRepository
    {
        private readonly ICollection<Role> _roles; 

        public override ICollection<Role> DataSource { get { return _roles; } }

        public InMemoryRoleRepository()
        {
            _roles = new HashSet<Role>
            {
                new Role {Id = 0, Name = "Administrator"}, 
                new Role {Id = 1, Name = "User"}
            };
        }

        public Role GetRole(string name)
        {
            return Find().FirstOrDefault(r => r.Name == name);
        }
    }
}
