using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Car_Insurance.Co.Models;

namespace Car_Insurance.Co.Data
{
    public partial class car_insuranceContext : DbContext
    {
        public car_insuranceContext()
        {
        }

        public car_insuranceContext(DbContextOptions<car_insuranceContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AdminDetail> AdminDetails { get; set; } = null!;
        public virtual DbSet<CeoDetail> CeoDetails { get; set; } = null!;
        public virtual DbSet<ClaimInsurance> ClaimInsurances { get; set; } = null!;
        public virtual DbSet<ClaimStatus> ClaimStatuses { get; set; } = null!;
        public virtual DbSet<Feedback> Feedbacks { get; set; } = null!;
        public virtual DbSet<InsurancePolicy> InsurancePolicies { get; set; } = null!;
        public virtual DbSet<OrderDetail> OrderDetails { get; set; } = null!;
        public virtual DbSet<OrderStatus> OrderStatuses { get; set; } = null!;
        public virtual DbSet<PlansDetail> PlansDetails { get; set; } = null!;
        public virtual DbSet<UserCarsDetail> UserCarsDetails { get; set; } = null!;
        public virtual DbSet<UserDetail> UserDetails { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdminDetail>(entity =>
            {
                entity.ToTable("admin_detail");

                entity.HasIndex(e => e.AdminEmail, "UQ_adminemail")
                    .IsUnique();

                entity.HasIndex(e => e.AdminName, "UQ_adminname")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AdminEmail)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("admin_email");

                entity.Property(e => e.AdminName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("admin_name");

                entity.Property(e => e.AdminPassword)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("admin_password");

                entity.Property(e => e.RegisterDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<CeoDetail>(entity =>
            {
                entity.ToTable("ceo_detail");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CeoEmail)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ceo_email");

                entity.Property(e => e.CeoName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ceo_name");

                entity.Property(e => e.CeoPassword)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ceo_password");
            });

            modelBuilder.Entity<ClaimInsurance>(entity =>
            {
                entity.ToTable("claim_insurance");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ClaimStatus).HasColumnName("claim_status");

                entity.Property(e => e.Insurancemonths).HasColumnName("insurancemonths");

                entity.Property(e => e.Planname)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("planname");

                entity.Property(e => e.Username)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.HasOne(d => d.ClaimStatusNavigation)
                    .WithMany(p => p.ClaimInsurances)
                    .HasForeignKey(d => d.ClaimStatus)
                    .HasConstraintName("FK__claim_ins__claim__38996AB5");
            });

            modelBuilder.Entity<ClaimStatus>(entity =>
            {
                entity.HasKey(e => e.ClaimId);

                entity.ToTable("claim_status");

                entity.Property(e => e.ClaimId).HasColumnName("claim_id");

                entity.Property(e => e.StatusName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("status_name");
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.HasKey(e => e.MessageId);

                entity.ToTable("Feedback");

                entity.Property(e => e.Email)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Message).IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Subject)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<InsurancePolicy>(entity =>
            {
                entity.ToTable("Insurance_Policy");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.EndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("end_date");

                entity.Property(e => e.StartDate)
                    .HasColumnType("datetime")
                    .HasColumnName("start_date");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.ToTable("order_detail");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CarId).HasColumnName("car_id");

                entity.Property(e => e.ClaimId).HasColumnName("claim_id");

                entity.Property(e => e.PlaneId).HasColumnName("plane_id");

                entity.Property(e => e.StatusId).HasColumnName("status_id");

                entity.HasOne(d => d.Car)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.CarId)
                    .HasConstraintName("FK__order_det__car_i__398D8EEE");

                entity.HasOne(d => d.Claim)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.ClaimId)
                    .HasConstraintName("FK__order_det__claim__3C69FB99");

                entity.HasOne(d => d.Plane)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.PlaneId)
                    .HasConstraintName("FK__order_det__plane__3A81B327");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("FK__order_det__statu__3B75D760");
            });

            modelBuilder.Entity<OrderStatus>(entity =>
            {
                entity.HasKey(e => e.StatusId);

                entity.ToTable("Order_Status");

                entity.Property(e => e.StatusId).HasColumnName("status_id");

                entity.Property(e => e.StatusName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("status_name");
            });

            modelBuilder.Entity<PlansDetail>(entity =>
            {
                entity.ToTable("plans_detail");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Insurancemonths).HasColumnName("insurancemonths");

                entity.Property(e => e.Planname)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("planname");

                entity.Property(e => e.Price).HasColumnName("price");
            });

            modelBuilder.Entity<UserCarsDetail>(entity =>
            {
                entity.ToTable("user_cars_detail");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Carcolor)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("carcolor");

                entity.Property(e => e.Carmodel).HasColumnName("carmodel");

                entity.Property(e => e.Carname)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("carname");

                entity.Property(e => e.Carnumber)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("carnumber");

                entity.Property(e => e.Carrcc).HasColumnName("carrcc");

                entity.Property(e => e.Chasisnumber)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("chasisnumber");

                entity.Property(e => e.City)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Enginenumber)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("enginenumber");

                entity.Property(e => e.PolicyId).HasColumnName("Policy_id");

                entity.Property(e => e.Purpose)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("purpose");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.HasOne(d => d.Policy)
                    .WithMany(p => p.UserCarsDetails)
                    .HasForeignKey(d => d.PolicyId)
                    .HasConstraintName("FK_Policy_insurance");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserCarsDetails)
                    .HasForeignKey(d => d.Userid)
                    .HasConstraintName("FK__user_cars__useri__3D5E1FD2");
            });

            modelBuilder.Entity<UserDetail>(entity =>
            {
                entity.ToTable("user_detail");

                entity.HasIndex(e => e.Useremail, "UQ_useremail")
                    .IsUnique();

                entity.HasIndex(e => e.Username, "UQ_username")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Usercontact).HasColumnName("usercontact");

                entity.Property(e => e.Useremail)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("useremail");

                entity.Property(e => e.Username)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.Property(e => e.Userpassword)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("userpassword");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
