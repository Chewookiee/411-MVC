using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FoamMVC.Startup))]
namespace FoamMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
