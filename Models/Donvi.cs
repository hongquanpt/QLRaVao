using System;
using System.Collections.Generic;

namespace QuanLyRaVao.Models;

public partial class Donvi
{
    public string MaDv { get; set; } = null!;

    public short Cap { get; set; }

    public string TenDv { get; set; } = null!;

    public bool? Xoa { get; set; }

    public int? NguoiSua { get; set; }

    public DateTime? ThoiGianSua { get; set; }

    public virtual ICollection<Giayto> Giaytos { get; set; } = new List<Giayto>();

    public virtual ICollection<Quannhan> Quannhans { get; set; } = new List<Quannhan>();
}
