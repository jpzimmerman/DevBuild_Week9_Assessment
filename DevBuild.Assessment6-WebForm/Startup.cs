using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin;
using Microsoft.Owin.Host.SystemWeb;
using Microsoft.Owin.Security.Cookies;
using Owin;

[assembly: OwinStartup(typeof(DevBuild.Assessment6_WebForm.Startup))]

namespace DevBuild.Assessment6_WebForm
{
    public class Startup
    {
        private readonly string _connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Joshua_PartyDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public void Configuration(IAppBuilder app)
        {

            IdentityDbContext context = new IdentityDbContext(_connectionString);

            app.CreatePerOwinContext(() => new IdentityDbContext(_connectionString));

            app.CreatePerOwinContext<UserStore<IdentityUser>>((opt, cont) => new UserStore<IdentityUser>(cont.Get<IdentityDbContext>()));

            app.CreatePerOwinContext<UserManager<IdentityUser>>(
                            (opt, cont) => new UserManager<IdentityUser>(cont.Get<UserStore<IdentityUser>>()));

            //ConfigureAuth(app);

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Identity/Login"),
                
                //LoginPath = new Microsoft.Owin.PathString(),
            });


            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
        }
    }
}
