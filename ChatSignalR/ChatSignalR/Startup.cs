using Microsoft.Owin;
using Owin;

namespace ChatSignalR
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}