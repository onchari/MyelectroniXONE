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
        public DbSet<TestClass> TestClasses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<MainCategory> MainCategories { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

    }
}