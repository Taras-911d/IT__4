using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Task_3_Core
{
    public partial class DzhusInternetShopDBContext : DbContext
    {
        public DzhusInternetShopDBContext()
        {
        }

        public DzhusInternetShopDBContext(DbContextOptions<DzhusInternetShopDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<Medicaments> Medicaments { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public object Users { get; internal set; }

        // Unable to generate entity type for table 'dbo.EmployeesInfo'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Stocks'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTO-MGBS7T6\\SQLEXPRESS; Database=DzhusInternetShopDB; Trusted_Connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.City).HasMaxLength(20);

                entity.Property(e => e.DateInSystem)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Fname)
                    .HasColumnName("FName")
                    .HasMaxLength(20);

                entity.Property(e => e.Lname)
                    .HasColumnName("LName")
                    .HasMaxLength(20);

                entity.Property(e => e.Mname)
                    .HasColumnName("MName")
                    .HasMaxLength(20);

                entity.Property(e => e.Phone)
                    .HasMaxLength(12)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Employees>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Fname)
                    .IsRequired()
                    .HasColumnName("FName")
                    .HasMaxLength(20);

                entity.Property(e => e.Lname)
                    .IsRequired()
                    .HasColumnName("LName")
                    .HasMaxLength(20);

                entity.Property(e => e.Mname)
                    .HasColumnName("MName")
                    .HasMaxLength(20);

                entity.Property(e => e.Post)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.PriorSalary).HasColumnType("money");

                entity.Property(e => e.Salary).HasColumnType("money");
            });

            modelBuilder.Entity<Medicaments>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<OrderDetails>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.LineItem });

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.MedicamentId).HasColumnName("MedicamentID");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.TotalPrice)
                    .HasColumnType("money")
                    .HasComputedColumnSql("(CONVERT([money],[Qty]*[Price]))");

                entity.HasOne(d => d.Medicament)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.MedicamentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_OrderDetails_Products");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_OrderDetails_Orders");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_Orders_Customers");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_Orders_Employees");
            });
        }
    }
}
