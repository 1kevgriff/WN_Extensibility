using Extensibility.BasicDI.Contracts;
using Extensibility.BasicDI.Hubs;
using Extensibility.BasicDI.Services;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Ninject;
using Owin;

[assembly: OwinStartupAttribute(typeof(Extensibility.BasicDI.Startup))]
namespace Extensibility.BasicDI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            var kernel = new StandardKernel();
            NinjectSignalRDependencyResolver resolver = new NinjectSignalRDependencyResolver(kernel);

            /* configure kernel */
            kernel.Bind<IHelpTicketRepository>()
                .To<InMemoryHelpTicketRepository>()
                .InSingletonScope();

            HubConfiguration hubConfiguration = new HubConfiguration();
            hubConfiguration.Resolver = resolver;

            app.MapSignalR(hubConfiguration);
        }
    }
}
