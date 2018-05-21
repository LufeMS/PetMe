using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PetMe.Startup))]
namespace PetMe
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
