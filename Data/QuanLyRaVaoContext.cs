using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using QuanLyRaVao.Models;

namespace QuanLyRaVao.Data;

public partial class QuanLyRaVaoContext : DbContext
{
    public QuanLyRaVaoContext()
    {
    }

    public QuanLyRaVaoContext(DbContextOptions<QuanLyRaVaoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CanboDuyet> CanboDuyets { get; set; }

    public virtual DbSet<Capbac> Capbacs { get; set; }

    public virtual DbSet<Chitietdanhsach> Chitietdanhsaches { get; set; }

    public virtual DbSet<ChitietdanhsachGiayto> ChitietdanhsachGiaytos { get; set; }

    public virtual DbSet<Chucvu> Chucvus { get; set; }

    public virtual DbSet<Donvi> Donvis { get; set; }

    public virtual DbSet<Giayto> Giaytos { get; set; }

    public virtual DbSet<Nhom> Nhoms { get; set; }

    public virtual DbSet<NhomQuyen> NhomQuyens { get; set; }

    public virtual DbSet<Quannhan> Quannhans { get; set; }

    public virtual DbSet<Quyen> Quyens { get; set; }

    public virtual DbSet<Rangoai> Rangoais { get; set; }

    public virtual DbSet<Taikhoan> Taikhoans { get; set; }

    public virtual DbSet<Vipham> Viphams { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=MSI\\PHUC;Initial Catalog=QuanLyRaVao;Integrated Security=True;Encrypt=false;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CanboDuyet>(entity =>
        {
            entity.HasKey(e => new { e.MaCb, e.MaCtds });

            entity.ToTable("CANBO_DUYET");

            entity.Property(e => e.MaCb).HasColumnName("MaCB");
            entity.Property(e => e.MaCtds).HasColumnName("MaCTDS");
            entity.Property(e => e.GhiChu).HasMaxLength(200);
            entity.Property(e => e.ThoiGianDuyet).HasColumnType("datetime");
            entity.Property(e => e.ThoiGianSua).HasColumnType("datetime");

            entity.HasOne(d => d.MaCbNavigation).WithMany(p => p.CanboDuyets)
                .HasForeignKey(d => d.MaCb)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CANBO_DUYE__MaCB__398D8EEE");

            entity.HasOne(d => d.MaCtdsNavigation).WithMany(p => p.CanboDuyets)
                .HasForeignKey(d => d.MaCtds)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CANBO_DUYET_CHITIETDANHSACH");
        });

        modelBuilder.Entity<Capbac>(entity =>
        {
            entity.HasKey(e => e.MaCapBac).HasName("PK__CAPBAC__2190882555388719");

            entity.ToTable("CAPBAC");

            entity.Property(e => e.CapBac1)
                .HasMaxLength(100)
                .HasColumnName("CapBac");
            entity.Property(e => e.KyHieu)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Chitietdanhsach>(entity =>
        {
            entity.HasKey(e => e.MaCtds);

            entity.ToTable("CHITIETDANHSACH");

            entity.Property(e => e.MaCtds)
                .ValueGeneratedNever()
                .HasColumnName("MaCTDS");
            entity.Property(e => e.DiaDiem).HasMaxLength(100);
            entity.Property(e => e.GhiChu).HasMaxLength(200);
            entity.Property(e => e.HinhThucRn).HasColumnName("HinhThucRN");
            entity.Property(e => e.LyDo).HasMaxLength(100);
            entity.Property(e => e.ThoiGianRa).HasColumnType("datetime");
            entity.Property(e => e.ThoiGianSua).HasColumnType("datetime");
            entity.Property(e => e.ThoiGianVao).HasColumnType("datetime");

            entity.HasOne(d => d.MaHocVienNavigation).WithMany(p => p.Chitietdanhsaches)
                .HasForeignKey(d => d.MaHocVien)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CHITIETDA__MaHoc__3B75D760");
        });

        modelBuilder.Entity<ChitietdanhsachGiayto>(entity =>
        {
            entity.HasKey(e => new { e.MaGiayTo, e.MaCtds });

            entity.ToTable("CHITIETDANHSACH_GIAYTO");

            entity.Property(e => e.MaCtds).HasColumnName("MaCTDS");
            entity.Property(e => e.GhiChu).HasMaxLength(200);
            entity.Property(e => e.ThoiGianLay).HasColumnType("datetime");
            entity.Property(e => e.ThoiGianSua).HasColumnType("datetime");
            entity.Property(e => e.ThoiGianTra).HasColumnType("datetime");

            entity.HasOne(d => d.MaCtdsNavigation).WithMany(p => p.ChitietdanhsachGiaytos)
                .HasForeignKey(d => d.MaCtds)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CHITIETDANHSACH_GIAYTO_CHITIETDANHSACH");

            entity.HasOne(d => d.MaGiayToNavigation).WithMany(p => p.ChitietdanhsachGiaytos)
                .HasForeignKey(d => d.MaGiayTo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CHITIETDA__MaGia__3D5E1FD2");
        });

        modelBuilder.Entity<Chucvu>(entity =>
        {
            entity.HasKey(e => e.MaCv).HasName("PK__CHUCVU__27258E76911495C4");

            entity.ToTable("CHUCVU");

            entity.Property(e => e.MaCv).HasColumnName("MaCV");
            entity.Property(e => e.KyHieu)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.TenCv)
                .HasMaxLength(100)
                .HasColumnName("TenCV");
        });

        modelBuilder.Entity<Donvi>(entity =>
        {
            entity.HasKey(e => e.MaDv).HasName("PK__DONVI__272586574A583AC5");

            entity.ToTable("DONVI");

            entity.Property(e => e.MaDv).HasColumnName("MaDV");
            entity.Property(e => e.TenDv)
                .HasMaxLength(100)
                .HasColumnName("TenDV");
            entity.Property(e => e.ThoiGianSua).HasColumnType("datetime");
        });

        modelBuilder.Entity<Giayto>(entity =>
        {
            entity.HasKey(e => e.MaGiayTo).HasName("PK__GIAYTO__D6796CCAC9630EC7");

            entity.ToTable("GIAYTO");

            entity.Property(e => e.GhiChu).HasMaxLength(200);
            entity.Property(e => e.MaDv).HasColumnName("MaDV");
            entity.Property(e => e.ThoiGianSua).HasColumnType("datetime");

            entity.HasOne(d => d.MaDvNavigation).WithMany(p => p.Giaytos)
                .HasForeignKey(d => d.MaDv)
                .HasConstraintName("FK__GIAYTO__MaDV__403A8C7D");
        });

        modelBuilder.Entity<Nhom>(entity =>
        {
            entity.HasKey(e => e.MaNhom).HasName("PK_NhomQuyen");

            entity.ToTable("NHOM");

            entity.Property(e => e.MaNhom).ValueGeneratedNever();
            entity.Property(e => e.TenNhom).HasMaxLength(200);
        });

        modelBuilder.Entity<NhomQuyen>(entity =>
        {
            entity.HasKey(e => new { e.MaQuyen, e.MaNhom });

            entity.ToTable("NHOM_QUYEN");

            entity.Property(e => e.GhiChu)
                .HasMaxLength(10)
                .IsFixedLength();

            entity.HasOne(d => d.MaNhomNavigation).WithMany(p => p.NhomQuyens)
                .HasForeignKey(d => d.MaNhom)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NHOM_QUYEN_NHOM");

            entity.HasOne(d => d.MaQuyenNavigation).WithMany(p => p.NhomQuyens)
                .HasForeignKey(d => d.MaQuyen)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NHOM_QUYEN_QUYEN");
        });

        modelBuilder.Entity<Quannhan>(entity =>
        {
            entity.HasKey(e => e.MaQn).HasName("PK__QUANNHAN__2725F8505224FF05");

            entity.ToTable("QUANNHAN");

            entity.Property(e => e.MaQn).HasColumnName("MaQN");
            entity.Property(e => e.DiaChi).HasMaxLength(100);
            entity.Property(e => e.HoTen).HasMaxLength(100);
            entity.Property(e => e.MaCv).HasColumnName("MaCV");
            entity.Property(e => e.MaDv).HasColumnName("MaDV");
            entity.Property(e => e.ThoiGianSua).HasColumnType("datetime");

            entity.HasOne(d => d.MaCapBacNavigation).WithMany(p => p.Quannhans)
                .HasForeignKey(d => d.MaCapBac)
                .HasConstraintName("FK__QUANNHAN__MaCapB__412EB0B6");

            entity.HasOne(d => d.MaCvNavigation).WithMany(p => p.Quannhans)
                .HasForeignKey(d => d.MaCv)
                .HasConstraintName("FK__QUANNHAN__MaCV__4222D4EF");

            entity.HasOne(d => d.MaDvNavigation).WithMany(p => p.Quannhans)
                .HasForeignKey(d => d.MaDv)
                .HasConstraintName("FK__QUANNHAN__MaDV__4316F928");
        });

        modelBuilder.Entity<Quyen>(entity =>
        {
            entity.HasKey(e => e.MaQuyen).HasName("PK__QUYEN__1D4B7ED4BB695527");

            entity.ToTable("QUYEN");

            entity.Property(e => e.ActionName).HasMaxLength(200);
            entity.Property(e => e.ControllerName).HasMaxLength(200);
            entity.Property(e => e.Ten).HasMaxLength(200);
        });

        modelBuilder.Entity<Rangoai>(entity =>
        {
            entity.HasKey(e => e.MaRn).HasName("PK__RANGOAI__2725F7B10BFB0930");

            entity.ToTable("RANGOAI");

            entity.Property(e => e.MaRn).HasColumnName("MaRN");
            entity.Property(e => e.GhiChu).HasMaxLength(200);
            entity.Property(e => e.MaCtds).HasColumnName("MaCTDS");
            entity.Property(e => e.MaVp).HasColumnName("MaVP");
            entity.Property(e => e.ThoiGianRa).HasColumnType("datetime");
            entity.Property(e => e.ThoiGianSua).HasColumnType("datetime");
            entity.Property(e => e.ThoiGianVao).HasColumnType("datetime");

            entity.HasOne(d => d.MaCtdsNavigation).WithMany(p => p.Rangoais)
                .HasForeignKey(d => d.MaCtds)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RANGOAI_CHITIETDANHSACH");

            entity.HasOne(d => d.MaGiayToNavigation).WithMany(p => p.Rangoais)
                .HasForeignKey(d => d.MaGiayTo)
                .HasConstraintName("FK__RANGOAI__MaGiayT__44FF419A");

            entity.HasOne(d => d.MaVpNavigation).WithMany(p => p.Rangoais)
                .HasForeignKey(d => d.MaVp)
                .HasConstraintName("FK__RANGOAI__MaVP__45F365D3");
        });

        modelBuilder.Entity<Taikhoan>(entity =>
        {
            entity.HasKey(e => e.MaTaiKhoan).HasName("PK__TAIKHOAN__AD7C652900ACF0BB");

            entity.ToTable("TAIKHOAN");

            entity.Property(e => e.MaQn).HasColumnName("MaQN");
            entity.Property(e => e.MatKhau)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Tdn)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("TDN");

            entity.HasOne(d => d.MaNhomNavigation).WithMany(p => p.Taikhoans)
                .HasForeignKey(d => d.MaNhom)
                .HasConstraintName("FK_TAIKHOAN_NHOM");

            entity.HasOne(d => d.MaQnNavigation).WithMany(p => p.Taikhoans)
                .HasForeignKey(d => d.MaQn)
                .HasConstraintName("FK__TAIKHOAN__MaQN__46E78A0C");
        });

        modelBuilder.Entity<Vipham>(entity =>
        {
            entity.HasKey(e => e.MaVp).HasName("PK__VIPHAM__2725103A438B065C");

            entity.ToTable("VIPHAM");

            entity.Property(e => e.MaVp).HasColumnName("MaVP");
            entity.Property(e => e.GhiChu).HasMaxLength(200);
            entity.Property(e => e.MaHv).HasColumnName("MaHV");
            entity.Property(e => e.MoTa).HasMaxLength(200);
            entity.Property(e => e.ThoiGian).HasColumnType("date");
            entity.Property(e => e.ThoiGianSua).HasColumnType("datetime");

            entity.HasOne(d => d.MaHvNavigation).WithMany(p => p.Viphams)
                .HasForeignKey(d => d.MaHv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__VIPHAM__MaHV__49C3F6B7");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
