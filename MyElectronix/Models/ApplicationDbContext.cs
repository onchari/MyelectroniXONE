using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

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
        public DbSet<TestModel> TestModels { get; set; }
        public DbSet<SubTest> SubTests { get; set; }
    }
}