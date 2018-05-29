using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using MyElectronix.Areas.Admin.Models;

namespace MyElectronix.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Category> Categories { get; set; }

        public System.Data.Entity.DbSet<MyElectronix.Areas.Admin.Models.TestClass> TestClasses { get; set; }

        public System.Data.Entity.DbSet<MyElectronix.Areas.Admin.Models.Student> Students { get; set; }
    }
}