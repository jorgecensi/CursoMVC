using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JLC.CursoMVC.UI.Mvc.Startup))]
namespace JLC.CursoMVC.UI.Mvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
