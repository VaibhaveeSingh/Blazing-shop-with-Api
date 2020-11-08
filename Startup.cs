using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BlazingShop.Startup))]
namespace BlazingShop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
