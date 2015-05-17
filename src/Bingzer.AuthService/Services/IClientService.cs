using Bingzer.StickDraw.AuthService.Entities;

namespace Bingzer.StickDraw.AuthService.Services
{
    public interface IClientService
    {
        /// <summary>
        /// Returns client by its id
        /// </summary>
        /// <param name="clientId"></param>
        /// <returns></returns>
        Client FindClient(string clientId);

        /// <summary>
        /// Validates client and client secret.
        /// If valid returns the client if not returns null
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="clientSecret"></param>
        /// <returns></returns>
        Client ValidateClient(string clientId, string clientSecret);
    }
}
