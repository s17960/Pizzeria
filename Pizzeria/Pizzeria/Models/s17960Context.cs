using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Pizzeria.Models
{
    public partial class s17960Context : DbContext
    {
        public s17960Context()
        {
        }

        public s17960Context(DbContextOptions<s17960Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Components> Components { get; set; }
        public virtual DbSet<Deliverer> Deliverer { get; set; }
        public virtual DbSet<Diameter> Diameter { get; set; }
        public virtual DbSet<Dough> Dough { get; set; }
        public virtual DbSet<Drink> Drink { get; set; }
        public virtual DbSet<DrinkPromotion> DrinkPromotion { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderDrink> OrderDrink { get; set; }
        public virtual DbSet<OrderPizza> OrderPizza { get; set; }
        public virtual DbSet<OrderSauce> OrderSauce { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }
        public virtual DbSet<Pizza> Pizza { get; set; }
        public virtual DbSet<PizzaComponents> PizzaComponents { get; set; }
        public virtual DbSet<PizzaPromotion> PizzaPromotion { get; set; }
        public virtual DbSet<Promotion> Promotion { get; set; }
        public virtual DbSet<Sauce> Sauce { get; set; }
        public virtual DbSet<SaucePromotion> SaucePromotion { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=db-mssql;Initial Catalog=s17960;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Components>(entity =>
            {
                entity.HasKey(e => e.ComponentId)
                    .HasName("Components_pk");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Deliverer>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Dough>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Drink>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("money");
            });

            modelBuilder.Entity<DrinkPromotion>(entity =>
            {
                entity.HasKey(e => new { e.DrinkId, e.PromotionId })
                    .HasName("DrinkPromotion_pk");

                entity.HasOne(d => d.Drink)
                    .WithMany(p => p.DrinkPromotion)
                    .HasForeignKey(d => d.DrinkId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("DrinkPromotion_Drink");

                entity.HasOne(d => d.Promotion)
                    .WithMany(p => p.DrinkPromotion)
                    .HasForeignKey(d => d.PromotionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("DrinkPromotion_Promotion");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Deliverer)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.DelivererId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Order_Deliverer");

                entity.HasOne(d => d.Payment)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.PaymentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Order_Payment");
            });

            modelBuilder.Entity<OrderDrink>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.DrinkId })
                    .HasName("OrderDrink_pk");

                entity.HasOne(d => d.Drink)
                    .WithMany(p => p.OrderDrink)
                    .HasForeignKey(d => d.DrinkId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Table_8_Drink");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDrink)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Table_8_Order");
            });

            modelBuilder.Entity<OrderPizza>(entity =>
            {
                entity.HasKey(e => new { e.PizzaId, e.OrderId })
                    .HasName("OrderPizza_pk");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderPizza)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("OrderPizza_Order");

                entity.HasOne(d => d.Pizza)
                    .WithMany(p => p.OrderPizza)
                    .HasForeignKey(d => d.PizzaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("OrderPizza_Pizza");
            });

            modelBuilder.Entity<OrderSauce>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.SauceId })
                    .HasName("OrderSauce_pk");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderSauce)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("OrderSauce_Order");

                entity.HasOne(d => d.Sauce)
                    .WithMany(p => p.OrderSauce)
                    .HasForeignKey(d => d.SauceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("OrderSauce_Sauce");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Pizza>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("money");

                entity.HasOne(d => d.Diameter)
                    .WithMany(p => p.Pizza)
                    .HasForeignKey(d => d.DiameterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Pizza_Diameter");

                entity.HasOne(d => d.Dough)
                    .WithMany(p => p.Pizza)
                    .HasForeignKey(d => d.DoughId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Pizza_Dough");
            });

            modelBuilder.Entity<PizzaComponents>(entity =>
            {
                entity.HasKey(e => new { e.ComponentsId, e.PizzaId })
                    .HasName("PizzaComponents_pk");

                entity.HasOne(d => d.Components)
                    .WithMany(p => p.PizzaComponents)
                    .HasForeignKey(d => d.ComponentsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PizzaComponents_Components");

                entity.HasOne(d => d.Pizza)
                    .WithMany(p => p.PizzaComponents)
                    .HasForeignKey(d => d.PizzaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PizzaComponents_Pizza");
            });

            modelBuilder.Entity<PizzaPromotion>(entity =>
            {
                entity.HasKey(e => new { e.PromotionId, e.PizzaId })
                    .HasName("PizzaPromotion_pk");

                entity.HasOne(d => d.Pizza)
                    .WithMany(p => p.PizzaPromotion)
                    .HasForeignKey(d => d.PizzaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PizzaPromotion_Pizza");

                entity.HasOne(d => d.Promotion)
                    .WithMany(p => p.PizzaPromotion)
                    .HasForeignKey(d => d.PromotionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PizzaPromotion_Promotion");
            });

            modelBuilder.Entity<Promotion>(entity =>
            {
                entity.Property(e => e.Price).HasColumnType("money");
            });

            modelBuilder.Entity<Sauce>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("money");
            });

            modelBuilder.Entity<SaucePromotion>(entity =>
            {
                entity.HasKey(e => new { e.PromotionId, e.SauceId })
                    .HasName("SaucePromotion_pk");

                entity.HasOne(d => d.Promotion)
                    .WithMany(p => p.SaucePromotion)
                    .HasForeignKey(d => d.PromotionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SaucePromotion_Promotion");

                entity.HasOne(d => d.Sauce)
                    .WithMany(p => p.SaucePromotion)
                    .HasForeignKey(d => d.SauceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SaucePromotion_Sauce");
            });
        }
    }
}
