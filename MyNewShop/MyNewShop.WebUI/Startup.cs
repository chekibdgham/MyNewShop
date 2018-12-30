using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyNewShop.WebUI.Startup))]
namespace MyNewShop.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
