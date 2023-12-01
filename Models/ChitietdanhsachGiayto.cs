using System;
using System.Collections.Generic;

namespace QuanLyRaVao.Models;

public partial class ChitietdanhsachGiayto
{
    public int MaGiayTo { get; set; }

    public int MaCtds { get; set; }

    public bool DaTra { get; set; }

    public DateTime? ThoiGianLay { get; set; }

    public DateTime? ThoiGianTra { get; set; }

    public string? GhiChu { get; set; }

    public bool Khoa { get; set; }

    public int? NguoiSua { get; set; }

    public DateTime? ThoiGianSua { get; set; }

    public virtual Chitietdanhsach MaCtdsNavigation { get; set; } = null!;

    public virtual Giayto MaGiayToNavigation { get; set; } = null!;
}
