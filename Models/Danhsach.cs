using System;
using System.Collections.Generic;

namespace QuanLyRaVao.Models;

public partial class Danhsach
{
    public int MaDs { get; set; }

    public int HinhThucRn { get; set; }

    public int? PheDuyet { get; set; }

    public virtual ICollection<Rangoai> Rangoais { get; set; } = new List<Rangoai>();
}
