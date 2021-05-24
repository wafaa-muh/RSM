using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using WebApplication3.Models;

[assembly: OwinStartupAttribute(typeof(WebApplication3.Startup))]
namespace WebApplication3
{
    public partial class Startup
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateDefaultRolesAndUsers();
        }

        public void CreateDefaultRolesAndUsers()
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            IdentityRole role = new IdentityRole();
            if (!roleManager.RoleExists("Admins"))
            {
                role.Name = "Admins";
                roleManager.Create(role);
                ApplicationUser user = new ApplicationUser();
                user.UserName = "Wafaa";
                user.Email = "wafaa.muh.k@gmail.com";
                var check = userManager.Create(user, "Wafaa123;");
                if (check.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Admins");
                }
            }
        }
    }
}
