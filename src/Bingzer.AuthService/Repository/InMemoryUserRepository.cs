using System.Collections.Generic;
using Bingzer.Butler.Repository;
using Bingzer.StickDraw.AuthService.Entities;

namespace Bingzer.StickDraw.AuthService.Repository
{
    public class InMemoryUserRepository : CollectionBasedRepository<User>, IUserRepository
    {
        private readonly ICollection<User> _users;  

        public override ICollection<User> DataSource { get { return _users; } }

        public InMemoryUserRepository(IRoleRepository roleRepository)
        {
            _users = new HashSet<User>
            {
                new User
                {
                    Email = "ricky@localhost", 
                    Password = "password",
                    FirstName = "Ricky",
                    LastName = "Tobing",
                    Roles = new HashSet<Role>
                    {
                        roleRepository.GetRole("User")
                    }
                },
                new User
                {
                    Email = "admin@localhost", 
                    Password = "password",
                    FirstName = "Admin",
                    LastName = "Admin",
                    Roles = new HashSet<Role>
                    {
                        roleRepository.GetRole("Administrator"), 
                        roleRepository.GetRole("User")
                    }
                }
            };
        }
    }
}
