using Microsoft.EntityFrameworkCore;
using PhoneApp.Entities;
using static PhoneApp.Entities.Sales;

namespace PhoneApp.Data
{
    public class PhoneDbContext : DbContext
    {
        public PhoneDbContext(DbContextOptions<PhoneDbContext> options) : base(options) { }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<PriceHistory> PriceHistories { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<StockMovement> StockMovements { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Brand>();
            modelBuilder.Entity<Model>();
            modelBuilder.Entity<Feature>();
            
            modelBuilder.Entity<PriceHistory>()
                .HasOne(p => p.Model)
                .WithMany()
                .HasForeignKey(p => p.ModelID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Sale>()
                .HasOne(s => s.Model)
                .WithMany()
                .HasForeignKey(s => s.ModelID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
