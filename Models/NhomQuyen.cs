using System;
using System.Collections.Generic;

namespace QuanLyRaVao.Models;

public partial class NhomQuyen
{
    public int MaNhom { get; set; }

    public string? TenNhom { get; set; }

    public virtual ICollection<NQHd> NQHds { get; set; } = new List<NQHd>();

    public virtual ICollection<Taikhoan> Taikhoans { get; set; } = new List<Taikhoan>();
}
