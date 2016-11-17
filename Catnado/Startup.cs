using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Catnado.Startup))]
namespace Catnado
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
