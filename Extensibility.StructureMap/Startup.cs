using Extensibility.BasicDI.Contracts;
using Extensibility.BasicDI.Hubs;
using Extensibility.BasicDI.Services;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Owin;
using StructureMap;

[assembly: OwinStartupAttribute(typeof(Extensibility.BasicDI.Startup))]
namespace Extensibility.BasicDI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            var container = new Container(p =>
            {
                p.For<IHelpTicketRepository>()
                    .Use<InMemoryHelpTicketRepository>()
                    .Singleton();
            });

            StructureMapSignalRDependencyResolver resolver = 
                new StructureMapSignalRDependencyResolver(container);

            HubConfiguration hubConfiguration = new HubConfiguration();
            hubConfiguration.Resolver = resolver;

            app.MapSignalR(hubConfiguration);
        }
    }
}
