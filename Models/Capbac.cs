using System;
using System.Collections.Generic;

namespace QuanLyRaVao.Models;

public partial class Capbac
{
    public string MaCapBac { get; set; } = null!;

    public string? CapBac1 { get; set; }

    public string? KyHieu { get; set; }

    public virtual ICollection<Quannhan> Quannhans { get; set; } = new List<Quannhan>();
}
