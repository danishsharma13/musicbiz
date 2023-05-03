using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(F2022A6DS.Startup))]

namespace F2022A6DS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
