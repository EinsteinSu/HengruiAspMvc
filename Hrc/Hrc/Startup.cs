using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Hrc.Startup))]
namespace Hrc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
