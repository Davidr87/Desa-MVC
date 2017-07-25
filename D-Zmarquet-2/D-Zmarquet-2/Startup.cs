using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(D_Zmarquet_2.Startup))]
namespace D_Zmarquet_2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
