using System;
using System.Collections.Generic;

namespace QuanLyRaVao.Models;

public partial class CanboDuyet
{
    public int MaCb { get; set; }

    public int MaCtds { get; set; }

    public DateTime? ThoiGianDuyet { get; set; }

    public string? GhiChu { get; set; }

    public int? NguoiSua { get; set; }

    public DateTime? ThoiGianSua { get; set; }

    public virtual Quannhan MaCbNavigation { get; set; } = null!;

    public virtual Chitietdanhsach MaCtdsNavigation { get; set; } = null!;
}
