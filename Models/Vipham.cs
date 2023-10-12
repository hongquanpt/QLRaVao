using System;
using System.Collections.Generic;

namespace QuanLyRaVao.Models;

public partial class Vipham
{
    public int MaVp { get; set; }

    public string MoTa { get; set; } = null!;

    public bool Loai { get; set; }

    public DateTime? ThoiGian { get; set; }

    public string? GhiChu { get; set; }

    public bool? Khoa { get; set; }

    public int? NguoiSua { get; set; }

    public DateTime? ThoiGianSua { get; set; }

    public int? MaHv { get; set; }

    public virtual Quannhan? MaHvNavigation { get; set; }

    public virtual ICollection<Rangoai> Rangoais { get; set; } = new List<Rangoai>();
}
