using System;
using System.Collections.Generic;

namespace QuanLyRaVao.Models;

public partial class Danhsach
{
    public int MaDs { get; set; }

    public int HinhThucRn { get; set; }

    public virtual ICollection<Chitietdanhsach> Chitietdanhsaches { get; set; } = new List<Chitietdanhsach>();

    public virtual ICollection<Rangoai> Rangoais { get; set; } = new List<Rangoai>();
}
