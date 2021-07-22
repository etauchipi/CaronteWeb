using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CaronteWeb.Startup))]
namespace CaronteWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
