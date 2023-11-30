using System;
using System.Collections.Generic;

namespace QuanLyRaVao.Models;

public partial class Taikhoan
{
    public int MaTaiKhoan { get; set; }

    public string Tdn { get; set; } = null!;

    public string MatKhau { get; set; } = null!;

    public bool? Khoa { get; set; }

    public int? MaQn { get; set; }

    public int? MaNhom { get; set; }

    public virtual Nhom? MaNhomNavigation { get; set; }

    public virtual Quannhan? MaQnNavigation { get; set; }
}
