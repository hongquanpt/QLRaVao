using System;
using System.Collections.Generic;

namespace QuanLyRaVao.Models;

public partial class Quannhan
{
    public int MaQn { get; set; }

    public string HoTen { get; set; } = null!;

    public bool TonTai { get; set; }

    public int? NguoiSua { get; set; }

    public DateTime? ThoiGianSua { get; set; }

    public int? MaCv { get; set; }

    public int? MaDv { get; set; }

    public int? MaCapBac { get; set; }

    public string? DiaChi { get; set; }

    public virtual ICollection<CanboDuyet> CanboDuyets { get; set; } = new List<CanboDuyet>();

    public virtual ICollection<Chitietdanhsach> Chitietdanhsaches { get; set; } = new List<Chitietdanhsach>();

    public virtual Capbac? MaCapBacNavigation { get; set; }

    public virtual Chucvu? MaCvNavigation { get; set; }

    public virtual Donvi? MaDvNavigation { get; set; }

    public virtual ICollection<Taikhoan> Taikhoans { get; set; } = new List<Taikhoan>();

    public virtual ICollection<Vipham> Viphams { get; set; } = new List<Vipham>();
}
