using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Bookstore2.Startup))]
namespace Bookstore2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
