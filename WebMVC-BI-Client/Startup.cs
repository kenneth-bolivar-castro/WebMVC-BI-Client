using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebMVC_BI_Client.Startup))]
namespace WebMVC_BI_Client
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
