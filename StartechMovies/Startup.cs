using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StartechMovies.Startup))]
namespace StartechMovies
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
