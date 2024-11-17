using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GOATBOOKING.Models;

public partial class MasterContext : DbContext
{
    public MasterContext()
    {
    }

    public MasterContext(DbContextOptions<MasterContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<Homestay> Homestays { get; set; }

    public virtual DbSet<Photo> Photos { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<ServicesAdvantage> ServicesAdvantages { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=MSI\\SQLEXPRESS;Initial Catalog=GOATBOOKING;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.BookingId).HasName("pk_Bookings");

            entity.Property(e => e.BookingId)
                .ValueGeneratedNever()
                .HasColumnName("booking_id");
            entity.Property(e => e.CheckInDate).HasColumnName("check_in_date");
            entity.Property(e => e.CheckOutDate).HasColumnName("check_out_date");
            entity.Property(e => e.CreatedAt).HasColumnName("created_at");
            entity.Property(e => e.DepositPrice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("deposit_price");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.TotalPrice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("total_price");
            entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("fk_Users");
        });

        modelBuilder.Entity<Homestay>(entity =>
        {
            entity.HasKey(e => e.HomestayId).HasName("pk_Homestays");

            entity.Property(e => e.HomestayId)
                .ValueGeneratedNever()
                .HasColumnName("homestay_id");
            entity.Property(e => e.CreatedAt).HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.District).HasColumnName("district");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Province).HasColumnName("province");
            entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Ward).HasColumnName("ward");

            entity.HasOne(d => d.User).WithMany(p => p.Homestays)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("fk_Users_Homestays");
        });

        modelBuilder.Entity<Photo>(entity =>
        {
            entity.HasKey(e => e.PhotoId).HasName("pk_Photos");

            entity.Property(e => e.PhotoId)
                .ValueGeneratedNever()
                .HasColumnName("photo_id");
            entity.Property(e => e.CreatedAt).HasColumnName("created_at");
            entity.Property(e => e.HomestayId).HasColumnName("homestay_id");
            entity.Property(e => e.NamePhoto)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name_photo");
            entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

            entity.HasOne(d => d.Homestay).WithMany(p => p.Photos)
                .HasForeignKey(d => d.HomestayId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Photos_Homestays");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.ReviewId).HasName("pk_Reviews");

            entity.Property(e => e.ReviewId)
                .ValueGeneratedNever()
                .HasColumnName("review_id");
            entity.Property(e => e.Comment)
                .HasColumnType("text")
                .HasColumnName("comment");
            entity.Property(e => e.CreatedAt).HasColumnName("created_at");
            entity.Property(e => e.HomestayId).HasColumnName("homestay_id");
            entity.Property(e => e.Rate).HasColumnName("rate");
            entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            // Ánh xạ rõ ràng quan hệ khóa ngoại
            entity.HasOne(d => d.Homestay)
                .WithMany(p => p.Reviews)
                .HasForeignKey(d => d.HomestayId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Reviews_Homestays");

            entity.HasOne(d => d.User)
                .WithMany(p => p.Reviews)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Reviews_Users");
        });


        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.RoomId).HasName("pk_Rooms");

            entity.Property(e => e.RoomId)
                .ValueGeneratedNever()
                .HasColumnName("room_id");
            entity.Property(e => e.BookingId).HasColumnName("booking_id");
            entity.Property(e => e.CreatedAt).HasColumnName("created_at");
            entity.Property(e => e.HomestayId).HasColumnName("homestay_id");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)").HasColumnName("price");
            entity.Property(e => e.RoomName).HasMaxLength(255).IsUnicode(false).HasColumnName("room_name");
            entity.Property(e => e.RoomType).HasColumnName("room_type");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

            entity.HasOne(d => d.Booking).WithMany(p => p.Rooms)
                .HasForeignKey(d => d.BookingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Rooms_Bookings");

            entity.HasOne(d => d.Homestay).WithMany(p => p.Rooms)
                .HasForeignKey(d => d.HomestayId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Rooms_Homestays");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.ServiceId).HasName("pk_Services");

            entity.Property(e => e.ServiceId)
                .ValueGeneratedNever()
                .HasColumnName("service_id");
            entity.Property(e => e.CreatedAt).HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
            entity.Property(e => e.ServiceName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("service_name");
            entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
        });

        modelBuilder.Entity<ServicesAdvantage>(entity =>
        {
            entity.HasKey(e => new { e.HomestayId, e.ServiceId }).HasName("pk_Services_advantage");

            entity.ToTable("Services_advantage");

            entity.Property(e => e.HomestayId).HasColumnName("homestay_id");
            entity.Property(e => e.ServiceId).HasColumnName("service_id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("description");

            entity.HasOne(d => d.Homestay).WithMany(p => p.ServicesAdvantages)
                .HasForeignKey(d => d.HomestayId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Services_advantage_Homestays");

            entity.HasOne(d => d.Service).WithMany(p => p.ServicesAdvantages)
                .HasForeignKey(d => d.ServiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Services_advantage_Services");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("pk_Users");

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("user_id");
            entity.Property(e => e.Avatar)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("avatar");
            entity.Property(e => e.CreatedAt).HasColumnName("created_at");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FullName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("full_name");
            entity.Property(e => e.Gender).HasColumnName("gender");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("phone_number");
            entity.Property(e => e.Role).HasColumnName("role");
            entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            entity.Property(e => e.UserName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("user_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
