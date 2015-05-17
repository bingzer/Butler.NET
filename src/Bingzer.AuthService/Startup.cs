using System;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using Microsoft.Owin.Cors;
using Newtonsoft.Json.Serialization;
using Ninject;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi;
using Ninject.Web.WebApi.OwinHost;
using Owin;

namespace Bingzer.StickDraw.AuthService
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var kernel = new StandardKernel(new AuthServiceModule());

            app.UseCors(CorsOptions.AllowAll);
            app.Use(async (env, next) =>
            {
                await next();
                Console.WriteLine("" + env.Request.Method + " (" + env.Response.StatusCode + ")  " + env.Request.Uri.LocalPath);
            });
            app.ConfigureOAuth(kernel);

            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            config.DependencyResolver = new NinjectDependencyResolver(kernel);
            config.Formatters.OfType<JsonMediaTypeFormatter>().First().SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            app.UseNinjectMiddleware(() => kernel).UseNinjectWebApi(config);
        }
    }
}
