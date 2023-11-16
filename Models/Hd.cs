using System;
using System.Collections.Generic;

namespace QuanLyRaVao.Models;

public partial class Hd
{
    public int MaA { get; set; }

    public string? TenA { get; set; }

    public virtual ICollection<NQHd> NQHds { get; set; } = new List<NQHd>();
}
