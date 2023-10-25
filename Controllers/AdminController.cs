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
        #region Quản lý đơn vị
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
            obj.Donvis.Add(moi);
            obj.SaveChanges();
            return Json(new
            {
                status= true 
            });
        }
        #endregion
        #region Quản lý cấp bậc
        public IActionResult QuanLyCapBac()
        {
            var model = obj.Capbacs.ToList();
            ViewBag.dscb = model;
            return View();
        }
        public IActionResult ThemCapBac()
        {
            var dscb = obj.Capbacs.ToList();
            ViewBag.dscb = dscb;

            return View();
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
                return RedirectToAction("QuanLyCapBac");
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
        #endregion
        #region Quản lý giấy tờ
        #endregion
        #region Quản lý tài khoản
        #endregion




    }
}
