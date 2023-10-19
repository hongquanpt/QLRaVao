using Microsoft.AspNetCore.Mvc;
using QuanLyRaVao.Data;
using QuanLyRaVao.Models;
using System.Security.Cryptography;

namespace QuanLyRaVao.Controllers
{
    public class AdminController : Controller
    {
        private readonly QuanLyRaVaoContext obj = new QuanLyRaVaoContext();
        public IActionResult Index()
        {
            return View();
        }

        #region Danh sách cấp bậc
        public IActionResult QuanLyCapBac()
        {
            var model = obj.Capbacs.ToList();
            ViewBag.dscb = model;
            return View();
        }
        #endregion
        #region Thêm Cấp bậc
        public IActionResult ThemCapBac()
        {
            var dscb = obj.Capbacs.ToList();
            ViewBag.dscb = dscb;

            return View();
        }
        [HttpPost]
        public IActionResult ThemCapBac( string tenCB, string KH)
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
        #endregion
        public IActionResult QuanLyDonVi()
        {
            var model = obj.Donvis.ToList();
            ViewBag.dsdv = model;
            return View();
        }
     
        public IActionResult ThemDonVi()
        {
            var dscb = obj.Donvis.ToList();
            ViewBag.dscb = dscb;
            return View();
        }
        [HttpPost]
        public ActionResult ThemDonVi( string TenDv, short Cap)
        {
            var moi = new Models.Donvi();
            moi.Cap = Cap;
            moi.TenDv = TenDv;
            // Lặp lại cho image3, image4, image5, và image6
            obj.Donvis.Add(moi);
            obj.SaveChanges();
            return Json(new
            {
                status= true 
            });
        }
    

        #region Quản lý quân nhân
        public IActionResult QuanLyQN()
        {
            var model = obj.Quannhans.ToList();
            ViewBag.dsqn = model;
            return View();
        }
        #endregion

        #region Quản lý danh sách ra ngoài
        public IActionResult QuanLyDS()
        {
            var dsrn = from qn in obj.Quannhans
                       join ctds in obj.Chitietdanhsaches on qn.MaQn equals ctds.MaHocVien
                       join ds in obj.Danhsaches on ctds.MaDs equals ds.MaDs
                       select new {
                           qn.HoTen ,
                           ctds.DiaDiem ,
                           ctds.LyDo,
                           ctds.ThoiGianRa,
                           ctds.ThoiGianVao,
                           ctds.GhiChu,
                           ds.TinhTrang
                       };



            ViewBag.dsrn = dsrn;
            return View();
        }
        #endregion

        #region Danh sách vi phạm
        public IActionResult QuanLyDSVP()
        {
            var dsvp = from qn in obj.Quannhans
                       join vp in obj.Viphams on qn.MaQn equals vp.MaHv
                       select new
                       {
                           vp.MaVp,
                           qn.HoTen,
                           vp.MoTa,
                           vp.Loai,
                           vp.ThoiGian,
                           vp.GhiChu
                       };
            ViewBag.dsvp = dsvp;
            return View();
        }
        #endregion

        #region Danh sách tài khoản
        public IActionResult QuanLyDSTK()
        {
            var dstk = from qn in obj.Quannhans
                       join tk in obj.Taikhoans on qn.MaQn equals tk.MaQn
                       select new
                       {
                           tk.MaTaiKhoan,
                           qn.MaQn,
                           qn.HoTen,
                           tk.Tdn,
                           tk.MatKhau
                       };
            ViewBag.dstk = dstk;
            return View();
        }
        #endregion

        #region Xóa tài khoản
        public IActionResult XoaTK(int MaTK)
        {
            var tk = obj.Taikhoans.Find(MaTK);
            if (tk != null)
            {
                obj.Taikhoans.Remove(tk);
                obj.SaveChanges();
                return Json(new
                {
                    status = true
                });
            }
            else
            {
                // Xử lý trường hợp tk là null (nếu cần)
                return Json(new
                {
                    status = false,
                    message = "Không tìm thấy tài khoản"
                });
            }
        }
        #endregion


    }
}
