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

    public virtual DbSet<Danhsach> Danhsaches { get; set; }

    public virtual DbSet<Donvi> Donvis { get; set; }

    public virtual DbSet<Giayto> Giaytos { get; set; }

    public virtual DbSet<Quannhan> Quannhans { get; set; }

    public virtual DbSet<Quyen> Quyens { get; set; }

    public virtual DbSet<Rangoai> Rangoais { get; set; }

    public virtual DbSet<Taikhoan> Taikhoans { get; set; }

    public virtual DbSet<TaikhoanQuyen> TaikhoanQuyens { get; set; }

    public virtual DbSet<Vipham> Viphams { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=Quan\\hq;Initial Catalog=QuanLyRaVao;Integrated Security=True;Encrypt=false;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CanboDuyet>(entity =>
        {
            entity.HasKey(e => new { e.MaCb, e.MaDs }).HasName("PK__CANBO_DU__7557D67FAEF68FF7");

            entity.ToTable("CANBO_DUYET");

            entity.Property(e => e.MaCb).HasColumnName("MaCB");
            entity.Property(e => e.MaDs).HasColumnName("MaDS");
            entity.Property(e => e.GhiChu).HasMaxLength(200);
            entity.Property(e => e.ThoiGianDuyet).HasColumnType("datetime");

            entity.HasOne(d => d.MaCbNavigation).WithMany(p => p.CanboDuyets)
                .HasForeignKey(d => d.MaCb)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CANBO_DUYE__MaCB__36B12243");

            entity.HasOne(d => d.MaDsNavigation).WithMany(p => p.CanboDuyets)
                .HasForeignKey(d => d.MaDs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CANBO_DUYE__MaDS__37A5467C");
        });

        modelBuilder.Entity<Capbac>(entity =>
        {
            entity.HasKey(e => e.MaCapBac).HasName("PK__CAPBAC__21908825B43113F2");

            entity.ToTable("CAPBAC");

            entity.Property(e => e.MaCapBac)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.CapBac1)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CapBac");
            entity.Property(e => e.KyHieu)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Chitietdanhsach>(entity =>
        {
            entity.HasKey(e => new { e.MaDs, e.MaHocVien }).HasName("PK__CHITIETD__91A036B2B90F1799");

            entity.ToTable("CHITIETDANHSACH");

            entity.Property(e => e.MaDs).HasColumnName("MaDS");
            entity.Property(e => e.DiaDiem).HasMaxLength(100);
            entity.Property(e => e.GhiChu).HasMaxLength(200);
            entity.Property(e => e.LyDo).HasMaxLength(100);
            entity.Property(e => e.ThoiGianSua).HasColumnType("datetime");

            entity.HasOne(d => d.MaDsNavigation).WithMany(p => p.Chitietdanhsaches)
                .HasForeignKey(d => d.MaDs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CHITIETDAN__MaDS__32E0915F");

            entity.HasOne(d => d.MaHocVienNavigation).WithMany(p => p.Chitietdanhsaches)
                .HasForeignKey(d => d.MaHocVien)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CHITIETDA__MaHoc__33D4B598");
        });

        modelBuilder.Entity<ChitietdanhsachGiayto>(entity =>
        {
            entity.HasKey(e => new { e.MaGiayTo, e.MaDs, e.MaHocVien }).HasName("PK__CHITIETD__EF636FA1A5F04FB4");

            entity.ToTable("CHITIETDANHSACH_GIAYTO");

            entity.Property(e => e.MaDs).HasColumnName("MaDS");
            entity.Property(e => e.GhiChu).HasMaxLength(200);
            entity.Property(e => e.ThoiGianLay).HasColumnType("datetime");
            entity.Property(e => e.ThoiGianSua).HasColumnType("datetime");
            entity.Property(e => e.ThoiGianTra).HasColumnType("datetime");

            entity.HasOne(d => d.MaDsNavigation).WithMany(p => p.ChitietdanhsachGiaytos)
                .HasForeignKey(d => d.MaDs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CHITIETDAN__MaDS__3E52440B");

            entity.HasOne(d => d.MaGiayToNavigation).WithMany(p => p.ChitietdanhsachGiaytos)
                .HasForeignKey(d => d.MaGiayTo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CHITIETDA__MaGia__3D5E1FD2");

            entity.HasOne(d => d.MaHocVienNavigation).WithMany(p => p.ChitietdanhsachGiaytos)
                .HasForeignKey(d => d.MaHocVien)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CHITIETDA__MaHoc__3F466844");
        });

        modelBuilder.Entity<Chucvu>(entity =>
        {
            entity.HasKey(e => e.MaCv).HasName("PK__CHUCVU__27258E766A385FE1");

            entity.ToTable("CHUCVU");

            entity.Property(e => e.MaCv)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MaCV");
            entity.Property(e => e.KyHieu)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.TenCv)
                .HasMaxLength(100)
                .HasColumnName("TenCV");
        });

        modelBuilder.Entity<Danhsach>(entity =>
        {
            entity.HasKey(e => e.MaDs).HasName("PK__DANHSACH__272586540C2EABB3");

            entity.ToTable("DANHSACH");

            entity.Property(e => e.MaDs)
                .ValueGeneratedNever()
                .HasColumnName("MaDS");
            entity.Property(e => e.GhiChu).HasMaxLength(200);
            entity.Property(e => e.HinhThucRn).HasColumnName("HinhThucRN");
            entity.Property(e => e.ThoiGianSua).HasColumnType("datetime");
        });

        modelBuilder.Entity<Donvi>(entity =>
        {
            entity.HasKey(e => e.MaDv).HasName("PK__DONVI__272586576C8D025A");

            entity.ToTable("DONVI");

            entity.Property(e => e.MaDv)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MaDV");
            entity.Property(e => e.TenDv)
                .HasMaxLength(100)
                .HasColumnName("TenDV");
            entity.Property(e => e.ThoiGianSua).HasColumnType("datetime");
        });

        modelBuilder.Entity<Giayto>(entity =>
        {
            entity.HasKey(e => e.MaGiayTo).HasName("PK__GIAYTO__D6796CCACAD5E0A3");

            entity.ToTable("GIAYTO");

            entity.Property(e => e.MaGiayTo).ValueGeneratedNever();
            entity.Property(e => e.GhiChu).HasMaxLength(200);
            entity.Property(e => e.MaDv)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MaDV");
            entity.Property(e => e.ThoiGianSua).HasColumnType("datetime");

            entity.HasOne(d => d.MaDvNavigation).WithMany(p => p.Giaytos)
                .HasForeignKey(d => d.MaDv)
                .HasConstraintName("FK__GIAYTO__MaDV__3A81B327");
        });

        modelBuilder.Entity<Quannhan>(entity =>
        {
            entity.HasKey(e => e.MaQn).HasName("PK__QUANNHAN__2725F850185658DF");

            entity.ToTable("QUANNHAN");

            entity.Property(e => e.MaQn)
                .ValueGeneratedNever()
                .HasColumnName("MaQN");
            entity.Property(e => e.HoTen).HasMaxLength(100);
            entity.Property(e => e.MaCapBac)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.MaCv)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MaCV");
            entity.Property(e => e.MaDv)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MaDV");
            entity.Property(e => e.ThoiGianSua).HasColumnType("datetime");

            entity.HasOne(d => d.MaCapBacNavigation).WithMany(p => p.Quannhans)
                .HasForeignKey(d => d.MaCapBac)
                .HasConstraintName("FK__QUANNHAN__MaCapB__2E1BDC42");

            entity.HasOne(d => d.MaCvNavigation).WithMany(p => p.Quannhans)
                .HasForeignKey(d => d.MaCv)
                .HasConstraintName("FK__QUANNHAN__MaCV__2C3393D0");

            entity.HasOne(d => d.MaDvNavigation).WithMany(p => p.Quannhans)
                .HasForeignKey(d => d.MaDv)
                .HasConstraintName("FK__QUANNHAN__MaDV__2D27B809");
        });

        modelBuilder.Entity<Quyen>(entity =>
        {
            entity.HasKey(e => e.MaQuyen).HasName("PK__QUYEN__1D4B7ED45602C09F");

            entity.ToTable("QUYEN");

            entity.Property(e => e.MaQuyen).ValueGeneratedNever();
            entity.Property(e => e.GhiChu).HasMaxLength(200);
            entity.Property(e => e.Ten)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Rangoai>(entity =>
        {
            entity.HasKey(e => e.MaRn).HasName("PK__RANGOAI__2725F7B12A178618");

            entity.ToTable("RANGOAI");

            entity.Property(e => e.MaRn)
                .ValueGeneratedNever()
                .HasColumnName("MaRN");
            entity.Property(e => e.GhiChu).HasMaxLength(200);
            entity.Property(e => e.MaDs).HasColumnName("MaDS");
            entity.Property(e => e.MaVp).HasColumnName("MaVP");
            entity.Property(e => e.ThoiGianRa).HasColumnType("datetime");
            entity.Property(e => e.ThoiGianSua).HasColumnType("datetime");
            entity.Property(e => e.ThoiGianVao).HasColumnType("datetime");

            entity.HasOne(d => d.MaDsNavigation).WithMany(p => p.Rangoais)
                .HasForeignKey(d => d.MaDs)
                .HasConstraintName("FK__RANGOAI__MaDS__46E78A0C");

            entity.HasOne(d => d.MaGiayToNavigation).WithMany(p => p.Rangoais)
                .HasForeignKey(d => d.MaGiayTo)
                .HasConstraintName("FK__RANGOAI__MaGiayT__45F365D3");

            entity.HasOne(d => d.MaVpNavigation).WithMany(p => p.Rangoais)
                .HasForeignKey(d => d.MaVp)
                .HasConstraintName("FK__RANGOAI__MaVP__44FF419A");
        });

        modelBuilder.Entity<Taikhoan>(entity =>
        {
            entity.HasKey(e => e.MaTaiKhoan).HasName("PK__TAIKHOAN__AD7C6529DA4587F1");

            entity.ToTable("TAIKHOAN");

            entity.Property(e => e.MaTaiKhoan).ValueGeneratedNever();
            entity.Property(e => e.MaQn).HasColumnName("MaQN");
            entity.Property(e => e.MatKhau)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Tdn)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("TDN");

            entity.HasOne(d => d.MaQnNavigation).WithMany(p => p.Taikhoans)
                .HasForeignKey(d => d.MaQn)
                .HasConstraintName("FK__TAIKHOAN__MaQN__49C3F6B7");
        });

        modelBuilder.Entity<TaikhoanQuyen>(entity =>
        {
            entity.HasKey(e => new { e.MaTaiKhoan, e.MaQuyen }).HasName("PK__TAIKHOAN__FCA8D2C4B2A3F56C");

            entity.ToTable("TAIKHOAN_QUYEN");

            entity.Property(e => e.ThoiGianSua).HasColumnType("datetime");

            entity.HasOne(d => d.MaQuyenNavigation).WithMany(p => p.TaikhoanQuyens)
                .HasForeignKey(d => d.MaQuyen)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TAIKHOAN___MaQuy__4D94879B");

            entity.HasOne(d => d.MaTaiKhoanNavigation).WithMany(p => p.TaikhoanQuyens)
                .HasForeignKey(d => d.MaTaiKhoan)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TAIKHOAN___MaTai__4CA06362");
        });

        modelBuilder.Entity<Vipham>(entity =>
        {
            entity.HasKey(e => e.MaVp).HasName("PK__VIPHAM__2725103A9CBC2BF1");

            entity.ToTable("VIPHAM");

            entity.Property(e => e.MaVp)
                .ValueGeneratedNever()
                .HasColumnName("MaVP");
            entity.Property(e => e.GhiChu).HasMaxLength(200);
            entity.Property(e => e.MaHv).HasColumnName("MaHV");
            entity.Property(e => e.MoTa).HasMaxLength(200);
            entity.Property(e => e.ThoiGian).HasColumnType("date");
            entity.Property(e => e.ThoiGianSua).HasColumnType("datetime");

            entity.HasOne(d => d.MaHvNavigation).WithMany(p => p.Viphams)
                .HasForeignKey(d => d.MaHv)
                .HasConstraintName("FK__VIPHAM__MaHV__4222D4EF");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
