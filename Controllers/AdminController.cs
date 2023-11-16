using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using QuanLyRaVao.Data;
using QuanLyRaVao.Models;
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
        public IActionResult QuanLyDonVi(int page = 1, int pageSize = 5)
        {
            
            var query = obj.Donvis.OrderBy(s => s.MaDv);
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
        public IActionResult QuanLyCapBac(int page = 1, int pageSize = 5)
        {
            var query = obj.Capbacs.OrderBy(s => s.MaCapBac);
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

        public IActionResult QuanLyChucVu(int page = 1, int pageSize = 5)
        {

            var query = obj.Chucvus.OrderBy(s => s.MaCv);
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
        public IActionResult QuanLyGiayTo(int page = 1, int pageSize = 5)
        {
            var query = obj.Giaytos.OrderBy(s => s.MaGiayTo);
            var model = query.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            // Tính toán thông tin phân trang
            var totalItemCount = query.Count();
            var pagedList = new StaticPagedList<Giayto>(model, page, pageSize, totalItemCount);
            ViewBag.PageStartItem = (page - 1) * pageSize + 1;
            ViewBag.PageEndItem = Math.Min(page * pageSize, totalItemCount);
            ViewBag.Page = page;
            ViewBag.TotalItemCount = totalItemCount;
            ViewBag.ChonDonVi = new SelectList(obj.Donvis.ToList(), "MaDV", "TenDV");
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
        #endregion

        #endregion
        #region Đại đội
        #region Quản lý danh sách
        #endregion
        #region Quản lý danh sách quân nhân
        #endregion
        #region Quản lý danh sách ra ngoài
        #endregion
        #region Quản lý danh sách vi phạm
        #endregion
        #endregion
        #region Tiểu đoàn
        #region Cập nhập danh sách vi phạm
        #endregion
        #region Phê duyệt danh sách ra ngoài
        #endregion

        #endregion
        #region Vệ Binh
        #region Cập nhật danh sách vi phạm
        #endregion
        #region Xác nhận ra/ vào 
        #endregion
        #endregion

    }
}
