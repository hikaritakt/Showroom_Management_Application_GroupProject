using Microsoft.EntityFrameworkCore;
using ShowroomApp.Models;

namespace ShowroomApp.Data
{
    internal class AppDbContext : DbContext
    {
        public DbSet<Brand> Brands => Set<Brand>();
        public DbSet<Car> Cars => Set<Car>();
        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<OrderDetail> OrderDetails => Set<OrderDetail>();

        public DbSet<CarModel> CarModels => Set<CarModel>();
        public DbSet<Color> Colors => Set<Color>();
        public DbSet<CarStatus> CarStatuses => Set<CarStatus>();
        public DbSet<CarInventoryTransaction> CarInventoryTransactions => Set<CarInventoryTransaction>();

        public DbSet<Accessory> Accessories => Set<Accessory>();
        public DbSet<AccessoryInventoryTransaction> AccessoryInventoryTransactions => Set<AccessoryInventoryTransaction>();
        public DbSet<CarAccessory> CarAccessories => Set<CarAccessory>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    "Server=TAKT;Username=sa;Password=123;Database=ShowroomDB;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>(entity =>
            {
                entity.ToTable("Brand");
                entity.HasKey(x => x.BrandId);
                entity.Property(x => x.BrandId).HasColumnName("brand_id");
                entity.Property(x => x.BrandName).HasColumnName("brand_name").HasMaxLength(100).IsRequired();
            });

            modelBuilder.Entity<Car>(entity =>
            {
                entity.ToTable("Car");
                entity.HasKey(x => x.CarId);
                entity.Property(x => x.CarId).HasColumnName("car_id");
                entity.Property(x => x.CarName).HasColumnName("car_name").HasMaxLength(100).IsRequired();
                entity.Property(x => x.Price).HasColumnName("price").HasColumnType("decimal(18,2)");
                entity.Property(x => x.Quantity).HasColumnName("quantity");
                entity.Property(x => x.BrandId).HasColumnName("brand_id");
                entity.Property(x => x.ModelId).HasColumnName("model_id");
                entity.Property(x => x.ColorId).HasColumnName("color_id");
                entity.Property(x => x.StatusId).HasColumnName("status_id");

                entity.HasOne(x => x.Brand)
                    .WithMany(x => x.Cars)
                    .HasForeignKey(x => x.BrandId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.CarModel)
                    .WithMany(x => x.Cars)
                    .HasForeignKey(x => x.ModelId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.Color)
                    .WithMany(x => x.Cars)
                    .HasForeignKey(x => x.ColorId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.Status)
                    .WithMany(x => x.Cars)
                    .HasForeignKey(x => x.StatusId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }