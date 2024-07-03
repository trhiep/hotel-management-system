using System;
using System.Collections.Generic;
using HotelManagementSystem.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HotelManagementSystem.Utils.DBContext
{
    public partial class HMSContext : DbContext
    {
        public HMSContext()
        {
        }

        public HMSContext(DbContextOptions<HMSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<BillDetail> BillDetails { get; set; } = null!;
        public virtual DbSet<BookingBill> BookingBills { get; set; } = null!;
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
        public virtual DbSet<PromotionItem> PromotionItems { get; set; } = null!;
        public virtual DbSet<PromotionRoom> PromotionRooms { get; set; } = null!;
        public virtual DbSet<PromotionType> PromotionTypes { get; set; } = null!;
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
                optionsBuilder.UseSqlServer("Data Source=localhost\\SQLEXPRESS;Initial Catalog=HMS;User ID=sa;Password=12345678");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Account");

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Fullname).HasMaxLength(255);

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.Username)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Account_Role");
            });

            modelBuilder.Entity<BillDetail>(entity =>
            {
                entity.Property(e => e.BillDetailId).HasColumnName("BillDetailID");

                entity.Property(e => e.BookingId).HasColumnName("BookingID");

                entity.Property(e => e.Note).HasMaxLength(100);

                entity.Property(e => e.Title).HasMaxLength(100);

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.BillDetails)
                    .HasForeignKey(d => d.BookingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("BillDetails_BookingBill");
            });

            modelBuilder.Entity<BookingBill>(entity =>
            {
                entity.HasKey(e => e.BookingId)
                    .HasName("BookingBill_pk");

                entity.ToTable("BookingBill");

                entity.Property(e => e.BookingId)
                    .ValueGeneratedNever()
                    .HasColumnName("BookingID");

                entity.HasOne(d => d.Booking)
                    .WithOne(p => p.BookingBill)
                    .HasForeignKey<BookingBill>(d => d.BookingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("BookingBill_RoomBooking");
            });

            modelBuilder.Entity<BookingStatus>(entity =>
            {
                entity.HasKey(e => e.BookStatusId)
                    .HasName("BookingStatus_pk");

                entity.ToTable("BookingStatus");

                entity.Property(e => e.BookStatusId).HasColumnName("BookStatusID");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.CitizenId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CitizenID");

                entity.Property(e => e.CustomerName).HasMaxLength(100);

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(13)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Facility>(entity =>
            {
                entity.ToTable("Facility");

                entity.Property(e => e.FacilityId).HasColumnName("FacilityID");

                entity.Property(e => e.FacilityName).HasMaxLength(255);
            });

            modelBuilder.Entity<FacilityMaintenanceStatus>(entity =>
            {
                entity.HasKey(e => e.StatusId)
                    .HasName("FacilityMaintenanceStatus_pk");

                entity.ToTable("FacilityMaintenanceStatus");

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.Property(e => e.StatusName).HasMaxLength(100);
            });

            modelBuilder.Entity<FacilityReport>(entity =>
            {
                entity.HasKey(e => e.ReportId)
                    .HasName("FacilityReport_pk");

                entity.ToTable("FacilityReport");

                entity.Property(e => e.ReportId).HasColumnName("ReportID");

                entity.Property(e => e.ReportDate).HasColumnType("datetime");

                entity.Property(e => e.RoomFacilityId).HasColumnName("RoomFacilityID");

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.HasOne(d => d.RoomFacility)
                    .WithMany(p => p.FacilityReports)
                    .HasForeignKey(d => d.RoomFacilityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FacilityReport_RoomFacilities");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.FacilityReports)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FacilityReport_FacilityMaintenanceStatus");
            });

            modelBuilder.Entity<HotelRoom>(entity =>
            {
                entity.HasKey(e => e.RoomId)
                    .HasName("HotelRoom_pk");

                entity.ToTable("HotelRoom");

                entity.Property(e => e.RoomId).HasColumnName("RoomID");

                entity.Property(e => e.RoomNumber)
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MenuBooking>(entity =>
            {
                entity.HasKey(e => e.BookingId)
                    .HasName("MenuBooking_pk");

                entity.ToTable("MenuBooking");

                entity.Property(e => e.BookingId).HasColumnName("BookingID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.IsDone).HasColumnName("isDone");

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

                entity.Property(e => e.CategoryName).HasMaxLength(1);
            });

            modelBuilder.Entity<MenuItem>(entity =>
            {
                entity.HasKey(e => e.ItemId)
                    .HasName("MenuItem_pk");

                entity.ToTable("MenuItem");

                entity.Property(e => e.ItemId).HasColumnName("ItemID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.Description).HasMaxLength(1);

                entity.Property(e => e.IsAvaliable).HasColumnName("isAvaliable");

                entity.Property(e => e.Price).HasColumnType("smallmoney");

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

                entity.Property(e => e.PromotionTypeId).HasColumnName("PromotionTypeID");

                entity.Property(e => e.Title).HasMaxLength(100);

                entity.HasOne(d => d.PromotionType)
                    .WithMany(p => p.Promotions)
                    .HasForeignKey(d => d.PromotionTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Promotion_PromotionType");
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

            modelBuilder.Entity<PromotionItem>(entity =>
            {
                entity.ToTable("PromotionItem");

                entity.Property(e => e.PromotionItemId).HasColumnName("PromotionItemID");

                entity.Property(e => e.ItemId).HasColumnName("ItemID");

                entity.Property(e => e.PromotionId).HasColumnName("PromotionID");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.PromotionItems)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PromotionItem_MenuItem");

                entity.HasOne(d => d.Promotion)
                    .WithMany(p => p.PromotionItems)
                    .HasForeignKey(d => d.PromotionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PromotionItem_Promotion");
            });

            modelBuilder.Entity<PromotionRoom>(entity =>
            {
                entity.ToTable("PromotionRoom");

                entity.Property(e => e.PromotionRoomId).HasColumnName("PromotionRoomID");

                entity.Property(e => e.PromotionId).HasColumnName("PromotionID");

                entity.Property(e => e.RoomId).HasColumnName("RoomID");

                entity.HasOne(d => d.Promotion)
                    .WithMany(p => p.PromotionRooms)
                    .HasForeignKey(d => d.PromotionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PromotionRoom_Promotion");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.PromotionRooms)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PromotionRoom_HotelRoom");
            });

            modelBuilder.Entity<PromotionType>(entity =>
            {
                entity.ToTable("PromotionType");

                entity.Property(e => e.PromotionTypeId).HasColumnName("PromotionTypeID");

                entity.Property(e => e.TypeName).HasMaxLength(25);
            });

            modelBuilder.Entity<RestaurantBooking>(entity =>
            {
                entity.HasKey(e => e.BookingId)
                    .HasName("RestaurantBooking_pk");

                entity.ToTable("RestaurantBooking");

                entity.Property(e => e.BookingId).HasColumnName("BookingID");

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
                entity.HasKey(e => e.BookingId)
                    .HasName("RoomBooking_pk");

                entity.ToTable("RoomBooking");

                entity.Property(e => e.BookingId).HasColumnName("BookingID");

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.BookStatusId).HasColumnName("BookStatusID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.CustomerPhoneNumber)
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.FromDate).HasColumnType("datetime");

                entity.Property(e => e.RoomId).HasColumnName("RoomID");

                entity.Property(e => e.ToDate).HasColumnType("datetime");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.RoomBookings)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RoomBook_Account");

                entity.HasOne(d => d.BookStatus)
                    .WithMany(p => p.RoomBookings)
                    .HasForeignKey(d => d.BookStatusId)
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
