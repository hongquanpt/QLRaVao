using System;
using System.Collections.Generic;

namespace QuanLyRaVao.Models;

public partial class Danhsach
{
    public int MaDs { get; set; }

    public short HinhThucRn { get; set; }

    public bool PheDuyet { get; set; }

    public bool? TinhTrang { get; set; }

    public string? GhiChu { get; set; }

    public int? NguoiSua { get; set; }

    public DateTime? ThoiGianSua { get; set; }

    public virtual ICollection<CanboDuyet> CanboDuyets { get; set; } = new List<CanboDuyet>();

    public virtual ICollection<ChitietdanhsachGiayto> ChitietdanhsachGiaytos { get; set; } = new List<ChitietdanhsachGiayto>();

    public virtual ICollection<Chitietdanhsach> Chitietdanhsaches { get; set; } = new List<Chitietdanhsach>();

    public virtual ICollection<Rangoai> Rangoais { get; set; } = new List<Rangoai>();
}
