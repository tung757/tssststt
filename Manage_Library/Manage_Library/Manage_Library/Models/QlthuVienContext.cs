using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Manage_Library.Models;

public partial class QlthuVienContext : DbContext
{
    public QlthuVienContext()
    {
    }

    public QlthuVienContext(DbContextOptions<QlthuVienContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Danhsachmuontra> Danhsachmuontras { get; set; }

    public virtual DbSet<Lichsu> Lichsus { get; set; }

    public virtual DbSet<Nguoidung> Nguoidungs { get; set; }

    public virtual DbSet<Sach> Saches { get; set; }

    public virtual DbSet<Taikhoan> Taikhoans { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=Admin-PC\\SQLEXPRESS;Initial Catalog=QLThuVien;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Danhsachmuontra>(entity =>
        {
            entity.HasKey(e => new { e.MaDg, e.MaSach, e.MaPhieu }).HasName("pk");

            entity.ToTable("DANHSACHMUONTRA");

            entity.Property(e => e.MaDg)
                .HasMaxLength(5)
                .HasColumnName("MaDG");
            entity.Property(e => e.MaSach).HasMaxLength(5);
            entity.Property(e => e.MaPhieu).HasMaxLength(5);
            entity.Property(e => e.GhiChu).HasMaxLength(255);
            entity.Property(e => e.NgayMuon).HasColumnType("date");
            entity.Property(e => e.NgayTra).HasColumnType("date");

            entity.HasOne(d => d.MaDgNavigation).WithMany(p => p.Danhsachmuontras)
                .HasForeignKey(d => d.MaDg)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk2");

            entity.HasOne(d => d.MaSachNavigation).WithMany(p => p.Danhsachmuontras)
                .HasForeignKey(d => d.MaSach)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk3");
        });

        modelBuilder.Entity<Lichsu>(entity =>
        {
            entity.HasKey(e => e.MaTh).HasName("PK__LICHSU__272500753A6344F2");

            entity.ToTable("LICHSU");

            entity.Property(e => e.MaTh)
                .HasMaxLength(5)
                .HasColumnName("MaTH");
            entity.Property(e => e.MaDg)
                .HasMaxLength(5)
                .HasColumnName("MaDG");
            entity.Property(e => e.NgayMuon).HasColumnType("date");
            entity.Property(e => e.TenSach).HasMaxLength(20);

            entity.HasOne(d => d.MaDgNavigation).WithMany(p => p.Lichsus)
                .HasForeignKey(d => d.MaDg)
                .HasConstraintName("fk1");
        });

        modelBuilder.Entity<Nguoidung>(entity =>
        {
            entity.HasKey(e => e.MaDg).HasName("PK__NGUOIDUN__2725866051E3E915");

            entity.ToTable("NGUOIDUNG");

            entity.Property(e => e.MaDg)
                .HasMaxLength(5)
                .HasColumnName("MaDG");
            entity.Property(e => e.DiaChi).HasMaxLength(20);
            entity.Property(e => e.Email).HasMaxLength(20);
            entity.Property(e => e.GioiTinh).HasMaxLength(5);
            entity.Property(e => e.NgaySinh).HasColumnType("date");
            entity.Property(e => e.Passw).HasMaxLength(10);
            entity.Property(e => e.SoDienThoai).HasMaxLength(10);
            entity.Property(e => e.TenNguoiDung).HasMaxLength(45);
            entity.Property(e => e.Username).HasMaxLength(10);
            entity.Property(e => e.VaiTro).HasMaxLength(15);
        });

        modelBuilder.Entity<Sach>(entity =>
        {
            entity.HasKey(e => e.MaSach).HasName("PK__SACH__B235742D8959ABD2");

            entity.ToTable("SACH");

            entity.Property(e => e.MaSach).HasMaxLength(5);
            entity.Property(e => e.AnhBia).HasMaxLength(15);
            entity.Property(e => e.NgonNgu).HasMaxLength(15);
            entity.Property(e => e.NhaXuatBan).HasMaxLength(20);
            entity.Property(e => e.TacGia).HasMaxLength(20);
            entity.Property(e => e.TenSach).HasMaxLength(20);
            entity.Property(e => e.TheLoai).HasMaxLength(20);
        });

        modelBuilder.Entity<Taikhoan>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TAIKHOAN__3214EC27F3C3868B");

            entity.ToTable("TAIKHOAN");

            entity.Property(e => e.Id)
                .HasMaxLength(10)
                .HasColumnName("ID");
            entity.Property(e => e.MatKhau).HasMaxLength(10);
            entity.Property(e => e.TaiKhoan1)
                .HasMaxLength(10)
                .HasColumnName("TaiKhoan");
            entity.Property(e => e.TenNhanVien).HasMaxLength(10);
            entity.Property(e => e.ThoiGianBatDau).HasMaxLength(10);
            entity.Property(e => e.ThoiGianKetThuc).HasMaxLength(10);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
