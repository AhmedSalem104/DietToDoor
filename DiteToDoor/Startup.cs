using Microsoft.Owin;
using Owin;


[assembly: OwinStartupAttribute(typeof(DiteToDoor.Startup))]
namespace DiteToDoor
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            
        }
       
    }
}
