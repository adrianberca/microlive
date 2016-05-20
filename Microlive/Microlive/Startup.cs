using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Microlive.Startup))]
namespace Microlive
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
