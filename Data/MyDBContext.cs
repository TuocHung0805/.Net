using Microsoft.EntityFrameworkCore;
using Store.Models;

namespace Store.Data
{
    public class MyDBContext : DbContext
    {
        public MyDBContext(DbContextOptions options) : base(options)
        {

        }

        #region DBSet
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(e =>
            {
                e.ToTable("Orders");
                e.HasKey(o => o.MaDH);
                e.Property(o => o.NgayDat).HasDefaultValueSql("getutcdate()");

                e.HasOne(o => o.Customer)
                .WithMany(o => o.Orders)
                .HasForeignKey(o => o.MaKH);
            });

            modelBuilder.Entity<OrderDetail>(e =>
            {
                e.ToTable("OrderDetail");
                e.HasKey(od => new { od.MaDH, od.MaSP });

                e.HasOne(od => od.Order)
                .WithMany(od => od.OrderDetails)
                .HasForeignKey(od => od.MaDH);

                e.HasOne(od => od.Product)
                .WithMany()
                .HasForeignKey(od => od.MaSP);
            });
    }
    }
}
