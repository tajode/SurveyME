using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SurveyME.Startup))]
namespace SurveyME
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
