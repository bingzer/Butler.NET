using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Bingzer.StickDraw.AuthService.Entities;
using Bingzer.StickDraw.AuthService.Repository;

namespace Bingzer.StickDraw.AuthService.Services
{
    internal class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<User> GetUsers()
        {
            // TODO: use pagination
            return _repository.Find().ToList();
        }

        public User FindUser(string email)
        {
            return _repository.Find().FirstOrDefault(u => u.Email == email);
        }

        public bool ValidateUser(string username, string password)
        {
            var user = FindUser(username);
            if (user != null)
                return user.Password == password;
            return false;
        }

        public ClaimsIdentity CreateIdentity(User user)
        {
            var identity = new ClaimsIdentity("JWT");
            identity.AddClaim(new Claim(ClaimTypes.Name, user.Email));
            identity.AddClaim(new Claim(ClaimTypes.Email, user.Email));
            identity.AddClaim(new Claim(ClaimTypes.GivenName, user.FirstName));
            identity.AddClaim(new Claim(ClaimTypes.Surname, user.LastName));
            foreach (var role in user.Roles)
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, role.Name));
            }

            return identity;
        }
    }
}
