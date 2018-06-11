using System;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;
using ResistorRating.Api;
using ResistorRating.Library;

[assembly: OwinStartup(typeof(Startup))]
namespace ResistorRating.Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            containerBuilder.RegisterWebApiFilterProvider(GlobalConfiguration.Configuration);

            AutofacBootstrap.Init(containerBuilder);

            var container = containerBuilder.Build();
            WebApiConfig.Register(GlobalConfiguration.Configuration);

            var webApiResolver = new AutofacWebApiDependencyResolver(container);

            app.UseCors(CorsOptions.AllowAll);
            GlobalConfiguration.Configuration.DependencyResolver = webApiResolver;
            GlobalConfiguration.Configuration.EnsureInitialized();
        }
    }
}
