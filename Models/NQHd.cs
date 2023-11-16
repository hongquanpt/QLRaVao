using System;
using System.Collections.Generic;

namespace QuanLyRaVao.Models;

public partial class NQHd
{
    public int MaA { get; set; }

    public int MaQuyen { get; set; }

    public int MaNhom { get; set; }

    public string? Ten { get; set; }

    public virtual Hd MaANavigation { get; set; } = null!;

    public virtual NhomQuyen MaNhomNavigation { get; set; } = null!;

    public virtual Quyen MaQuyenNavigation { get; set; } = null!;
}
