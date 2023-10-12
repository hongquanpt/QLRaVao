using System;
using System.Collections.Generic;

namespace QuanLyRaVao.Models;

public partial class CanboDuyet
{
    public int MaCb { get; set; }

    public int MaDs { get; set; }

    public DateTime? ThoiGianDuyet { get; set; }

    public bool TinhTrang { get; set; }

    public string? GhiChu { get; set; }

    public virtual Quannhan MaCbNavigation { get; set; } = null!;

    public virtual Danhsach MaDsNavigation { get; set; } = null!;
}
