using System;
using System.Collections.Generic;

namespace QuanLyRaVao.Models;

public partial class NhomQuyen
{
    public int MaQuyen { get; set; }

    public int MaNhom { get; set; }

    public string? GhiChu { get; set; }

    public virtual Nhom MaNhomNavigation { get; set; } = null!;

    public virtual Quyen MaQuyenNavigation { get; set; } = null!;
}
