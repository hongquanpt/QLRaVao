using System;
using System.Collections.Generic;

namespace QuanLyRaVao.Models;

public partial class Giayto
{
    public int MaGiayTo { get; set; }

    public bool Loai { get; set; }

    public int SoGiay { get; set; }

    public bool TinhTrang { get; set; }

    public string? GhiChu { get; set; }

    public int? NguoiSua { get; set; }

    public DateTime? ThoiGianSua { get; set; }

    public int? MaDv { get; set; }

    public virtual ICollection<ChitietdanhsachGiayto> ChitietdanhsachGiaytos { get; set; } = new List<ChitietdanhsachGiayto>();

    public virtual Donvi? MaDvNavigation { get; set; }

    public virtual ICollection<Rangoai> Rangoais { get; set; } = new List<Rangoai>();
}
