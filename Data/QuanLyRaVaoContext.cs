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

    public virtual DbSet<Hd> Hds { get; set; }

    public virtual DbSet<NQHd> NQHds { get; set; }

    public virtual DbSet<NhomQuyen> NhomQuyens { get; set; }

    public virtual DbSet<Quannhan> Quannhans { get; set; }

    public virtual DbSet<Quyen> Quyens { get; set; }

    public virtual DbSet<Rangoai> Rangoais { get; set; }

    public virtual DbSet<Taikhoan> Taikhoans { get; set; }

    public virtual DbSet<TkNq> TkNqs { get; set; }

    public virtual DbSet<Vipham> Viphams { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=Quan\\hq;Initial Catalog=QuanLyRaVao;Integrated Security=True;Encrypt=false;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CanboDuyet>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CANBO_DUYET");

            entity.Property(e => e.GhiChu).HasMaxLength(200);
            entity.Property(e => e.MaCb).HasColumnName("MaCB");
            entity.Property(e => e.MaDs).HasColumnName("MaDS");
            entity.Property(e => e.ThoiGianDuyet).HasColumnType("datetime");
            entity.Property(e => e.ThoiGianSua).HasColumnType("datetime");

            entity.HasOne(d => d.MaCbNavigation).WithMany()
                .HasForeignKey(d => d.MaCb)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CANBO_DUYE__MaCB__398D8EEE");

            entity.HasOne(d => d.MaDsNavigation).WithMany()
                .HasForeignKey(d => d.MaDs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CANBO_DUYE__MaDS__3A81B327");
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
            entity
                .HasNoKey()
                .ToTable("CHITIETDANHSACH");

            entity.Property(e => e.DiaDiem).HasMaxLength(100);
            entity.Property(e => e.GhiChu).HasMaxLength(200);
            entity.Property(e => e.LyDo).HasMaxLength(100);
            entity.Property(e => e.MaDs).HasColumnName("MaDS");
            entity.Property(e => e.ThoiGianSua).HasColumnType("datetime");

            entity.HasOne(d => d.MaDsNavigation).WithMany()
                .HasForeignKey(d => d.MaDs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CHITIETDAN__MaDS__3C69FB99");

            entity.HasOne(d => d.MaHocVienNavigation).WithMany()
                .HasForeignKey(d => d.MaHocVien)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CHITIETDA__MaHoc__3B75D760");
        });

        modelBuilder.Entity<ChitietdanhsachGiayto>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CHITIETDANHSACH_GIAYTO");

            entity.Property(e => e.GhiChu).HasMaxLength(200);
            entity.Property(e => e.MaDs).HasColumnName("MaDS");
            entity.Property(e => e.ThoiGianLay).HasColumnType("datetime");
            entity.Property(e => e.ThoiGianSua).HasColumnType("datetime");
            entity.Property(e => e.ThoiGianTra).HasColumnType("datetime");

            entity.HasOne(d => d.MaDsNavigation).WithMany()
                .HasForeignKey(d => d.MaDs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CHITIETDAN__MaDS__3F466844");

            entity.HasOne(d => d.MaGiayToNavigation).WithMany()
                .HasForeignKey(d => d.MaGiayTo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CHITIETDA__MaGia__3D5E1FD2");

            entity.HasOne(d => d.MaHocVienNavigation).WithMany()
                .HasForeignKey(d => d.MaHocVien)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CHITIETDA__MaHoc__3E52440B");
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

        modelBuilder.Entity<Danhsach>(entity =>
        {
            entity.HasKey(e => e.MaDs).HasName("PK__DANHSACH__27258654B1E7AC44");

            entity.ToTable("DANHSACH");

            entity.Property(e => e.MaDs).HasColumnName("MaDS");
            entity.Property(e => e.GhiChu).HasMaxLength(200);
            entity.Property(e => e.HinhThucRn).HasColumnName("HinhThucRN");
            entity.Property(e => e.ThoiGianSua).HasColumnType("datetime");
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

        modelBuilder.Entity<Hd>(entity =>
        {
            entity.HasKey(e => e.MaA);

            entity.ToTable("HD");

            entity.Property(e => e.MaA).ValueGeneratedNever();
            entity.Property(e => e.TenA).HasMaxLength(200);
        });

        modelBuilder.Entity<NQHd>(entity =>
        {
            entity.HasKey(e => new { e.MaA, e.MaQuyen, e.MaNhom });

            entity.ToTable("N_Q_HD");

            entity.Property(e => e.Ten).HasMaxLength(100);

            entity.HasOne(d => d.MaANavigation).WithMany(p => p.NQHds)
                .HasForeignKey(d => d.MaA)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_N_Q_HD_HD");

            entity.HasOne(d => d.MaNhomNavigation).WithMany(p => p.NQHds)
                .HasForeignKey(d => d.MaNhom)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_N_Q_HD_NhomQuyen");

            entity.HasOne(d => d.MaQuyenNavigation).WithMany(p => p.NQHds)
                .HasForeignKey(d => d.MaQuyen)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_N_Q_HD_QUYEN");
        });

        modelBuilder.Entity<NhomQuyen>(entity =>
        {
            entity.HasKey(e => e.MaNhom);

            entity.ToTable("NhomQuyen");

            entity.Property(e => e.MaNhom).ValueGeneratedNever();
            entity.Property(e => e.TenNhom).HasMaxLength(200);
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
            entity.Property(e => e.MaDs).HasColumnName("MaDS");
            entity.Property(e => e.MaVp).HasColumnName("MaVP");
            entity.Property(e => e.ThoiGianRa).HasColumnType("datetime");
            entity.Property(e => e.ThoiGianSua).HasColumnType("datetime");
            entity.Property(e => e.ThoiGianVao).HasColumnType("datetime");

            entity.HasOne(d => d.MaDsNavigation).WithMany(p => p.Rangoais)
                .HasForeignKey(d => d.MaDs)
                .HasConstraintName("FK__RANGOAI__MaDS__440B1D61");

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

            entity.HasOne(d => d.MaQnNavigation).WithMany(p => p.Taikhoans)
                .HasForeignKey(d => d.MaQn)
                .HasConstraintName("FK__TAIKHOAN__MaQN__46E78A0C");
        });

        modelBuilder.Entity<TkNq>(entity =>
        {
            entity.HasKey(e => new { e.MaNhom, e.MaTaiKhoan });

            entity.ToTable("TK_NQ");

            entity.Property(e => e.GhiChu).HasMaxLength(100);

            entity.HasOne(d => d.MaNhomNavigation).WithMany(p => p.TkNqs)
                .HasForeignKey(d => d.MaNhom)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TK_NQ_NhomQuyen");

            entity.HasOne(d => d.MaTaiKhoanNavigation).WithMany(p => p.TkNqs)
                .HasForeignKey(d => d.MaTaiKhoan)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TK_NQ_TAIKHOAN");
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
                .HasConstraintName("FK__VIPHAM__MaHV__49C3F6B7");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
