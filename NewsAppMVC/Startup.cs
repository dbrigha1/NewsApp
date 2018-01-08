using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NewsAppMVC.Startup))]
namespace NewsAppMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
