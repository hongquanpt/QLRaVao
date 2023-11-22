﻿namespace QuanLyRaVao.Models
{
    public class TT_QN
    {
        public int MaQn { get; set; }

        public string HoTen { get; set; } = null!;

        public bool TonTai { get; set; }

        public int? NguoiSua { get; set; }

        public DateTime? ThoiGianSua { get; set; }

        public int? MaCv { get; set; }

        public int? MaDv { get; set; }

        public int? MaCapBac { get; set; }
        public string? CapBac1 { get; set; }
        public string ?TenCv { get; set; }
        public string ?TenDv { get; set; }
        public string? DiaChi { get; set; }

        //public TT_QN(Quannhan qn) 
        //{
        //    this.MaQn = qn.MaQn;
        //    this.MaCv = qn.MaCv;
            
        //}
    }
}
