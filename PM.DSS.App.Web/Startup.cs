using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PM.DSS.App.Web.Startup))]
namespace PM.DSS.App.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
