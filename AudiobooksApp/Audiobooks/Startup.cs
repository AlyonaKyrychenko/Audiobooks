using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Audiobooks.Startup))]
namespace Audiobooks
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
