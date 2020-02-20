using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BeaconnectedWebApp.Startup))]
namespace BeaconnectedWebApp
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
