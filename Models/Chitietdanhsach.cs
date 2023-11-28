using System;
using System.Collections.Generic;

namespace QuanLyRaVao.Models;

public partial class Chitietdanhsach
{
    public int MaDs { get; set; }

    public int MaHocVien { get; set; }

    public string? LyDo { get; set; }

    public string? DiaDiem { get; set; }

    public DateTime? ThoiGianRa { get; set; }

    public DateTime? ThoiGianVao { get; set; }

    public string? GhiChu { get; set; }

    public int? NguoiSua { get; set; }

    public DateTime? ThoiGianSua { get; set; }

    public int? TinhTrang { get; set; }

    public int MaCtds { get; set; }

    public virtual ICollection<CanboDuyet> CanboDuyets { get; set; } = new List<CanboDuyet>();

    public virtual ICollection<ChitietdanhsachGiayto> ChitietdanhsachGiaytos { get; set; } = new List<ChitietdanhsachGiayto>();

    public virtual Danhsach MaDsNavigation { get; set; } = null!;

    public virtual Quannhan MaHocVienNavigation { get; set; } = null!;
}
