using System;
using System.Collections.Generic;

namespace QuanLyRaVao.Models;

public partial class TaikhoanQuyen
{
    public int MaTaiKhoan { get; set; }

    public int MaQuyen { get; set; }

    public bool? Khoa { get; set; }

    public int? NguoiSua { get; set; }

    public DateTime? ThoiGianSua { get; set; }

    public virtual Quyen MaQuyenNavigation { get; set; } = null!;

    public virtual Taikhoan MaTaiKhoanNavigation { get; set; } = null!;
}
