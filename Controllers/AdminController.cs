using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuanLyRaVao.authorize;
using QuanLyRaVao.Data;
using QuanLyRaVao.Models;
using System;
using System.Data;
using System.Security.Cryptography;
using X.PagedList;

namespace QuanLyRaVao.Controllers
{
    public class AdminController : Controller
    {
        private readonly QuanLyRaVaoContext obj;
       
        public AdminController(QuanLyRaVaoContext obj)
        {
            this.obj = obj;
        }
        public IActionResult Index()
        {
            return View();
        }
        #region admin
        #region Quản lý đơn vị
        public IActionResult QuanLyDonVi(int madv,int cap, string tendv,int page = 1, int pageSize = 5)
        {

            var query = from dv in obj.Donvis select dv;
                       
            if (madv != 0)
            {
                query = query.Where(item => item.MaDv == madv);
            }
            if (cap != 0)
            {
                query = query.Where(item => item.Cap == cap);
            }
            if (!string.IsNullOrEmpty(tendv))
            {
                query = query.Where(dm => dm.TenDv.Contains(tendv)); // hoặc OrderByDescending(dm => dm.MaDanhMuc)
            }
            var model = query.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            // Tính toán thông tin phân trang
            var totalItemCount = query.Count();
            var pagedList = new StaticPagedList<Donvi>(model, page, pageSize, totalItemCount);
            ViewBag.PageStartItem = (page - 1) * pageSize + 1;
            ViewBag.PageEndItem = Math.Min(page * pageSize, totalItemCount);
            ViewBag.Page = page;
            ViewBag.TotalItemCount = totalItemCount;
            return View(pagedList);
        }
        [HttpPost]
        public ActionResult ThemDonVi( string tendv, short cap)
        {
            var moi = new Models.Donvi();
            moi.Cap = cap;
            moi.TenDv = tendv;        
            obj.Donvis.Add(moi);
            obj.SaveChanges();
            return Json(new
            {
                status= true 
            });
        }
        public IActionResult XoaDonVi(int madv)
        {
            var donvi = obj.Donvis.Find(madv);
            if (donvi != null)
            {
                obj.Donvis.Remove(donvi);
                obj.SaveChanges();
                return Json(new
                {
                    status = true
                });
            }
            else
            {
                return Json(new
                {
                    status = false
                });
            }

        }

        public IActionResult SuaDonVi(int madv)
        {
            var model = obj.Donvis.Find(madv);
            return View(model);
        }
        [HttpPost]
        public IActionResult SuaDonVi(int madv, string tendv, short cap)
        {
            var donvi = obj.Donvis.Find(madv);
            if (donvi != null)
            {
                donvi.TenDv = tendv;
                donvi.Cap = cap;
                obj.SaveChanges();
                return Json(new
                {
                    status = true
                });
            }
            else
            {
                return Json(new
                {
                    status = false
                });
            }
        }
        #endregion
        #region Quản lý cấp bậc
        public IActionResult QuanLyCapBac(int macb,string capbac,string kyhieu,int page = 1, int pageSize = 5)
        {
            var query = obj.Capbacs.ToList();
            if (macb != 0)
            {
                query= query.Where(c=>c.MaCapBac == macb).ToList();
            }
            if (!string.IsNullOrEmpty(capbac))
            {
                query = query.Where(dm => dm.CapBac1.Contains(capbac)).ToList(); // hoặc OrderByDescending(dm => dm.MaDanhMuc)
            }
            if (!string.IsNullOrEmpty(kyhieu))
            {
                query = query.Where(dm => dm.KyHieu.Contains(kyhieu)).ToList(); // hoặc OrderByDescending(dm => dm.MaDanhMuc)
            }
            var model = query.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            // Tính toán thông tin phân trang
            var totalItemCount = query.Count();
            var pagedList = new StaticPagedList<Capbac>(model, page, pageSize, totalItemCount);
            ViewBag.PageStartItem = (page - 1) * pageSize + 1;
            ViewBag.PageEndItem = Math.Min(page * pageSize, totalItemCount);
            ViewBag.Page = page;
            ViewBag.TotalItemCount = totalItemCount;
            return View(pagedList);
        }
  
        [HttpPost]
        public IActionResult ThemCapBac(string tenCB, string KH)
        {
            var spmoi = new Models.Capbac();
            if (tenCB != null && KH != null)
            {
                spmoi.CapBac1 = tenCB;
                spmoi.KyHieu = KH;
                obj.Capbacs.Add(spmoi);
                obj.SaveChanges();
                return Json(new
                {
                    status = true
                });
            }
            else
            {
                return Json(new
                {
                    status = false
                });
            }
        }
        public IActionResult SuaCapBac(int maCB)
        {
            var cb = obj.Capbacs.Find(maCB);
            if (cb != null)
                return View(cb);
            else return Json(new { status = false });

        }
        [HttpPost]
        public IActionResult SuaCapBac(int maCB, string tenCB, string KH)
        {
            var cb = obj.Capbacs.Find(maCB);
            if (cb != null)
            {
                cb.KyHieu = KH;
                cb.CapBac1 = tenCB;
                obj.SaveChanges();
                return Json(new { status = true });
            }
            else
            {
                return Json(new { status = false });
            }
        }
        public IActionResult XoaCapBac(int maCB)
        {
            var cb = obj.Capbacs.Find(maCB);
            if (cb != null)
            {
                obj.Capbacs.Remove(cb);
                obj.SaveChanges();
                return Json(new
                {
                    status = true
                });
            }
            else
            {
                return Json(new
                {
                    status = false
                });
            }

        }
        #endregion
        #region Quản lý chức vụ

        public IActionResult QuanLyChucVu(int macv, string tencv, string kyhieu,int page = 1, int pageSize = 5)
        {

            var query = obj.Chucvus.OrderBy(s => s.MaCv).ToList();
            if (macv != 0)
            {
                query = query.Where(c => c.MaCv == macv).ToList();
            }
            if (!string.IsNullOrEmpty(tencv))
            {
                query = query.Where(dm => dm.TenCv.Contains(tencv)).ToList(); // hoặc OrderByDescending(dm => dm.MaDanhMuc)
            }
            if (!string.IsNullOrEmpty(kyhieu))
            {
                query = query.Where(dm => dm.KyHieu.Contains(kyhieu)).ToList(); // hoặc OrderByDescending(dm => dm.MaDanhMuc)
            }
            var model = query.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            // Tính toán thông tin phân trang
            var totalItemCount = query.Count();
            var pagedList = new StaticPagedList<Chucvu>(model, page, pageSize, totalItemCount);
            ViewBag.PageStartItem = (page - 1) * pageSize + 1;
            ViewBag.PageEndItem = Math.Min(page * pageSize, totalItemCount);
            ViewBag.Page = page;
            ViewBag.TotalItemCount = totalItemCount;
            return View(pagedList);
        }

        [HttpPost]
        public ActionResult ThemChucVu(string TenCv, string KH)
        {
            var moi = new Models.Chucvu();
            moi.KyHieu = KH;
            moi.TenCv = TenCv;
            obj.Chucvus.Add(moi);
            obj.SaveChanges();
            return Json(new
            {
                status = true
            });
        }
        public IActionResult XoaChucVu(int macv)
        {
            var ChucVu = obj.Chucvus.Find(macv);
            if (ChucVu != null)
            {
                obj.Chucvus.Remove(ChucVu);
                obj.SaveChanges();
                return Json(new
                {
                    status = true
                });
            }
            else
            {
                return Json(new
                {
                    status = false
                });
            }

        }

        public IActionResult SuaChucVu(int macv)
        {
            var model = obj.Chucvus.Find(macv);
            return View(model);
        }
        [HttpPost]
        public IActionResult SuaChucVu(int macv, string TenCv, string KH)
        {
            var ChucVu = obj.Chucvus.Find(macv);
            if (ChucVu != null)
            {
                ChucVu.TenCv = TenCv;
                ChucVu.KyHieu = KH;
                obj.SaveChanges();
                return Json(new
                {
                    status = true
                });
            }
            else
            {
                return Json(new
                {
                    status = false
                });
            }
        }

        #endregion
        #region Quản lý giấy tờ
        public IActionResult QuanLyGiayTo(int magiayto,bool loai,int sogiay,int madv,int page = 1, int pageSize = 5)
        {
            var query = obj.Giaytos.OrderBy(s => s.MaGiayTo).ToList();
            if (magiayto != 0)
            {
                query = query.Where(item => item.MaGiayTo == magiayto).ToList();
            }
            if (loai != null)
            {
                query = query.Where(item => item.Loai == loai).ToList();
            }
            if (sogiay != 0)
            {
                query = query.Where(item => item.SoGiay == sogiay).ToList();
            }
            if (madv != 0)
            {
                query = query.Where(item => item.MaDv ==madv).ToList();
            }

            var model = query.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            // Tính toán thông tin phân trang
            var totalItemCount = query.Count();
            var pagedList = new StaticPagedList<Giayto>(model, page, pageSize, totalItemCount);
            ViewBag.PageStartItem = (page - 1) * pageSize + 1;
            ViewBag.PageEndItem = Math.Min(page * pageSize, totalItemCount);
            ViewBag.Page = page;
            ViewBag.TotalItemCount = totalItemCount;
          //  ViewBag.ChonDonVi = (obj.Donvis.ToList());
            ViewBag.ChonDonVi = (obj.Donvis.ToList());
            return View(pagedList);
        }
        [HttpPost]
        public ActionResult ThemGiayTo(bool Loai, int sogiay, int madv)
        {
            var moi = new Models.Giayto();
            moi.Loai = Loai;
            moi.SoGiay = sogiay;
            moi.MaDv= madv;
            obj.Giaytos.Add(moi);
            obj.SaveChanges();
            return Json(new
            {
                status = true
            });
        }
        public IActionResult XoaGiayTo(int magiayto)
        {
            var giayto = obj.Giaytos.Find(magiayto);
            if (giayto != null)
            {
                obj.Giaytos.Remove(giayto);
                obj.SaveChanges();
                return Json(new
                {
                    status = true
                });
            }
            else
            {
                return Json(new
                {
                    status = false
                });
            }

        }

        public IActionResult SuaGiayTo(int magiayto)
        {
            var model = obj.Giaytos.Find(magiayto);
            ViewBag.ChonDonVi = (obj.Donvis.ToList());
            return View(model);
        }
        [HttpPost]
        public IActionResult SuaGiayTo(int magiayto, bool loai, int  sogiay,int madv)
        {
            var giayto = obj.Giaytos.Find(magiayto);
            if (giayto != null)
            {
                giayto.SoGiay = sogiay;
                giayto.Loai = loai;
                giayto.MaDv= madv;
                obj.SaveChanges();
                return Json(new
                {
                    status = true
                });
            }
            else
            {
                return Json(new
                {
                    status = false
                });
            }
        }

        #endregion
        #region Quản lý tài khoản
        public IActionResult QuanLyTK( int page = 1, int pageSize = 10)
        {
            // Thực hiện truy vấn và phân trang
            var query = from tk in obj.Taikhoans
                        join cv in obj.Nhoms on tk.MaNhom equals cv.MaNhom
                        join  qn in obj.Quannhans on tk.MaQn equals qn.MaQn
                        join dv in obj.Donvis on qn.MaDv equals dv.MaDv
                        join cb in obj.Capbacs on qn.MaCapBac equals cb.MaCapBac                       
                        join ch in obj.Chucvus on qn.MaCv equals ch.MaCv
                        select new TT_TK
                        {
                            MaTaiKhoan = tk.MaTaiKhoan,
                            Tdn= tk.Tdn,
                            MaNhom= cv.MaNhom,
                            Khoa= tk.Khoa,
                            MaQn=qn.MaQn,
                            HoTen= qn.HoTen,
                            TenNhom=cv.TenNhom,
                            TenDv=dv.TenDv,
                            TenCv=ch.TenCv,
                            CapBac1=cb.CapBac1
                        }; 

            var nhomquyen = obj.NhomQuyens.ToList();
            var model = query.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            // Tính toán thông tin phân trang
            var totalItemCount = query.Count();
            var pagedList = new StaticPagedList<TT_TK>(model, page, pageSize, totalItemCount);
            ViewBag.PageStartItem = (page - 1) * pageSize + 1;
            ViewBag.PageEndItem = Math.Min(page * pageSize, totalItemCount);
            ViewBag.Page = page;
            ViewBag.TotalItemCount = totalItemCount;
             ViewBag.nhomquyen=nhomquyen;
            ViewBag.ChonCapBac = (obj.Capbacs.ToList());
            ViewBag.ChonChucVu = (obj.Chucvus.ToList());
            ViewBag.ChonDonVi = (obj.Donvis.ToList());
            ViewBag.ChonQuanNhan = (obj.Quannhans.ToList());
            ViewBag.ChonNhomQuyen = (obj.NhomQuyens.ToList());
            ViewBag.ChonNhom = (obj.Nhoms.ToList());
            return View(pagedList);
        }
        [HttpPost]
        public ActionResult ThemTaiKhoan(string tdn, string  matkhau, int maqn, int manhom)
        {
            var moi = new Models.Taikhoan();
            moi.Tdn = tdn;
            moi.MatKhau = matkhau;
            moi.MaQn = maqn;
            moi.MaNhom = manhom;
            obj.Taikhoans.Add(moi);
            obj.SaveChanges();
            return Json(new
            {
                status = true
            });
        }
        public IActionResult XoaTaiKhoan(int mataikhoan)
        {
            var taikhoan = obj.Taikhoans.Find(mataikhoan);
            if (taikhoan != null)
            {
                obj.Taikhoans.Remove(taikhoan);
                obj.SaveChanges();
                return Json(new
                {
                    status = true
                });
            }
            else
            {
                return Json(new
                {
                    status = false
                });
            }

        }

        public IActionResult SuaTaiKhoan(int mataikhoan)
        {
            var model = obj.Taikhoans.Find(mataikhoan);
            ViewBag.ChonQuanNhan = (obj.Quannhans.ToList());
            ViewBag.ChonNhomQuyen = (obj.NhomQuyens.ToList());
            return View(model);
        }
        [HttpPost]
        public IActionResult SuaTaiKhoan(int mataikhoan, string tdn, string matkhau, int maqn, int manhom)
        {
            var taikhoan = obj.Taikhoans.Find(mataikhoan);
            if (taikhoan != null)
            {
                taikhoan.Tdn = tdn;
                taikhoan.MatKhau = matkhau;
                taikhoan.MaQn = maqn;
                taikhoan.MaNhom = manhom;
                obj.SaveChanges();
                return Json(new
                {
                    status = true
                });
            }
            else
            {
                return Json(new
                {
                    status = false
                });
            }
        }
        #endregion

        #endregion
       
        #region Quản lý danh sách     
        public IActionResult QuanLyDanhSach(int page = 1, int pageSize = 5)
        {

            var query = from  ct in obj.Chitietdanhsaches 
                        join qn in obj.Quannhans on ct.MaHocVien equals qn.MaQn
                        join cb in obj.Capbacs on qn.MaCapBac equals cb.MaCapBac
                        join dv in obj.Donvis on qn.MaDv equals dv.MaDv
                        join cv in obj.Chucvus on qn.MaCv equals cv.MaCv
                        
                        select new DSRN
                        {
                            MaCTDS= ct.MaCtds,                        
                            MaHocVien = ct.MaHocVien,
                            LyDo = ct.LyDo,
                            DiaDiem = ct.DiaDiem,
                            ThoiGianRa = ct.ThoiGianRa,
                            ThoiGianVao = ct.ThoiGianVao,
                            TinhTrang = ct.TinhTrang,
                            HinhThucRn = ct.HinhThucRn,
                            MaCv = qn.MaCv,
                            MaDv = qn.MaDv,
                            MaCapBac = qn.MaCapBac,
                            CapBac1 = cb.CapBac1,
                            TenCv = cv.TenCv,
                            TenDv = dv.TenDv,
                            DiaChi = qn.DiaChi,
                            HoTen = qn.HoTen
                        };
            // Tạo danh sách các tình trạng

            var tinhTrang5 = query.Where(o => o.TinhTrang == 4).OrderBy(o => o.MaCTDS).ToList();
            var tinhTrang0 = query.Where(o => o.TinhTrang == 0).OrderBy(o => o.MaCTDS).ToList();
            var tinhTrang1 = query.Where(o => o.TinhTrang == 1).OrderBy(o => o.MaCTDS).ToList();
            var tinhTrang2 = query.Where(o => o.TinhTrang == 2).OrderBy(o => o.MaCTDS).ToList();
            var tinhTrang3 = query.Where(o => o.TinhTrang == 3).OrderBy(o => o.MaCTDS).ToList();
            var tinhTrang4 = query.Where(o => o.TinhTrang == 4).OrderBy(o => o.MaCTDS).ToList();

            // Tạo danh sách phân trang cho từng tình trạng
            var pagedList5 = tinhTrang5.ToPagedList(page, pageSize);
            var pagedList0 = tinhTrang0.ToPagedList(page, pageSize);
            var pagedList1 = tinhTrang1.ToPagedList(page, pageSize);
            var pagedList2 = tinhTrang2.ToPagedList(page, pageSize);
            var pagedList3 = tinhTrang3.ToPagedList(page, pageSize);
            var pagedList4 = tinhTrang4.ToPagedList(page, pageSize);

            ViewBag.pagedList5 = pagedList5;
            ViewBag.pagedList0 = pagedList0;
            ViewBag.pagedList1 = pagedList1;
            ViewBag.pagedList2 = pagedList2;
            ViewBag.pagedList3 = pagedList3;
            ViewBag.pagedList4 = pagedList4;
            ViewBag.PageStartItem = (page - 1) * pageSize + 1;
            ViewBag.PageEndItem = Math.Min(page * pageSize, pagedList5.TotalItemCount);
            ViewBag.Page = page;

            int totalOrders = obj.Chitietdanhsaches.Count(o => o.TinhTrang == 4);
            int unpaidOrdersCount = obj.Chitietdanhsaches.Count(o => o.TinhTrang == 0);
            int pendingOrdersCount = obj.Chitietdanhsaches.Count(o => o.TinhTrang == 1);
            int shippingOrdersCount = obj.Chitietdanhsaches.Count(o => o.TinhTrang == 2);
            int completedOrdersCount = obj.Chitietdanhsaches.Count(o => o.TinhTrang == 3);
            int canceledOrdersCount = obj.Chitietdanhsaches.Count(o => o.TinhTrang == 4);

            ViewBag.DaHoanThanh = totalOrders;
            ViewBag.DaBiTuChoi = unpaidOrdersCount;
            ViewBag.ChuaPheDuyet = pendingOrdersCount;
            ViewBag.PheDuyetC = shippingOrdersCount;
            ViewBag.PheDuyetD = completedOrdersCount;
            ViewBag.PheDuyetCong = canceledOrdersCount;
            var query2 = from ct in obj.Chitietdanhsaches
                        join qn in obj.Quannhans on ct.MaHocVien equals qn.MaQn
                        join cb in obj.Capbacs on qn.MaCapBac equals cb.MaCapBac
                        join dv in obj.Donvis on qn.MaDv equals dv.MaDv
                        join cv in obj.Chucvus on qn.MaCv equals cv.MaCv
                        join dsgt in obj.ChitietdanhsachGiaytos on ct.MaCtds equals dsgt.MaCtds
                        join gt in obj.Giaytos on dsgt.MaGiayTo equals gt.MaGiayTo
                        where ct.TinhTrang == 3
                        select new DSGT
                        {
                            MaCtds = dsgt.MaCtds,
                            MaHocVien = ct.MaHocVien,
                            MaGiayTo = dsgt.MaGiayTo,
                            SoGiay = gt.SoGiay,
                            ThoiGianLay = dsgt.ThoiGianLay,
                            ThoiGianTra = dsgt.ThoiGianTra,
                            DaTra = gt.TinhTrang,
                            MaCv = qn.MaCv,
                            MaDv = qn.MaDv,
                            MaCapBac = qn.MaCapBac,
                            CapBac1 = cb.CapBac1,
                            TenCv = cv.TenCv,
                            TenDv = dv.TenDv,
                            TinhTrang = ct.TinhTrang,
                            ThoiGianRa = ct.ThoiGianRa,
                            ThoiGianVao = ct.ThoiGianVao,
                            HoTen = qn.HoTen
                        };
            List<DSGT> ds = query2.ToList();
            HttpContext.Session.SetJson("DS", ds);
            List<Giayto> giayto = obj.Giaytos.Where(c => c.TinhTrang == true).ToList();
            HttpContext.Session.SetJson("GT", giayto);
            List<int> mahv=ds.Select(c=>c.MaHocVien).ToList();
            var hv= obj.Quannhans.Where(c=>c.MaCv==1||c.MaCv==2).ToList();
            var hocvien=hv.Where(c => !mahv.Contains(c.MaQn)).ToList();      
            HttpContext.Session.SetJson("HV", hocvien);
            return View();
        }
        public IActionResult Duyet1(int mactds, int maqn)
        {
            
            var dh = obj.Chitietdanhsaches.FirstOrDefault(c => c.MaCtds == mactds);

            if (dh != null)
            {
                var duyet = new CanboDuyet
                {
                    MaCtds = mactds,
                    MaCb = maqn,
                    ThoiGianDuyet = DateTime.Now,
                    GhiChu = "Phê duyệt đại đội"
                };               
                obj.CanboDuyets.Add(duyet);       
                dh.TinhTrang = 2;
                obj.SaveChanges();
                return Json(new
                {
                    status = true
                });
            }
            else
            {
                return Json(new
                {
                    status = false
                });
            }
        }


        public IActionResult TC1(int mactds, int maqn)
        {
            
            var dh = obj.Chitietdanhsaches.Where(c => c.MaCtds == mactds).FirstOrDefault();
            if (dh != null)
            {
                var duyet = new CanboDuyet
                {
                    MaCtds = mactds,
                    MaCb = maqn,
                    ThoiGianDuyet = DateTime.Now,
                    GhiChu = "Từ chối đại đội"
                };
                obj.CanboDuyets.Add(duyet);
                dh.TinhTrang = 0;
                obj.SaveChanges();
                return Json(new
                {
                    status = true
                });
            }
            else
            {
                return Json(new
                {
                    status = false
                });
            }

        }
        public IActionResult All1(int maqn)
        {
           
            // Lấy danh sách chi tiết đánh sách có trạng thái là 1
            var danhSachChiTiet = obj.Chitietdanhsaches.Where(c => c.TinhTrang == 1).ToList();
            
            // Lấy danh sách ID của vi phạm
            List<int> viphamsIds = obj.Viphams.Select(v => v.MaHv).ToList();
            //List<string> diachi= obj.Quannhans.Select(v=>v.DiaChi).ToList();
            // Kiểm tra xem danh sách ID của vi phạm có dữ liệu và danh sách chi tiết có dữ liệu không
            if (viphamsIds.Any() && danhSachChiTiet != null && danhSachChiTiet.Any())
            {
                // Lọc và chỉ giữ lại các đối tượng không có mã trong danh sách vi phạm
                var danhSachKhongViPham = danhSachChiTiet.Where(c => !viphamsIds.Contains(c.MaHocVien)).ToList();
                var danhSachViPham= danhSachChiTiet.Where(c => viphamsIds.Contains(c.MaHocVien)).ToList();
                // Cập nhật trạng thái trực tiếp trong cơ sở dữ liệu
                foreach (var chiTiet in danhSachKhongViPham)
                {
                    // Kiểm tra nếu HinhThuc là 1 trong danhSachChiTiet
                    if (chiTiet.HinhThucRn == 1)
                    {
                        string diachi = obj.Quannhans.Where(c => c.MaQn == chiTiet.MaHocVien).FirstOrDefault().DiaChi;
                        // So sánh địa chỉ với obj.QuanNhans và gán TinhTrang tùy thuộc vào kết quả
                        if (chiTiet.DiaDiem.Contains(diachi))
                        {
                            var duyet = new CanboDuyet
                            {
                                MaCtds = chiTiet.MaCtds,
                                MaCb = maqn,
                                ThoiGianDuyet = DateTime.Now,
                                GhiChu = "Từ chối đại đội"
                            };

                            // Add the entity to the context
                            obj.CanboDuyets.Add(duyet);
                            chiTiet.TinhTrang = 0;
                        }
                        else
                        {
                            var duyet = new CanboDuyet
                            {
                                MaCtds = chiTiet.MaCtds,
                                MaCb = maqn,
                                ThoiGianDuyet = DateTime.Now,
                                GhiChu = "Phê duyệt đại đội"
                            };

                            // Add the entity to the context
                            obj.CanboDuyets.Add(duyet);
                            chiTiet.TinhTrang = 2;
                        }
                    }
                    else
                    {
                        var duyet = new CanboDuyet
                        {
                            MaCtds = chiTiet.MaCtds,
                            MaCb = maqn,
                            ThoiGianDuyet = DateTime.Now,
                            GhiChu = "Phê duyệt đại đội"
                        };

                        // Add the entity to the context
                        obj.CanboDuyets.Add(duyet);
                        // Nếu HinhThuc có giá trị khác 1, gán TinhTrang = 2
                        chiTiet.TinhTrang = 2;
                    }
                }
                foreach (var chiTiet in danhSachViPham)
                {
                    var duyet = new CanboDuyet
                    {
                        MaCtds = chiTiet.MaCtds,
                        MaCb = maqn,
                        ThoiGianDuyet = DateTime.Now,
                        GhiChu = "Từ chối đại đội"
                    };

                    // Add the entity to the context
                    obj.CanboDuyets.Add(duyet);
                    chiTiet.TinhTrang = 0 ;                   
                }
                // Lưu thay đổi vào cơ sở dữ liệu
                obj.SaveChanges();

                return Json(new
                {
                    status = true
                });
            }
            else
            {
                return Json(new
                {
                    status = false
                });
            }
        }

        public IActionResult AllT1(int maqn)
        {
            var danhSachChiTiet = obj.Chitietdanhsaches.Where(c => c.TinhTrang == 1).ToList();         
            if ( danhSachChiTiet != null && danhSachChiTiet.Any())
            {                            
                foreach (var chiTiet in danhSachChiTiet)
                {
                    var duyet = new CanboDuyet
                    {
                        MaCtds = chiTiet.MaCtds,
                        MaCb = maqn,
                        ThoiGianDuyet = DateTime.Now,
                        GhiChu = "Từ chối đại đội"
                    };
                    chiTiet.TinhTrang = 0;
                }
                // Lưu thay đổi vào cơ sở dữ liệu
                obj.SaveChanges();

                return Json(new
                {
                    status = true
                });
            }
            else
            {
                return Json(new
                {
                    status = false
                });
            }
        }

        // Duyet d
        public IActionResult Duyet2(int mactds, int maqn)
        {
            
            var dh = obj.Chitietdanhsaches.Find(mactds);
            if (dh != null)
            {
                var duyet = new CanboDuyet
                {
                    MaCtds = mactds,
                    MaCb = maqn,
                    ThoiGianDuyet = DateTime.Now,
                    GhiChu = "Phê duyệt tiểu đoàn"
                };
                obj.CanboDuyets.Add(duyet);
                dh.TinhTrang = 3;
                obj.SaveChanges();
                return Json(new
                {
                    status = true
                });
            }
            else
            {
                return Json(new
                {
                    status = false
                });
            }

        }
        public IActionResult TC2(int mactds, int maqn)
        {
           
            var dh = obj.Chitietdanhsaches.Where(c => c.MaCtds == mactds).FirstOrDefault();
            if (dh != null)
            {
                var duyet = new CanboDuyet
                {
                    MaCtds = mactds,
                    MaCb = maqn,
                    ThoiGianDuyet = DateTime.Now,
                    GhiChu = "Từ chối tiểu đoàn"
                };
                obj.CanboDuyets.Add(duyet);
                dh.TinhTrang = 0;
                obj.SaveChanges();
                return Json(new
                {
                    status = true
                });
            }
            else
            {
                return Json(new
                {
                    status = false
                });
            }

        }
        public IActionResult All2(int maqn)
        {
            
            
            // Lấy danh sách chi tiết đánh sách có trạng thái là 1
            var danhSachChiTiet = obj.Chitietdanhsaches.Where(c => c.TinhTrang == 2).ToList();

            // Lấy danh sách ID của vi phạm
            List<int> viphamsIds = obj.Viphams.Select(v => v.MaHv).ToList();
            //List<string> diachi= obj.Quannhans.Select(v=>v.DiaChi).ToList();
            // Kiểm tra xem danh sách ID của vi phạm có dữ liệu và danh sách chi tiết có dữ liệu không
            if (viphamsIds.Any() && danhSachChiTiet != null && danhSachChiTiet.Any())
            {
                // Lọc và chỉ giữ lại các đối tượng không có mã trong danh sách vi phạm
                var danhSachKhongViPham = danhSachChiTiet.Where(c => !viphamsIds.Contains(c.MaHocVien)).ToList();
                var danhSachViPham = danhSachChiTiet.Where(c => viphamsIds.Contains(c.MaHocVien)).ToList();
                // Cập nhật trạng thái trực tiếp trong cơ sở dữ liệu
                foreach (var chiTiet in danhSachKhongViPham)
                {
                    // Kiểm tra nếu HinhThuc là 1 trong danhSachChiTiet
                    if (chiTiet.HinhThucRn == 1)
                    {
                        string diachi = obj.Quannhans.Where(c => c.MaQn == chiTiet.MaHocVien).FirstOrDefault().DiaChi;
                        // So sánh địa chỉ với obj.QuanNhans và gán TinhTrang tùy thuộc vào kết quả
                        if (chiTiet.DiaDiem.Contains(diachi))
                        {
                            var duyet = new CanboDuyet
                            {
                                MaCtds = chiTiet.MaCtds,
                                MaCb = maqn,
                                ThoiGianDuyet = DateTime.Now,
                                GhiChu = "Từ chối tiểu đoàn"
                            };

                            // Add the entity to the context
                            obj.CanboDuyets.Add(duyet);
                            chiTiet.TinhTrang = 0;
                        }
                        else
                        {
                            var duyet = new CanboDuyet
                            {
                                MaCtds = chiTiet.MaCtds,
                                MaCb = maqn,
                                ThoiGianDuyet = DateTime.Now,
                                GhiChu = "Phê duyệt tiểu đoàn"
                            };

                            // Add the entity to the context
                            obj.CanboDuyets.Add(duyet);
                            chiTiet.TinhTrang = 3;
                        }
                    }
                    else
                    {
                        var duyet = new CanboDuyet
                        {
                            MaCtds = chiTiet.MaCtds,
                            MaCb = maqn,
                            ThoiGianDuyet = DateTime.Now,
                            GhiChu = "Phê duyệt tiểu đoàn"
                        };

                        // Add the entity to the context
                        obj.CanboDuyets.Add(duyet);
                        // Nếu HinhThuc có giá trị khác 1, gán TinhTrang = 2
                        chiTiet.TinhTrang = 3;
                    }
                }
                foreach (var chiTiet in danhSachViPham)
                {
                    var duyet = new CanboDuyet
                    {
                        MaCtds = chiTiet.MaCtds,
                        MaCb = maqn,
                        ThoiGianDuyet = DateTime.Now,
                        GhiChu = "Từ chối tiểu đoàn"
                    };

                    // Add the entity to the context
                    obj.CanboDuyets.Add(duyet);
                    chiTiet.TinhTrang = 0;
                }
                // Lưu thay đổi vào cơ sở dữ liệu
                obj.SaveChanges();

                return Json(new
                {
                    status = true
                });
            }
            else
            {
                return Json(new
                {
                    status = false
                });
            }
        }

        public IActionResult AllT2(int maqn)
        {
            
            var danhSachChiTiet = obj.Chitietdanhsaches.Where(c => c.TinhTrang == 1).ToList();
            if (danhSachChiTiet != null && danhSachChiTiet.Any())
            {
                foreach (var chiTiet in danhSachChiTiet)
                {
                    var duyet = new CanboDuyet
                    {
                        MaCtds = chiTiet.MaCtds,
                        MaCb = maqn,
                        ThoiGianDuyet = DateTime.Now,
                        GhiChu = "Từ chối tiểu đoàn"
                    };

                    // Add the entity to the context
                    obj.CanboDuyets.Add(duyet);
                    chiTiet.TinhTrang = 0;
                }
                // Lưu thay đổi vào cơ sở dữ liệu
                obj.SaveChanges();

                return Json(new
                {
                    status = true
                });
            }
            else
            {
                return Json(new
                {
                    status = false
                });
            }
        }
        public IActionResult TraGT(int id, int magiay, DateTime thoigianTra)
        {
            var giayto = obj.Giaytos.Where(c => c.MaGiayTo == magiay).FirstOrDefault();
            giayto.TinhTrang = true;
            var tinhtrang = obj.Chitietdanhsaches.Find(id);
            tinhtrang.TinhTrang = 4;
            var ct = obj.ChitietdanhsachGiaytos.Where(c => c.MaCtds == id && c.MaGiayTo == magiay).FirstOrDefault();
            ct.ThoiGianTra = thoigianTra;
            obj.SaveChanges();
            return Json(new
            {
                status = true
            });

            /* return Json(new
             {
                 status = false
             });*/

        }
        public IActionResult ThemGT(int id, int giayto, DateTime thoigianLay)
        {

            ChitietdanhsachGiayto ct = new ChitietdanhsachGiayto();
            ct.MaCtds = id;
            ct.MaGiayTo = giayto;
            ct.ThoiGianLay = thoigianLay;
            var gt = obj.Giaytos.Find(giayto);
            gt.TinhTrang = false;
            obj.ChitietdanhsachGiaytos.Add(ct);
            obj.SaveChanges();
            return Json(new
            {
                status = true
            });

            /* return Json(new
             {
                 status = false
             });*/

        } 
        public IActionResult ChiTiet(int maCTDS, int maGiayTo)
        {
            var ct= obj.ChitietdanhsachGiaytos.Where(c=>c.MaCtds==maCTDS&& c.MaGiayTo==maGiayTo).FirstOrDefault();
            return View(ct);
        }
        public IActionResult ThemDS(int hocVien, int hinhThuc, string lyDo, string diaDiem, DateTime thoiGianRa, DateTime thoiGianVao)
        {
           
            int max = obj.Chitietdanhsaches.Max(r => r.MaCtds);
            var ct = new Chitietdanhsach
            {
                MaCtds= max+1,
                MaHocVien = hocVien,
                HinhThucRn = hinhThuc,
                LyDo = lyDo,
                DiaDiem = diaDiem,
                ThoiGianRa = thoiGianRa,
                ThoiGianVao = thoiGianVao,
                TinhTrang=1
            };
            obj.Chitietdanhsaches.Add(ct);
            obj.SaveChanges();
            return Json(new
            {
                status = true
            });
        }
        #endregion
        #region Quản lý quân nhân
        public IActionResult QuanLyQuanNhan(int maqn, string diachi, string hoten, int CapBac, int ChucVu, int DonVi,int page = 1, int pageSize = 5)
        {

            var query = from qn in obj.Quannhans
                        join cb in obj.Capbacs on qn.MaCapBac equals cb.MaCapBac
                        join dv in obj.Donvis on qn.MaDv equals dv.MaDv
                        join cv in obj.Chucvus on qn.MaCv equals cv.MaCv
                        select new TT_QN
                        {
                            MaQn = qn.MaQn,
                            HoTen = qn.HoTen,
                            TonTai = qn.TonTai,
                            NguoiSua = qn.NguoiSua,
                            ThoiGianSua = qn.ThoiGianSua,
                            MaCv = qn.MaCv,
                            MaDv = qn.MaDv,
                            MaCapBac = qn.MaCapBac,
                            CapBac1 = cb.CapBac1,
                            TenCv = cv.TenCv,
                            TenDv = dv.TenDv,
                            DiaChi= qn.DiaChi
                        };

            if (maqn != 0)
            {
                query = query.Where(item => item.MaQn == maqn);
            }
            if (ChucVu != 0)
            {
                query = query.Where(item => item.MaCv == ChucVu);
            }
            if (CapBac != 0)
            {
                query = query.Where(item => item.MaCapBac == CapBac);
            }
            if (DonVi != 0)
            {
                query = query.Where(item => item.MaDv == DonVi);
            }
            if (!string.IsNullOrEmpty(diachi))
            {
                query = query.Where(dm => dm.DiaChi.Contains(diachi)); // hoặc OrderByDescending(dm => dm.MaDanhMuc)
            }
            if (!string.IsNullOrEmpty(hoten))
            {
                query = query.Where(dm => dm.HoTen.Contains(hoten)); // hoặc OrderByDescending(dm => dm.MaDanhMuc)
            }
            var model = query.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            // Tính toán thông tin phân trang
            var totalItemCount = query.Count();
            var pagedList = new StaticPagedList<TT_QN>(model, page, pageSize, totalItemCount);
            ViewBag.PageStartItem = (page - 1) * pageSize + 1;
            ViewBag.PageEndItem = Math.Min(page * pageSize, totalItemCount);
            ViewBag.Page = page;
            ViewBag.TotalItemCount = totalItemCount;
            ViewBag.ChonDonVi = (obj.Donvis.ToList());
            ViewBag.ChonChucVu = (obj.Chucvus.ToList());
            ViewBag.ChonCapBac = (obj.Capbacs.ToList());
            ViewBag.maqn = maqn;
            ViewBag.hoten = hoten;
            ViewBag.diachi= diachi;
            ViewBag.ChucVu = ChucVu;
            ViewBag.CapBac=CapBac;
            ViewBag.DonVi = DonVi;
            return View(pagedList);
        }
        [HttpPost]
        public ActionResult ThemQuanNhan(string hoten, int macv, int madv,int macapbac, string diachi)
        {
            var moi = new Models.Quannhan();
            var ttqn = new TT_QN();
            ttqn.MaQn = moi.MaQn;
            ttqn.MaCv = moi.MaCv;
            ttqn.MaDv = moi.MaDv;
            ttqn.DiaChi = moi.DiaChi;
            ttqn.HoTen = moi.HoTen;
            ttqn.MaCapBac = moi.MaCapBac;
            moi.HoTen = hoten;
            moi.MaCv = macv;
            moi.MaDv = madv;
            moi.MaCapBac=macapbac;
            moi.DiaChi=diachi;
            obj.Quannhans.Add(moi);
            obj.SaveChanges();
            return Json(new
            {
                status = true
            });
        }
        public IActionResult XoaQuanNhan(int maqn)
        {
            var quannhan = obj.Quannhans.Find(maqn);
            if (quannhan != null)
            {
                obj.Quannhans.Remove(quannhan);
                obj.SaveChanges();
                return Json(new
                {
                    status = true
                });
            }
            else
            {
                return Json(new
                {
                    status = false
                });
            }

        }

        public IActionResult SuaQuanNhan(int maqn)
        {
            var query = from qn in obj.Quannhans
                        join cb in obj.Capbacs on qn.MaCapBac equals cb.MaCapBac
                        join dv in obj.Donvis on qn.MaDv equals dv.MaDv
                        join cv in obj.Chucvus on qn.MaCv equals cv.MaCv
                        where qn.MaQn==maqn
                        select new TT_QN
                        {
                            MaQn = qn.MaQn,
                            HoTen = qn.HoTen,
                            TonTai = qn.TonTai,
                            NguoiSua = qn.NguoiSua,
                            ThoiGianSua = qn.ThoiGianSua,
                            MaCv = qn.MaCv,
                            MaDv = qn.MaDv,
                            MaCapBac = qn.MaCapBac,
                            CapBac1 = cb.CapBac1,
                            TenCv = cv.TenCv,
                            TenDv = dv.TenDv,
                            DiaChi = qn.DiaChi
                        };

           
            ViewBag.ChonDonVi = (obj.Donvis.ToList());
            ViewBag.ChonChucVu = (obj.Chucvus.ToList());
            ViewBag.ChonCapBac = (obj.Capbacs.ToList());
            List<TT_QN> query1 = query.ToList();

            HttpContext.Session.SetJson("QuanNhan", query1);

            return View();
        }
        [HttpPost]
        public IActionResult SuaQuanNhan(int maqn,string hoten, int macv, int madv, int macapbac, string diachi)
        {
            var quannhan = obj.Quannhans.Find(maqn);
            if (quannhan != null)
            {
                quannhan.HoTen = hoten;
                quannhan.MaCv = macv;
                quannhan.MaDv = madv;
                quannhan.MaCapBac = macapbac;
                quannhan.DiaChi = diachi;
                obj.SaveChanges();
                return Json(new
                {
                    status = true
                });
            }
            else
            {
                return Json(new
                {
                    status = false
                });
            }
        }
        #endregion
        #region Quản lý danh sách ra ngoài- giấy tờ
        public IActionResult QuanLyDSGT(int page = 1, int pageSize = 5)
        {

            var query = from ct in obj.Chitietdanhsaches
                        join qn in obj.Quannhans on ct.MaHocVien equals qn.MaQn
                        join cb in obj.Capbacs on qn.MaCapBac equals cb.MaCapBac
                        join dv in obj.Donvis on qn.MaDv equals dv.MaDv
                        join cv in obj.Chucvus on qn.MaCv equals cv.MaCv
                        join dsgt in obj.ChitietdanhsachGiaytos on ct.MaCtds equals dsgt.MaCtds
                        join gt in obj.Giaytos on dsgt.MaGiayTo equals gt.MaGiayTo
                        where ct.TinhTrang==3
                        select new DSGT
                        {
                            MaCtds = dsgt.MaCtds,
                            MaHocVien = ct.MaHocVien,
                            MaGiayTo = dsgt.MaGiayTo,
                            SoGiay = gt.SoGiay,
                            ThoiGianLay = dsgt.ThoiGianLay,
                            ThoiGianTra = dsgt.ThoiGianTra,
                            DaTra = gt.TinhTrang,
                            MaCv = qn.MaCv,
                            MaDv = qn.MaDv,
                            MaCapBac = qn.MaCapBac,
                            CapBac1 = cb.CapBac1,
                            TenCv = cv.TenCv,
                            TenDv = dv.TenDv,
                            TinhTrang = ct.TinhTrang,
                            ThoiGianRa = ct.ThoiGianRa,
                            ThoiGianVao = ct.ThoiGianVao,
                            HoTen = qn.HoTen
                        };
            var model = query.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            // Tính toán thông tin phân trang
            var totalItemCount = query.Count();
            var pagedList = new StaticPagedList<DSGT>(model, page, pageSize, totalItemCount);
            ViewBag.PageStartItem = (page - 1) * pageSize + 1;
            ViewBag.PageEndItem = Math.Min(page * pageSize, totalItemCount);
            ViewBag.Page = page;
            ViewBag.TotalItemCount = totalItemCount;
            List<Rangoai> rn = obj.Rangoais.ToList();
            HttpContext.Session.SetJson("RN", rn);
            return View(pagedList);

        }
        public IActionResult RaNgoai(int id, int magiay, DateTime thoigianra)
        {
           // int max = obj.Rangoais.Max(r => r.MaRn);
            Rangoai rn =new Rangoai();
            rn.ThoiGianRa = thoigianra;
           // rn.MaRn = max + 1;
            rn.MaGiayTo= magiay;
            rn.MaCtds = id;
            obj.Add(rn);
            obj.SaveChanges();
            return RedirectToAction("QuanLyDSGT","Admin");
            /* return Json(new
             {
                 status = false
             });*/

        }
        public IActionResult Vao(int id, int magiay)
        {
            var rn = obj.Rangoais.Where(c => c.MaCtds == id && c.MaGiayTo == magiay).FirstOrDefault();
            rn.ThoiGianVao = DateTime.Now;
            obj.Update(rn);
            obj.SaveChanges();
            return RedirectToAction("QuanLyDSGT", "Admin");

            /* return Json(new
             {
                 status = false
             });*/

        }
        #endregion
        #region Quản lý danh sách vi phạm
        public IActionResult QuanLyViPham(int page = 1, int pageSize = 5)
        {

            var query = from qn in obj.Quannhans
                        join vp in obj.Viphams on qn.MaQn equals vp.MaHv
                        join dv in obj.Donvis on qn.MaDv equals dv.MaDv
                        join cv in obj.Chucvus on qn.MaCv equals cv.MaCv
                        join cb in obj.Capbacs on qn.MaCapBac equals cb.MaCapBac                                              
                        select new HV_VP
                        {
                            MaQn = qn.MaQn,
                            HoTen = qn.HoTen,
                            MaVp = vp.MaVp,
                            MaDv = qn.MaDv,
                            MaCapBac = qn.MaCapBac,
                            MaCv = qn.MaCv,
                            TenCv= cv.TenCv,
                            CapBac1=cb.CapBac1,
                            ThoiGian = vp.ThoiGian,
                            TenDv = dv.TenDv,
                            Loai = vp.Loai,
                            MoTa= vp.MoTa
                        };
            var model = query.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            // Tính toán thông tin phân trang
            var totalItemCount = query.Count();
            var pagedList = new StaticPagedList<HV_VP>(model, page, pageSize, totalItemCount);
            ViewBag.PageStartItem = (page - 1) * pageSize + 1;
            ViewBag.PageEndItem = Math.Min(page * pageSize, totalItemCount);
            ViewBag.Page = page;
            ViewBag.TotalItemCount = totalItemCount;
            ViewBag.ChonQuanNhan = (obj.Quannhans.ToList());
            return View(pagedList);
        }
        [HttpPost]
        public ActionResult ThemViPham(string mota, bool loai, DateTime thoigian, string ghichu, int mahv)
        {
            var moi = new Models.Vipham();
            moi.MoTa = mota;
            moi.Loai = loai;
            moi.ThoiGian = thoigian;
            moi.GhiChu = ghichu;
            moi.MaHv = mahv;
            obj.Viphams.Add(moi);
            obj.SaveChanges();
            return Json(new
            {
                status = true
            });
        }
        public IActionResult XoaViPham(int mavp)
        {
            var vipham = obj.Viphams.Find(mavp);
            if (vipham != null)
            {
                obj.Viphams.Remove(vipham);
                obj.SaveChanges();
                return Json(new
                {
                    status = true
                });
            }
            else
            {
                return Json(new
                {
                    status = false
                });
            }

        }

        public IActionResult SuaViPham(int mavp)
        {
            var model = obj.Viphams.Find(mavp);
            ViewBag.ChonQuanNhan = (obj.Quannhans.ToList());
            var hvvp = new HV_VP();
            if(model != null)
            {
                hvvp.MoTa = model.MoTa;
                hvvp.Loai = model.Loai;
                hvvp.ThoiGian = model.ThoiGian;
                hvvp.MaQn = model.MaHv;
                return View(model);
            }
            else
            {
                return Json(new
                {
                    status = false
                });
            }
        }
        [HttpPost]
        public IActionResult SuaViPham(int mavp, string mota, bool loai, DateTime thoigian, string ghichu, int mahv)
        {
            var vipham = obj.Viphams.Find(mavp);
            if (vipham != null)
            {
                vipham.MoTa = mota;
                vipham.Loai = loai;
                vipham.ThoiGian = thoigian;
                vipham.GhiChu = ghichu;
                vipham.MaHv = mahv;
                obj.SaveChanges();
                return Json(new
                {
                    status = true
                });
            }
            else
            {
                return Json(new
                {
                    status = false
                });
            }
        }
        #endregion

       

    }
}
