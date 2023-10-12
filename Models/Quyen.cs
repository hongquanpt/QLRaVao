using System;
using System.Collections.Generic;

namespace QuanLyRaVao.Models;

public partial class Quyen
{
    public int MaQuyen { get; set; }

    public string Ten { get; set; } = null!;

    public string? GhiChu { get; set; }

    public virtual ICollection<TaikhoanQuyen> TaikhoanQuyens { get; set; } = new List<TaikhoanQuyen>();
}
