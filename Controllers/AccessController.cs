using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyRaVao.Data;
using System.Security.Claims;
using QuanLyRaVao.Models;
using System.Security.Cryptography;
using System.Text;

namespace QuanLyRaVao.Controllers
{
    public class AccessController : Controller
    {
        private readonly QuanLyRaVaoContext obj;
        public AccessController(QuanLyRaVaoContext obj)
        {
            this.obj = obj;
        }
        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;

            //nếu bạn muốn các chữ cái in thường thay vì in hoa thì bạn thay chữ "X" in hoa trong "X2" thành "x"
        }
        public IActionResult Login()
        {
            /* ClaimsPrincipal claimUser = HttpContext.User;
             if (claimUser.Identity.IsAuthenticated)
             {
                 return RedirectToAction("Index", "Home");
             }*/
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginInfo loginInfo)
        {
            Console.WriteLine(loginInfo.KeepLoggedIn);
            var user = await obj.Taikhoans.SingleOrDefaultAsync(c => c.Tdn == loginInfo.TDN);
            if (user == null)
            {
                ViewData["ValidateMessage"] = "user not found";
                return View();
            }
            var f_password = GetMD5(loginInfo.MatKhau);
            if (user.MatKhau != f_password)
            {
                ViewData["ValidateMessage"] = "password incorrect";
                return View();
            }
            if (user.MatKhau == f_password)
            {
                List<Claim> claims = new List<Claim>()
                  {
                      new Claim(ClaimTypes.NameIdentifier,loginInfo.TDN),
                      new Claim("OtherProperties","Example Role")

                  };
                var quyen = obj.TkNqs.SingleOrDefault(c => c.MaTaiKhoan == user.MaTaiKhoan);
                //lu thogn tin vao session
                //HttpContext.Session.SetString("TDN", loginInfo.TDN);
                //HttpContext.Session.SetInt32("Ma", user.MaTaiKhoan);
                //HttpContext.Session.SetString("role", quyen.MaQuyen);


                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                AuthenticationProperties properties = new AuthenticationProperties()
                {
                    AllowRefresh = true,
                    // IsPersistent = loginInfo.KeepLoggedIn
                };
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity), properties);
                
                    return RedirectToAction("Index", "VeBinh");
                
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterInfo registerInfo)
        {
            var user = await obj.Taikhoans.SingleOrDefaultAsync(c => c.Tdn == registerInfo.TDN);
            if (user != null)
            {
                ViewData["ValidateMessage"] = "Tài khoản đã tồn tại";
                return RedirectToAction("Login", "Access");
            }
            var f_password = GetMD5(registerInfo.MatKhau);
            Taikhoan newTk = new Taikhoan()
            {
                Tdn = registerInfo.TDN,             
                MatKhau = registerInfo.MatKhau,
               
            };
            obj.Taikhoans.Add(newTk);
            await obj.SaveChangesAsync();
            List<Claim> claims = new List<Claim>()
                  {
                      new Claim(ClaimTypes.NameIdentifier,registerInfo.TDN),
                      new Claim("OtherProperties","Example Role")

                  };
            HttpContext.Session.SetString("email", registerInfo.TDN);
            HttpContext.Session.SetInt32("Ma", newTk.MaTaiKhoan);

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            AuthenticationProperties properties = new AuthenticationProperties()
            {
                AllowRefresh = true
            };
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(claimsIdentity), properties);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Logout()
        {

            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

    }
}
