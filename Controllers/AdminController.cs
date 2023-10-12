using Microsoft.AspNetCore.Mvc;

namespace QuanLyRaVao.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
