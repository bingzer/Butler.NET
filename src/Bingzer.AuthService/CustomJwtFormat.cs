using System;
using System.IdentityModel.Tokens;
using Bingzer.Butler;
using Bingzer.StickDraw.AuthService.Services;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataHandler.Encoder;
using Thinktecture.IdentityModel.Tokens;

namespace Bingzer.StickDraw.AuthService
{
    public class CustomJwtFormat : ISecureDataFormat<AuthenticationTicket>
    {
        private readonly IClientService _clientService;
        private readonly string _issuer;

        public CustomJwtFormat(IClientService clientService, string issuer)
        {
            _clientService = clientService;
            _issuer = issuer;
        }

        public string Protect(AuthenticationTicket data)
        {
            if (data == null)
            {
                throw new ArgumentNullException("data");
            }

            var clientId = data.Properties.Dictionary.ContainsKey("clientId") ? data.Properties.Dictionary["clientId"] : null;

            if (string.IsNullOrWhiteSpace(clientId)) throw new InvalidOperationException("AuthenticationTicket.Properties does not include audience");

            var client = _clientService.FindClient(clientId);
            var keyBytes = TextEncodings.Base64Url.Decode(client.Secret);
            var signingKey = new HmacSigningCredentials(keyBytes);
            var issued = data.Properties.IssuedUtc;
            var expires = data.Properties.ExpiresUtc;
            var token = new JwtSecurityToken(_issuer, clientId, data.Identity.Claims, issued.Value.UtcDateTime, expires.Value.UtcDateTime, signingKey);
            var handler = new JwtSecurityTokenHandler();
            var jwt = handler.WriteToken(token);

            return jwt;
        }

        public AuthenticationTicket Unprotect(string protectedText)
        {
            throw new NotImplementedException();
        }
    }
}
