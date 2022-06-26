using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SolutionDBFinalApp.Startup))]
namespace SolutionDBFinalApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
