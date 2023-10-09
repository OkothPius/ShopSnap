using Microsoft.EntityFrameworkCore;
using ShopSnap.Models;

namespace ShopSnap.Data;

public partial class DatabaseContext : DbContext
{

    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Item> Items { get; set; }

    // CONNECTION STRING
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Server=localhost;Database=AppGoods;Username=ruko;Password=pass123;Port=5432");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("items_pkey");

            entity.ToTable("items");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ProductName)
                .HasColumnType("character varying")
                .HasColumnName("product_name");
            entity.Property(e => e.ProductPrice).HasColumnName("product_price");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
