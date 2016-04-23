using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PCInfoEditor.Startup))]
namespace PCInfoEditor
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
