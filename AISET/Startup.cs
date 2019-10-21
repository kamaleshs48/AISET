using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AISET.Startup))]
namespace AISET
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
