using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using QuanLyRaVao.Data;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using QuanLyRaVao.Models;
using QuanLyRaVao.authorize;


namespace QuanLyRaVao.Controllers
{
    public class AccessController : Controller
    {
        private readonly QuanLyRaVaoContext _context;

        public AccessController(QuanLyRaVaoContext context)
        {
            _context = context;
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
            ViewBag.prevouisPage = Request.Headers.Referer.ToString();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginInfo loginInfo)
        {
            
                ViewData["action"] = "login";
                var user = await _context.Taikhoans.SingleOrDefaultAsync(c => c.Tdn == loginInfo.TDN);
                if (user == null)
                {
                    ViewData["ValidateMessage"] = "Tài khoản không tồn tại";
                    return View();
                }
                var f_MatKhau = GetMD5(loginInfo.MatKhau);
                if (user.MatKhau != f_MatKhau)
                {
                    ViewData["ValidateMessage"] = "Mật khẩu không chính xác";
                    return View();
                }
                if (user.MatKhau == f_MatKhau)
                {
                    List<Claim> claims = new List<Claim>()
                  {
                      new Claim(ClaimTypes.NameIdentifier,loginInfo.TDN),
                      new Claim("OtherProperties","Example Role")

                  };
                HttpContext.Session.SetString("email", loginInfo.TDN);
                var data = from tk in _context.Taikhoans
                            join cv in _context.NhomQuyens on tk.MaNhom equals cv.MaNhom
                            join n in _context.Nhoms on tk.MaNhom equals n.MaNhom
                            join q in _context.Quyens on cv.MaQuyen equals q.MaQuyen
                            
                            where (tk.Tdn == loginInfo.TDN)
                            select new AccountRole
                            {
                                MaTaiKhoan = tk.MaTaiKhoan,
                                MaQ = q.MaQuyen,
                                MaCv = cv.MaNhom,
                                TenCV = n.TenNhom,
                                TenQ = q.Ten,
                                ControllerName = q.ControllerName,
                                ActionName = q.ActionName,
                                
                            };
                List<AccountRole> roles = data.ToList();

                HttpContext.Session.SetJson("QuyenTK", roles);

                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    AuthenticationProperties properties = new AuthenticationProperties()
                    {
                        AllowRefresh = true,
                        // IsPersistent = loginInfo.KeepLoggedIn
                    };
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity), properties);
                   

                

                        return RedirectToAction("Index", "Admin");
                    
                }
                return View();

            
        
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterInfo registerInfo)
        {
            try
            {
                ViewData["action"] = "register";
                var user = await _context.Taikhoans.SingleOrDefaultAsync(c => c.Tdn == registerInfo.TDN);
                if (user != null)
                {
                    ViewData["ValidateMessage"] = "Tài khoản đã tồn tại";
                    return RedirectToAction("Login", "Access");
                }
                var f_MatKhau = GetMD5(registerInfo.MatKhau);
                Taikhoan newTk = new Taikhoan()
                {        
                    Tdn = registerInfo.TDN,
                    MatKhau = registerInfo.MatKhau,
                    //  Quyen = "khach"
                };
                _context.Taikhoans.Add(newTk);
                await _context.SaveChangesAsync();
                List<Claim> claims = new List<Claim>()
                  {
                      new Claim(ClaimTypes.NameIdentifier,registerInfo.TDN),
                      new Claim("OtherProperties","Example Role")

                  };
                HttpContext.Session.SetString("TDN", registerInfo.TDN);
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
            catch (Exception ex)
            {
                ViewData["ValidateMessage"] = "Đăng ký thất bại";
                return View();
            }
        }

        public ActionResult Logout()
        {

            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Access");
        }

    }
}
