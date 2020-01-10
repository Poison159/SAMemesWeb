using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SAMemes.Startup))]
namespace SAMemes
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
