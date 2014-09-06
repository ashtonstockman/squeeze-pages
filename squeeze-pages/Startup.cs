using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(squeeze_pages.Startup))]
namespace squeeze_pages
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
