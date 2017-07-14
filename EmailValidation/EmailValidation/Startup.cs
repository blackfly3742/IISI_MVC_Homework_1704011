using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EmailValidation.Startup))]
namespace EmailValidation
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
