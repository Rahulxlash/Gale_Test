using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AIS_Test.Web.Startup))]
namespace AIS_Test.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
