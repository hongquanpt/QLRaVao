using System;
using System.Collections.Generic;

namespace QuanLyRaVao.Models;

public partial class Capbac
{
    public int MaCapBac { get; set; } 

    public string? CapBac1 { get; set; }

    public string? KyHieu { get; set; }

    public virtual ICollection<Quannhan> Quannhans { get; set; } = new List<Quannhan>();
}
