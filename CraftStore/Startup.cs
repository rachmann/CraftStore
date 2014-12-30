using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CraftStore.Startup))]
namespace CraftStore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
