using System;
using System.Collections.Generic;
using HotelManagementSystem.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HotelManagementSystem.Utils.DBContext
{
    public partial class HMS_DBContext : DbContext
    {
        public HMS_DBContext()
        {
        }

        public HMS_DBContext(DbContextOptions<HMS_DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<Bill> Bills { get; set; } = null!;
        public virtual DbSet<BillDetail> BillDetails { get; set; } = null!;
        public virtual DbSet<BookingStatus> BookingStatuses { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Facility> Facilities { get; set; } = null!;
        public virtual DbSet<FacilityMaintenanceStatus> FacilityMaintenanceStatuses { get; set; } = null!;
        public virtual DbSet<FacilityReport> FacilityReports { get; set; } = null!;
        public virtual DbSet<HotelRoom> HotelRooms { get; set; } = null!;
        public virtual DbSet<MenuBooking> MenuBookings { get; set; } = null!;
        public virtual DbSet<MenuCategory> MenuCategories { get; set; } = null!;
        public virtual DbSet<MenuItem> MenuItems { get; set; } = null!;
        public virtual DbSet<Promotion> Promotions { get; set; } = null!;
        public virtual DbSet<PromotionCustomer> PromotionCustomers { get; set; } = null!;
        public virtual DbSet<PromotionHotelRoom> PromotionHotelRooms { get; set; } = null!;
        public virtual DbSet<PromotionStatus> PromotionStatuses { get; set; } = null!;
        public virtual DbSet<PromotionTarget> PromotionTargets { get; set; } = null!;
        public virtual DbSet<PromotionType> PromotionTypes { get; set; } = null!;
        public virtual DbSet<ResetPasswordOtp> ResetPasswordOtps { get; set; } = null!;
        public virtual DbSet<RestaurantBooking> RestaurantBookings { get; set; } = null!;
        public virtual DbSet<RestaurantTable> RestaurantTables { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<RoomBooking> RoomBookings { get; set; } = null!;
        public virtual DbSet<RoomFacility> RoomFacilities { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=localhost\\SQLEXPRESS;Initial Catalog=HMS_DB;User ID=sa;Password=12345678");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Account");

                entity.HasIndex(e => e.Email, "UNQ_Account_Email")
                    .IsUnique();

                entity.HasIndex(e => e.Username, "UNQ_Account_Username")
                    .IsUnique();

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Fullname)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Account_Role");
            });

            modelBuilder.Entity<Bill>(entity =>
            {
                entity.ToTable("Bill");

                entity.Property(e => e.BillId).HasColumnName("BillID");

                entity.Property(e => e.RoomBookingId).HasColumnName("RoomBookingID");

                entity.HasOne(d => d.RoomBooking)
                    .WithMany(p => p.Bills)
                    .HasForeignKey(d => d.RoomBookingId)
                    .HasConstraintName("Bill_RoomBooking");
            });

            modelBuilder.Entity<BillDetail>(entity =>
            {
                entity.HasKey(e => e.BillDetailsId)
                    .HasName("BillDetails_pk");

                entity.Property(e => e.BillDetailsId).HasColumnName("BillDetailsID");

                entity.Property(e => e.BillId).HasColumnName("BillID");

                entity.Property(e => e.Note)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Bill)
                    .WithMany(p => p.BillDetails)
                    .HasForeignKey(d => d.BillId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("BillDetails_Bill");
            });

            modelBuilder.Entity<BookingStatus>(entity =>
            {
                entity.ToTable("BookingStatus");

                entity.HasIndex(e => e.BookingStatusName, "UNQ_BookingStatus_Name")
                    .IsUnique();

                entity.Property(e => e.BookingStatusId).HasColumnName("BookingStatusID");

                entity.Property(e => e.BookingStatusName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.HasIndex(e => e.CitizenId, "UNQ_Customer_CitizenID")
                    .IsUnique();

                entity.HasIndex(e => e.Email, "UNQ_Customer_Email")
                    .IsUnique();

                entity.HasIndex(e => e.PhoneNumber, "UNQ_Customer_Phone")
                    .IsUnique();

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.CitizenId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CitizenID");

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Facility>(entity =>
            {
                entity.ToTable("Facility");

                entity.Property(e => e.FacilityId).HasColumnName("FacilityID");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FacilityName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FacilityMaintenanceStatus>(entity =>
            {
                entity.HasKey(e => e.MaintenanceStatusId)
                    .HasName("FacilityMaintenanceStatus_pk");

                entity.ToTable("FacilityMaintenanceStatus");

                entity.Property(e => e.MaintenanceStatusId).HasColumnName("MaintenanceStatusID");

                entity.Property(e => e.StatusName)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FacilityReport>(entity =>
            {
                entity.HasKey(e => e.ReportId)
                    .HasName("FacilityReport_pk");

                entity.ToTable("FacilityReport");

                entity.Property(e => e.ReportId).HasColumnName("ReportID");

                entity.Property(e => e.ImageLink).IsUnicode(false);

                entity.Property(e => e.MaintenanceStatusId).HasColumnName("MaintenanceStatusID");

                entity.Property(e => e.ReportDate).HasColumnType("datetime");

                entity.Property(e => e.RoomFacilityId).HasColumnName("RoomFacilityID");

                entity.HasOne(d => d.MaintenanceStatus)
                    .WithMany(p => p.FacilityReports)
                    .HasForeignKey(d => d.MaintenanceStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FacilityReport_FacilityMaintenanceStatus");

                entity.HasOne(d => d.RoomFacility)
                    .WithMany(p => p.FacilityReports)
                    .HasForeignKey(d => d.RoomFacilityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FacilityReport_RoomFacilities");
            });

            modelBuilder.Entity<HotelRoom>(entity =>
            {
                entity.HasKey(e => e.RoomId)
                    .HasName("HotelRoom_pk");

                entity.ToTable("HotelRoom");

                entity.HasIndex(e => e.RoomNumber, "UNQ_HotelRoom_Number")
                    .IsUnique();

                entity.Property(e => e.RoomId).HasColumnName("RoomID");

                entity.Property(e => e.RoomNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MenuBooking>(entity =>
            {
                entity.HasKey(e => e.BookingId)
                    .HasName("MenuBooking_pk");

                entity.ToTable("MenuBooking");

                entity.Property(e => e.BookingId).HasColumnName("BookingID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.ItemId).HasColumnName("ItemID");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.MenuBookings)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("MenuBooking_Customer");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.MenuBookings)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("MenuBooking_MenuItem");
            });

            modelBuilder.Entity<MenuCategory>(entity =>
            {
                entity.HasKey(e => e.CategoryId)
                    .HasName("MenuCategory_pk");

                entity.ToTable("MenuCategory");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MenuItem>(entity =>
            {
                entity.HasKey(e => e.ItemId)
                    .HasName("MenuItem_pk");

                entity.ToTable("MenuItem");

                entity.Property(e => e.ItemId).HasColumnName("ItemID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.Description)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.ItemName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.MenuItems)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CategoryID");
            });

            modelBuilder.Entity<Promotion>(entity =>
            {
                entity.ToTable("Promotion");

                entity.Property(e => e.PromotionId).HasColumnName("PromotionID");

                entity.Property(e => e.PromotionCode)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.PromotionTargetId).HasColumnName("PromotionTargetID");

                entity.Property(e => e.PromotionTypeId).HasColumnName("PromotionTypeID");

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.Promotions)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Promotion_Account");

                entity.HasOne(d => d.PromotionTarget)
                    .WithMany(p => p.Promotions)
                    .HasForeignKey(d => d.PromotionTargetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Promotion_PromotionTarget");

                entity.HasOne(d => d.PromotionType)
                    .WithMany(p => p.Promotions)
                    .HasForeignKey(d => d.PromotionTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Promotion_PromotionType");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Promotions)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Promotion_PromotionStatus");
            });

            modelBuilder.Entity<PromotionCustomer>(entity =>
            {
                entity.ToTable("PromotionCustomer");

                entity.Property(e => e.PromotionCustomerId).HasColumnName("PromotionCustomerID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.PromotionId).HasColumnName("PromotionID");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.PromotionCustomers)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PromotionCustomer_Customer");

                entity.HasOne(d => d.Promotion)
                    .WithMany(p => p.PromotionCustomers)
                    .HasForeignKey(d => d.PromotionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PromotionCustomer_Promotion");
            });

            modelBuilder.Entity<PromotionHotelRoom>(entity =>
            {
                entity.HasKey(e => e.PromotionRoomId)
                    .HasName("PromotionHotelRoom_pk");

                entity.ToTable("PromotionHotelRoom");

                entity.Property(e => e.PromotionRoomId).HasColumnName("PromotionRoomID");

                entity.Property(e => e.PromotionId).HasColumnName("PromotionID");

                entity.Property(e => e.RoomId).HasColumnName("RoomID");

                entity.HasOne(d => d.Promotion)
                    .WithMany(p => p.PromotionHotelRooms)
                    .HasForeignKey(d => d.PromotionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PromotionRoom_Promotion");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.PromotionHotelRooms)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PromotionRoom_HotelRoom");
            });

            modelBuilder.Entity<PromotionStatus>(entity =>
            {
                entity.ToTable("PromotionStatus");

                entity.Property(e => e.PromotionStatusId).HasColumnName("PromotionStatusID");

                entity.Property(e => e.StatusName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PromotionTarget>(entity =>
            {
                entity.ToTable("PromotionTarget");

                entity.Property(e => e.PromotionTargetId).HasColumnName("PromotionTargetID");

                entity.Property(e => e.TargetName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PromotionType>(entity =>
            {
                entity.ToTable("PromotionType");

                entity.Property(e => e.PromotionTypeId).HasColumnName("PromotionTypeID");

                entity.Property(e => e.TypeName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ResetPasswordOtp>(entity =>
            {
                entity.HasKey(e => e.Otpid)
                    .HasName("ResetPasswordOTP_pk");

                entity.ToTable("ResetPasswordOTP");

                entity.Property(e => e.Otpid).HasColumnName("OTPID");

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.GeneratedTime).HasColumnType("datetime");

                entity.Property(e => e.Otpstring)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("OTPString");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.ResetPasswordOtps)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("OTPManager_Account");
            });

            modelBuilder.Entity<RestaurantBooking>(entity =>
            {
                entity.ToTable("RestaurantBooking");

                entity.Property(e => e.RestaurantBookingId).HasColumnName("RestaurantBookingID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.TableId).HasColumnName("TableID");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.RestaurantBookings)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RestaurantBooking_Customer");

                entity.HasOne(d => d.Table)
                    .WithMany(p => p.RestaurantBookings)
                    .HasForeignKey(d => d.TableId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RestaurantBooking_RestaurantTable");
            });

            modelBuilder.Entity<RestaurantTable>(entity =>
            {
                entity.HasKey(e => e.TableId)
                    .HasName("RestaurantTable_pk");

                entity.ToTable("RestaurantTable");

                entity.Property(e => e.TableId)
                    .ValueGeneratedNever()
                    .HasColumnName("TableID");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RoomBooking>(entity =>
            {
                entity.ToTable("RoomBooking");

                entity.Property(e => e.RoomBookingId).HasColumnName("RoomBookingID");

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.BookDate).HasColumnType("datetime");

                entity.Property(e => e.BookingStatusId).HasColumnName("BookingStatusID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.FromDate).HasColumnType("datetime");

                entity.Property(e => e.RoomId).HasColumnName("RoomID");

                entity.Property(e => e.ToDate).HasColumnType("datetime");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.RoomBookings)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RoomBook_Account");

                entity.HasOne(d => d.BookingStatus)
                    .WithMany(p => p.RoomBookings)
                    .HasForeignKey(d => d.BookingStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RoomBooking_BookingStatus");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.RoomBookings)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RoomBook_Customer");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.RoomBookings)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RoomBook_HotelRoom");
            });

            modelBuilder.Entity<RoomFacility>(entity =>
            {
                entity.ToTable("RoomFacility");

                entity.Property(e => e.RoomFacilityId).HasColumnName("RoomFacilityID");

                entity.Property(e => e.FacilityId).HasColumnName("FacilityID");

                entity.Property(e => e.RoomId).HasColumnName("RoomID");

                entity.HasOne(d => d.Facility)
                    .WithMany(p => p.RoomFacilities)
                    .HasForeignKey(d => d.FacilityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RoomFacilities_Facility");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.RoomFacilities)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RoomFacilities_HotelRoom");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
