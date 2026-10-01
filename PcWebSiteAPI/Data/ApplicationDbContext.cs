using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PcWebSiteAPI.Models;

namespace PcWebSiteAPI.Data;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<BuyOrder> BuyOrders { get; set; }

    public virtual DbSet<Kunder> Kunders { get; set; }

    public virtual DbSet<OrderHistory> OrderHistories { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<OrderTotal> OrderTotals { get; set; }

    public virtual DbSet<PostNr> PostNrs { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductList> ProductLists { get; set; }

    public virtual DbSet<ProductSpecification> ProductSpecifications { get; set; }

    public virtual DbSet<Saelger> Saelgers { get; set; }

    public virtual DbSet<Specification> Specifications { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Brand>(entity =>
        {
            entity.HasKey(e => e.BrandId).HasName("PK__brands__AABC2567770CDB55");

            entity.ToTable("brands", "production");

            entity.HasIndex(e => e.BrandName, "UQ__brands__1E20FB9A1FEDAC49").IsUnique();

            entity.Property(e => e.BrandId).HasColumnName("Brand_id");
            entity.Property(e => e.BrandName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Brand_name");
        });

        modelBuilder.Entity<BuyOrder>(entity =>
        {
            entity.HasKey(e => e.OrdersId).HasName("PK__buyOrder__B2D00CA4B6F09958");

            entity.ToTable("buyOrders", "selling");

            entity.Property(e => e.OrdersId).HasColumnName("Orders_id");
            entity.Property(e => e.CustomerId).HasColumnName("Customer_id");
            entity.Property(e => e.OrderDate).HasColumnName("Order_date");
            entity.Property(e => e.OrderStatus)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Order_status");
            entity.Property(e => e.SaelgerId).HasColumnName("Saelger_id");

            entity.HasOne(d => d.Customer).WithMany(p => p.BuyOrders)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__buyOrders__Custo__489AC854");

            entity.HasOne(d => d.Saelger).WithMany(p => p.BuyOrders)
                .HasForeignKey(d => d.SaelgerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__buyOrders__Saelg__47A6A41B");
        });

        modelBuilder.Entity<Kunder>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__kunder__8CB382B12E7B13A1");

            entity.ToTable("kunder", "selling");

            entity.Property(e => e.CustomerId).HasColumnName("Customer_id");
            entity.Property(e => e.Email)
                .HasMaxLength(75)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("First_name");
            entity.Property(e => e.Gade)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Last_name");
        });

        modelBuilder.Entity<OrderHistory>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("OrderHistory", "selling");

            entity.Property(e => e.BrandName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Brand_name");
            entity.Property(e => e.CustomerId).HasColumnName("Customer_id");
            entity.Property(e => e.FirstName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("First_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Last_name");
            entity.Property(e => e.LineTotal)
                .HasColumnType("decimal(21, 2)")
                .HasColumnName("Line_total");
            entity.Property(e => e.ModelInfo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Model_Info");
            entity.Property(e => e.OrderDate).HasColumnName("Order_date");
            entity.Property(e => e.OrderItemId).HasColumnName("OrderItem_id");
            entity.Property(e => e.OrderStatus)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Order_status");
            entity.Property(e => e.OrdersId).HasColumnName("Orders_id");
            entity.Property(e => e.ProductId).HasColumnName("Product_id");
            entity.Property(e => e.SaelgerId).HasColumnName("Saelger_id");
            entity.Property(e => e.UnitPrice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Unit_price");
            entity.Property(e => e.Virksomhedsnavn)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => e.OrderItemId).HasName("PK__orderIte__2F31262AC21FDA93");

            entity.ToTable("orderItems", "selling");

            entity.Property(e => e.OrderItemId).HasColumnName("OrderItem_id");
            entity.Property(e => e.OrdersId).HasColumnName("Orders_id");
            entity.Property(e => e.ProductId).HasColumnName("Product_id");
            entity.Property(e => e.UnitPrice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Unit_price");

            entity.HasOne(d => d.Orders).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.OrdersId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__orderItem__Order__5BAD9CC8");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__orderItem__Produ__5CA1C101");
        });

        modelBuilder.Entity<OrderTotal>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("OrderTotals", "selling");

            entity.Property(e => e.CustomerId).HasColumnName("Customer_id");
            entity.Property(e => e.FirstName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("First_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Last_name");
            entity.Property(e => e.OrderDate).HasColumnName("Order_date");
            entity.Property(e => e.OrderStatus)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Order_status");
            entity.Property(e => e.OrderTotal1)
                .HasColumnType("decimal(38, 2)")
                .HasColumnName("Order_total");
            entity.Property(e => e.OrdersId).HasColumnName("Orders_id");
        });

        modelBuilder.Entity<PostNr>(entity =>
        {
            entity.HasKey(e => e.PostNr1).HasName("PK__postNr__AA124BB839A3706A");

            entity.ToTable("postNr", "selling");

            entity.Property(e => e.PostNr1)
                .ValueGeneratedNever()
                .HasColumnName("PostNr");
            entity.Property(e => e.ByNavn).HasMaxLength(75);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__products__9833FF92B4A2B6E1");

            entity.ToTable("products", "production");

            entity.Property(e => e.ProductId).HasColumnName("Product_id");
            entity.Property(e => e.BrandId).HasColumnName("Brand_id");
            entity.Property(e => e.ModelInfo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Model_Info");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ProductType)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Product_type");

            entity.HasOne(d => d.Brand).WithMany(p => p.Products)
                .HasForeignKey(d => d.BrandId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__products__Brand___4F47C5E3");
        });

        modelBuilder.Entity<ProductList>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Product_List", "production");

            entity.Property(e => e.BrandName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Brand_name");
            entity.Property(e => e.ModelInfo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Model_Info");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ProductId).HasColumnName("Product_id");
            entity.Property(e => e.ProductType)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Product_type");
            entity.Property(e => e.SpecificationName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Specification_name");
            entity.Property(e => e.SpecificationValue)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Specification_value");
            entity.Property(e => e.Unit)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ProductSpecification>(entity =>
        {
            entity.HasKey(e => e.ProductSpecificationId).HasName("PK__productS__0D3E383B7627C3B7");

            entity.ToTable("productSpecifications", "production");

            entity.HasIndex(e => new { e.ProductId, e.SpecificationId }, "UQ__productS__D9DDDC2D273733AB").IsUnique();

            entity.Property(e => e.ProductSpecificationId).HasColumnName("ProductSpecification_id");
            entity.Property(e => e.ProductId).HasColumnName("Product_id");
            entity.Property(e => e.SpecificationId).HasColumnName("Specification_id");
            entity.Property(e => e.SpecificationValue)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Specification_value");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductSpecifications)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__productSp__Produ__55F4C372");

            entity.HasOne(d => d.Specification).WithMany(p => p.ProductSpecifications)
                .HasForeignKey(d => d.SpecificationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__productSp__Speci__56E8E7AB");
        });

        modelBuilder.Entity<Saelger>(entity =>
        {
            entity.HasKey(e => e.SaelgerId).HasName("PK__saelger__E0931D03F43B3A82");

            entity.ToTable("saelger", "selling");

            entity.Property(e => e.SaelgerId).HasColumnName("Saelger_id");
            entity.Property(e => e.Cvr).HasColumnName("CVR");
            entity.Property(e => e.Gade)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Virksomhedsnavn)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Specification>(entity =>
        {
            entity.HasKey(e => e.SpecificationId).HasName("PK__specific__1EE23BE56D4FB256");

            entity.ToTable("specifications", "production");

            entity.HasIndex(e => e.SpecificationName, "UQ__specific__BA64D5E1B64F13B9").IsUnique();

            entity.Property(e => e.SpecificationId).HasColumnName("Specification_id");
            entity.Property(e => e.SpecificationName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Specification_name");
            entity.Property(e => e.Unit)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
