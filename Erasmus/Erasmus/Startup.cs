using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Erasmus.Startup))]
namespace Erasmus
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
