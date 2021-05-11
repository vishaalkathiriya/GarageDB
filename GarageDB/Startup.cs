using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GarageDB.Startup))]
namespace GarageDB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
