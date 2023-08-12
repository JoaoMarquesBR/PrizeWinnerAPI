using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PrizeWinner.Domain.Entities;

public partial class TheFactoryDevContext : DbContext
{
    public TheFactoryDevContext()
    {
    }

    public TheFactoryDevContext(DbContextOptions<TheFactoryDevContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Guest> Guests { get; set; }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<ItemGroup> ItemGroups { get; set; }

    public virtual DbSet<PromotionGroup> PromotionGroups { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=thefactorylondon-db.cjhy495rnkkn.us-west-2.rds.amazonaws.com;Database=TheFactoryDev;User Id=admin;Password=TheFactory2020;Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Guest>(entity =>
        {
            entity.HasKey(e => e.GuestId).HasName("PK__Guest__8D59CD7CAD3A9C8A");

            entity.ToTable("Guest");

            entity.Property(e => e.GuestId).HasColumnName("guestID");
            entity.Property(e => e.ExpiringDate)
                .HasColumnType("datetime")
                .HasColumnName("expiringDate");
            entity.Property(e => e.FirstName)
                .HasMaxLength(80)
                .HasColumnName("firstName");
            entity.Property(e => e.GroupId).HasColumnName("groupID");
            entity.Property(e => e.LastName)
                .HasMaxLength(80)
                .HasColumnName("lastName");
            entity.Property(e => e.SignedInDate)
                .HasColumnType("datetime")
                .HasColumnName("signedInDate");
            entity.Property(e => e.UserEmail)
                .HasMaxLength(80)
                .HasColumnName("userEmail");
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.ItemId).HasName("PK__Item__727E83EBD9A932C7");

            entity.ToTable("Item");

            entity.Property(e => e.ItemId).HasColumnName("ItemID");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Price).HasColumnType("money");
        });

        modelBuilder.Entity<ItemGroup>(entity =>
        {
            entity.HasKey(e => e.ItemGroupId).HasName("PK__ItemGrou__CCB7CA9D4ECAD2E1");

            entity.ToTable("ItemGroup");

            entity.Property(e => e.ItemGroupId).HasColumnName("ItemGroupID");
            entity.Property(e => e.ItemId).HasColumnName("ItemID");
            entity.Property(e => e.PromotionGroupId).HasColumnName("PromotionGroupID");

            entity.HasOne(d => d.Item).WithMany(p => p.ItemGroups)
                .HasForeignKey(d => d.ItemId)
                .HasConstraintName("FK__ItemGroup__ItemI__1AD3FDA4");

            entity.HasOne(d => d.PromotionGroup).WithMany(p => p.ItemGroups)
                .HasForeignKey(d => d.PromotionGroupId)
                .HasConstraintName("FK__ItemGroup__Promo__1BC821DD");
        });

        modelBuilder.Entity<PromotionGroup>(entity =>
        {
            entity.HasKey(e => e.PromotionGroupId).HasName("PK__Promotio__8BE3BF403370DCFA");

            entity.ToTable("PromotionGroup");

            entity.Property(e => e.PromotionGroupId).HasColumnName("PromotionGroupID");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.GroupName).HasMaxLength(40);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
