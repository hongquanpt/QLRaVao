using System;
using System.Collections.Generic;

namespace QuanLyRaVao.Models;

public partial class Rangoai
{
    public int MaRn { get; set; }

    public DateTime? ThoiGianRa { get; set; }

    public DateTime? ThoiGianVao { get; set; }

    public string? GhiChu { get; set; }

    public bool? Khoa { get; set; }

    public int? NguoiSua { get; set; }

    public DateTime? ThoiGianSua { get; set; }

    public int? MaVp { get; set; }

    public int? MaGiayTo { get; set; }

    public int MaCtds { get; set; }

    public virtual Chitietdanhsach MaCtdsNavigation { get; set; } = null!;

    public virtual Giayto? MaGiayToNavigation { get; set; }

    public virtual Vipham? MaVpNavigation { get; set; }
}
