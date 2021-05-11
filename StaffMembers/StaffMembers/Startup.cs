using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StaffMembers.Startup))]
namespace StaffMembers
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
