using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WeddingApp.Startup))]
namespace WeddingApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
