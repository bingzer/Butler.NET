using Bingzer.StickDraw.AuthService.Repository;
using Bingzer.StickDraw.AuthService.Services;
using Ninject.Modules;

namespace Bingzer.StickDraw.AuthService
{
    public class AuthServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IClientService>().To<ClientService>();
            Bind<IUserService>().To<UserService>();
            Bind<IUserRepository>().To<InMemoryUserRepository>();
            Bind<IClientRepository>().To<InMemoryClientRepository>();
            Bind<IRoleRepository>().To<InMemoryRoleRepository>();
        }
    }
}
