using Microsoft.EntityFrameworkCore;
using PIPlatform.UserManager.DomainModel.Entities;

namespace PIPlatform.UserManager.DAL
{
    public class UserManagerContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductOrder> ProductOrders { get; set; }
        public DbSet<Supply> Supplies { get; set; }
        public DbSet<NovaUser> NovaUsers { get; set; }

        public UserManagerContext() : base(GenerateOptions("Data Source=DESKTOP-6PLD2PB;Initial Catalog=UserManager;Integrated Security=True;MultipleActiveResultSets=True;TrustServerCertificate=True;"))
        {
            Database.EnsureCreated();
        }

        private static DbContextOptions<UserManagerContext> GenerateOptions(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<UserManagerContext>()
                .UseSqlServer(connectionString);
            return optionsBuilder.Options;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>()
                .Property(c => c.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Order>()
                .Property(c => c.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customer)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Order>()
                .Property(c => c.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
