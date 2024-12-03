using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using p50_8_22.Models;


namespace p50_8_22.Models;

public partial class SamokatDbContext : DbContext
{
    public SamokatDbContext()
    {
    }

    public SamokatDbContext(DbContextOptions<SamokatDbContext> options)
        : base(options)
    {
    }


    public DbSet<Client> Client { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=EgorPC\\SQLEXPRESS01;Initial Catalog=BPN;Integrated Security=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleID).HasName("PK__Roles__8AFACE3A65449A52");

            entity.HasIndex(e => e.RoleName, "UQ__Roles__8A2B616005821DF9").IsUnique();

            entity.Property(e => e.RoleID).HasColumnName("RoleID");
            entity.Property(e => e.RoleName).HasMaxLength(50);
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.UserID).HasName("PK__Client__1788CCAC6956D34F");


            entity.HasIndex(e => e.Email, "UQ__Client__A9D10534EF10C61F").IsUnique();

            entity.Property(e => e.UserID).HasColumnName("UserID");
            entity.Property(e => e.DateJoined)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Login).HasMaxLength(100);
            entity.Property(e => e.PasswordHash).HasMaxLength(200);
            entity.Property(e => e.RoleID).HasColumnName("RoleID");

            entity.HasOne(d => d.Role).WithMany(p => p.Client)
                .HasForeignKey(d => d.RoleID)
                .HasConstraintName("FK__Client__RoleID__3C69FB99");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
