using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_1.Startup))]
namespace MVC_1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
