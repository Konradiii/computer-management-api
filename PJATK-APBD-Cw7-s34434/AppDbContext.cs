using Microsoft.EntityFrameworkCore;
using PJATK_APBD_Cw7_s34434.DTOs;

namespace PJATK_APBD_Cw7_s34434;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<PC> PCs { get; set; }
    public DbSet<Component> Components { get; set; }
    public DbSet<PCComponent> PCComponents { get; set; }
    public DbSet<ComponentType> ComponentTypes { get; set; }
    public DbSet<ComponentManufacture> ComponentManufactures { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ComponentType>(builder =>
        {
            builder.ToTable("ComponentTypes");
            builder.HasKey(ct => ct.Id);
            builder.Property(ct => ct.Abbreviation).IsRequired().HasMaxLength(30);
            builder.Property(ct => ct.Name).IsRequired().HasMaxLength(150);

            builder.HasData(
                new ComponentType { Id = 1, Abbreviation = "CPU", Name = "Central Processing Unit" },
                new ComponentType { Id = 2, Abbreviation = "GPU", Name = "Graphics Processing Unit" },
                new ComponentType { Id = 3, Abbreviation = "RAM", Name = "Random Access Memory" }
            );
        });

        modelBuilder.Entity<ComponentManufacture>(builder =>
        {
            builder.ToTable("ComponentManufactures");
            builder.HasKey(cm => cm.Id);
            builder.Property(cm => cm.Abbreviation).IsRequired().HasMaxLength(30);
            builder.Property(cm => cm.FullName).IsRequired().HasMaxLength(300);
            builder.Property(cm => cm.FoundationDate).IsRequired(false).HasColumnType("date");

            builder.HasData(
                new ComponentManufacture { Id = 1, Abbreviation = "Intel", FullName = "Intel Corporation", FoundationDate = new DateTime(1968, 7, 18) },
                new ComponentManufacture { Id = 2, Abbreviation = "AMD", FullName = "Advanced Micro Devices", FoundationDate = new DateTime(1969, 5, 1) },
                new ComponentManufacture { Id = 3, Abbreviation = "NVIDIA", FullName = "NVIDIA Corporation", FoundationDate = new DateTime(1993, 4, 5) }
            );
        });

        modelBuilder.Entity<Component>(builder =>
        {
            builder.ToTable("Components");
            builder.HasKey(c => c.Code);
            builder.Property(c => c.Code).IsRequired().HasMaxLength(10).HasColumnType("char(10)");
            builder.Property(c => c.Name).IsRequired().HasMaxLength(300);
            builder.Property(c => c.Description).IsRequired(false).HasColumnType("nvarchar(max)");

            builder.HasOne(c => c.ComponentManufacture)
                   .WithMany(cm => cm.Components)
                   .HasForeignKey(c => c.ComponentManufacturesId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.ComponentType)
                   .WithMany(ct => ct.Components)
                   .HasForeignKey(c => c.ComponentTypeId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(
                new Component { Code = "I9-14900K", Name = "Intel Core i9-14900K", ComponentManufacturesId = 1, ComponentTypeId = 1 },
                new Component { Code = "RX7900XTX", Name = "AMD Radeon RX 7900 XTX", ComponentManufacturesId = 2, ComponentTypeId = 2 },
                new Component { Code = "DDR5-32GB", Name = "DDR5 32GB 6000MHz", ComponentManufacturesId = 2, ComponentTypeId = 3 }
            );
        });

        modelBuilder.Entity<PC>(builder =>
        {
            builder.ToTable("PCs");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Weight).HasColumnType("float");
            builder.Property(p => p.Warranty).IsRequired(false);
            builder.Property(p => p.CreatedAt).HasColumnType("datetime");
            builder.Property(p => p.Stock).IsRequired();

            builder.HasData(
                new PC { Id = 1, Name = "Gaming Pro",    Weight = 8.5f,  Warranty = "3 lata", CreatedAt = new DateTime(2024, 1, 15), Stock = 10 },
                new PC { Id = 2, Name = "WorkStation X", Weight = 12.0f, Warranty = "2 lata", CreatedAt = new DateTime(2024, 3, 20), Stock = 5  },
                new PC { Id = 3, Name = "Budget Build",  Weight = 6.5f,  Warranty = "1 rok",  CreatedAt = new DateTime(2024, 6, 1),  Stock = 20 }
            );
        });

        modelBuilder.Entity<PCComponent>(builder =>
        {
            builder.ToTable("PCComponents");
            builder.HasKey(pc => new { pc.PCId, pc.ComponentCode });
            builder.Property(pc => pc.ComponentCode).IsRequired().HasMaxLength(10).HasColumnType("char(10)");
            builder.Property(pc => pc.Amount).IsRequired();

            builder.HasOne(pc => pc.PC)
                   .WithMany(p => p.PCComponents)
                   .HasForeignKey(pc => pc.PCId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(pc => pc.Component)
                   .WithMany(c => c.PCComponents)
                   .HasForeignKey(pc => pc.ComponentCode)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(
                new PCComponent { PCId = 1, ComponentCode = "I9-14900K", Amount = 1 },
                new PCComponent { PCId = 1, ComponentCode = "RX7900XTX", Amount = 1 },
                new PCComponent { PCId = 2, ComponentCode = "DDR5-32GB", Amount = 2 },
                new PCComponent { PCId = 3, ComponentCode = "I9-14900K", Amount = 1 },
                new PCComponent { PCId = 3, ComponentCode = "DDR5-32GB", Amount = 1 }
            );
        });
    }
}