using formula_API.Models;
using Microsoft.EntityFrameworkCore;

namespace formula_API.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Formula> Formulas { get; set; }
        public DbSet<Product> Products { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Formula>()
                .Property(f => f.StepsData)
                .HasColumnType("jsonb");

            modelBuilder.Entity<Product>()
                .HasOne(f => f.Formula)
                .WithOne(p => p.Product)
                .HasForeignKey<Formula>(p => p.ProductId);

            modelBuilder.Entity<Product>(p =>
            {
                p.Property(x => x.ProductCode).IsRequired();
                p.Property(x => x.ProductName).IsRequired();
                p.Property(x => x.CreatedBy).IsRequired();
                p.Property(x => x.CreatedDate).IsRequired();
                p.HasData(new Product
                {
                    ProductId = 1,
                    ProductCode = "PRD001",
                    ProductName = "Jamu Obat Batuk",
                    Description = "Resep jamu untuk obat batuk",
                    CreatedBy = "API",
                    CreatedDate = new DateTime(2025, 5, 4, 0, 0, 0, DateTimeKind.Utc),
                },
                new Product
                {
                    ProductId = 2,
                    ProductCode = "PRD002",
                    ProductName = "Jamu Nyeri Haid",
                    Description = "Resep jamu untuk nyeri haid",
                    CreatedBy = "API",
                    CreatedDate = new DateTime(2025, 5, 4, 0, 0, 0, DateTimeKind.Utc),
                });
            });

            modelBuilder.Entity<Formula>(f =>
            {
                f.Property(x => x.ProductId).IsRequired();
                f.Property(x => x.CreatedBy).IsRequired();
                f.Property(x => x.CreatedDate).IsRequired();
            });
        }
    }
}
