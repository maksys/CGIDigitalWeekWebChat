using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CGIDigitalWeekWebChat.Startup))]
namespace CGIDigitalWeekWebChat
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
