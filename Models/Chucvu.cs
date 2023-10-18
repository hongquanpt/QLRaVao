using System;
using System.Collections.Generic;

namespace QuanLyRaVao.Models;

public partial class Chucvu
{
    public int MaCv { get; set; }

    public string TenCv { get; set; } = null!;

    public string? KyHieu { get; set; }

    public virtual ICollection<Quannhan> Quannhans { get; set; } = new List<Quannhan>();
}
