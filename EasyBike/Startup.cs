using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EasyBike.Startup))]
namespace EasyBike
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
