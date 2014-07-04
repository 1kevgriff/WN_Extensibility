using Extensibility.BasicDI.Hubs;
using Extensibility.BasicDI.Services;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Extensibility.BasicDI.Startup))]
namespace Extensibility.BasicDI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            GlobalHost.DependencyResolver.Register(
                typeof(HelpTicketHub),
                () => 
                {
                    return new HelpTicketHub(new InMemoryHelpTicketRepository());
                });

            app.MapSignalR();
        }
    }
}
