using System;
using System.Collections.Generic;

namespace QuanLyRaVao.Models;

public partial class TkNq
{
    public int MaNhom { get; set; }

    public int MaTaiKhoan { get; set; }

    public string? GhiChu { get; set; }

    public virtual NhomQuyen MaNhomNavigation { get; set; } = null!;

    public virtual Taikhoan MaTaiKhoanNavigation { get; set; } = null!;
}
