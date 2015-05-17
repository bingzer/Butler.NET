using System.Collections.Generic;
using System.Threading.Tasks;
using Bingzer.StickDraw.AuthService.Services;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;

namespace Bingzer.StickDraw.AuthService
{
    public class CustomOAuthProvider : OAuthAuthorizationServerProvider
    {
        private readonly IClientService _clientService;
        private readonly IUserService _userService;

        public CustomOAuthProvider(IClientService clientService, IUserService userService)
        {
            _clientService = clientService;
            _userService = userService;
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            string clientId;
            string clientSecret;
            if (!context.TryGetBasicCredentials(out clientId, out clientSecret))
            {
                context.TryGetFormCredentials(out clientId, out clientSecret);
            }

            var client = _clientService.ValidateClient(clientId, clientSecret);
            if (client == null)
            {
                context.SetError("invalid_clientId", "Incorrect client_id or client_secret");
                return Task.FromResult(0);
            }

            context.Validated();
            return Task.FromResult(0);
        }


        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            if (!_userService.ValidateUser(context.UserName, context.Password))
            {
                context.SetError("invalid_grant", "The username or password is incorrect");
                return Task.FromResult(0);
            }

            var user = _userService.FindUser(context.UserName);
            var identity = _userService.CreateIdentity(user);
            var props = new AuthenticationProperties(new Dictionary<string, string>
            {
                { "clientId", context.ClientId ?? string.Empty }
            });

            var ticket = new AuthenticationTicket(identity, props);
            context.Validated(ticket);
            return Task.FromResult<object>(null);
        }
    }
}
