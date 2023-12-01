using System;
using System.Collections.Generic;

namespace QuanLyRaVao.Models;

public partial class Nhom
{
    public int MaNhom { get; set; }

    public string? TenNhom { get; set; }

    public virtual ICollection<NhomQuyen> NhomQuyens { get; set; } = new List<NhomQuyen>();

    public virtual ICollection<Taikhoan> Taikhoans { get; set; } = new List<Taikhoan>();
}
