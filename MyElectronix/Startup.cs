using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyElectronix.Startup))]
namespace MyElectronix
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
