using System;
using Bingzer.StickDraw.AuthService.Services;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Ninject;
using Owin;

namespace Bingzer.StickDraw.AuthService
{
    internal static class OAuthExtensions
    {
        internal static void ConfigureOAuth(this IAppBuilder app, IKernel kernel)
        {
            var clientService = kernel.Get<IClientService>();
            var userService = kernel.Get<IUserService>();

            app.UseOAuthAuthorizationServer(
                new OAuthAuthorizationServerOptions
                {
                    AllowInsecureHttp = true,
                    TokenEndpointPath = new PathString("/oauth2/token"),
                    AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(30),
                    Provider = new CustomOAuthProvider(clientService, userService),
                    AccessTokenFormat = new CustomJwtFormat(clientService, "localhost")
                }
            );
        }
    }
}
