using System;
using System.Collections.Generic;

namespace QuanLyRaVao.Models;

public partial class Chitietdanhsach
{
    public int MaDs { get; set; }

    public int MaHocVien { get; set; }

    public string? LyDo { get; set; }

    public string? DiaDiem { get; set; }

    public TimeSpan? ThoiGianRa { get; set; }

    public TimeSpan? ThoiGianVao { get; set; }

    public string? GhiChu { get; set; }

    public int? NguoiSua { get; set; }

    public DateTime? ThoiGianSua { get; set; }

    public virtual Danhsach MaDsNavigation { get; set; } = null!;

    public virtual Quannhan MaHocVienNavigation { get; set; } = null!;
}
