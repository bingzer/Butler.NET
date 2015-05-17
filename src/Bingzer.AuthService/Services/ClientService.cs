using System.Linq;
using Bingzer.StickDraw.AuthService.Entities;
using Bingzer.StickDraw.AuthService.Repository;

namespace Bingzer.StickDraw.AuthService.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _repository;

        public ClientService(IClientRepository repository)
        {
            _repository = repository;
        }

        public Client FindClient(string clientId)
        {
            return _repository.Find().FirstOrDefault(c => c.ClientId == clientId);
        }

        public Client ValidateClient(string clientId, string clientSecret)
        {
            var client = FindClient(clientId);
            if (client != null && client.Secret != clientSecret)
                return null;
            return client;
        }
    }
}
