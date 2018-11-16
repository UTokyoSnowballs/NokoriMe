using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SleepMakeSense.Startup))]
namespace SleepMakeSense
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
