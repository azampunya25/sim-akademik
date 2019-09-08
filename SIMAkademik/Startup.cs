using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SIMAkademik.Startup))]
namespace SIMAkademik
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
