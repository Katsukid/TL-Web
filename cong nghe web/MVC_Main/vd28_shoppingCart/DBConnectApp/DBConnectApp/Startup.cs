using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DBConnectApp.Startup))]
namespace DBConnectApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
