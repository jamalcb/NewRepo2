using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RMA.Models;

public partial class RmaContext : DbContext
{
    public RmaContext()
    {
    }

    public RmaContext(DbContextOptions<RmaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<MenuItem> MenuItems { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-5N8J203;Initial catalog=RMA;Integrated Security=true;Trust server Certificate=true;MultipleActiveResultSets=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MenuItem>(entity =>
        {
            entity.HasKey(e => e.ItemId);

            entity.Property(e => e.Description)
                .HasMaxLength(550)
                .IsUnicode(false);
            entity.Property(e => e.ImagePath)
                .HasMaxLength(550)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.Property(e => e.Cgst).HasColumnName("CGST");
            entity.Property(e => e.GrandTotal)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.OrderDate).HasColumnType("datetime");
            entity.Property(e => e.Sgst).HasColumnName("SGST");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("Role");

            entity.Property(e => e.RoleName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
