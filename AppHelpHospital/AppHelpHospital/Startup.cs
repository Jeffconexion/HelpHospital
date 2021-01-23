using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AppHelpHospital.Startup))]
namespace AppHelpHospital
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
