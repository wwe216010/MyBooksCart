using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyBooksCart.Startup))]
namespace MyBooksCart
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
