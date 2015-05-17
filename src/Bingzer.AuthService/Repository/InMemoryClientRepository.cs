using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using Bingzer.Butler.Repository;
using Bingzer.StickDraw.AuthService.Entities;

namespace Bingzer.StickDraw.AuthService.Repository
{
    public class InMemoryClientRepository : CollectionBasedRepository<Client>, IClientRepository
    {
        private readonly ICollection<Client> _clients;

        public override ICollection<Client> DataSource { get { return _clients; } }

        public InMemoryClientRepository()
        {
            _clients = new HashSet<Client>
            {
                new Client { ClientId = "123456", Name = "Test01", Secret = "IxrAjDoa2FqElO7IhrSrUJELhUckePEPVpaePlS_Xaw" }
            };
        }

        private static string GenerateRandomSecret()
        {
            var data = new byte[32];
            using (var crypto = new RNGCryptoServiceProvider())
            {
                crypto.GetBytes(data);
                return Convert.ToBase64String(data);
            }
        }
    }
}
