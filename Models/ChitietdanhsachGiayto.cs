using System;
using System.Collections.Generic;

namespace QuanLyRaVao.Models;

public partial class ChitietdanhsachGiayto
{
    public int MaGiayTo { get; set; }

    public int MaDs { get; set; }

    public int MaHocVien { get; set; }

    public bool DaTra { get; set; }

    public DateTime? ThoiGianLay { get; set; }

    public DateTime? ThoiGianTra { get; set; }

    public string? GhiChu { get; set; }

    public bool Khoa { get; set; }

    public int? NguoiSua { get; set; }

    public DateTime? ThoiGianSua { get; set; }

    public virtual Danhsach MaDsNavigation { get; set; } = null!;

    public virtual Giayto MaGiayToNavigation { get; set; } = null!;

    public virtual Quannhan MaHocVienNavigation { get; set; } = null!;
}
